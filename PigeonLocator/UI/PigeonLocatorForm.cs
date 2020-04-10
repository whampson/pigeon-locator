#region License
/* Copyright (c) 2018-2020 Wes Hampson
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

using GTASaveData;
using GTASaveData.GTA4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using WHampson.PigeonLocator.Extensions;
using WHampson.PigeonLocator.GameData;
using WHampson.PigeonLocator.Properties;

namespace WHampson.PigeonLocator
{
    internal partial class PigeonLocatorForm : Form
    {
        private const int ScriptSpaceSizePC = 65055;
        private const int ScriptSpaceSizePC_TLAD = 39279;
        private const int ScriptSpaceSizePC_TBOGT = 43847;
        private const int ScriptSpaceSizeConsoles = 64976;
        private const int ScriptSpaceSizeConsoles_TLAD = 39203;
        private const int ScriptSpaceSizeConsoles_TBOGT = 43697;
        private const float ZoomControlScaleFactor = 100.0f;
        private const float GameWorldScaleFactor = 500f / 256f;
        private const int MapCenterOffsetX = 500;
        private const int MapCenterOffsetY = 750;
        private const int MaximumRecentFiles = 9;
        private const int DefaultBlipSize = 2;
        private const bool DefaultShowExterminated = false;
        private const bool DefaultShowRemaining = true;

        private readonly int[] BlipSizes = { 24, 32, 40, 48, 56, 64 };

        private GTA4Save _savegame;
        private SaveFileFormat _platform;
        private EpisodeType _episode;
        private List<Vector3> _remainingPigeons;
        private PointF _mapCoordinates;
        private bool _toolTipVisible;
        private int _blipSizeIndex;
        private bool suppressZoomTrackBarUpdate;
        private bool suppressMapZoomUpdate;
        private string lastDirectory;
        private readonly FixedLengthUniqueQueue<string> recentFilesQueue;

        public PigeonLocatorForm(string path)
            : this()
        {
            LoadFile(path);
        }

        public PigeonLocatorForm()
        {
            suppressZoomTrackBarUpdate = false;
            suppressMapZoomUpdate = false;
            lastDirectory = GetDefaultSaveDirectory();
            recentFilesQueue = new FixedLengthUniqueQueue<string>(MaximumRecentFiles);

            InitializeComponent();
            LoadConfig();
            ResetView();
        }

        private GTA4Save Savegame
        {
            get { return _savegame; }
            set {
                _savegame = value;
                fileInformationMenuItem.Enabled = (_savegame != null);
            }
        }

        private SaveFileFormat Platform
        {
            get { return _platform; }
            set {
                _platform = value;
                platformLabel.Text = Savegame.FileFormat.Name;
                platformLabel.ToolTipText = Savegame.FileFormat.Description;
            }
        }

        private EpisodeType Episode
        {
            get { return _episode; }
            set {
                _episode = value;
                episodeLabel.Text = _episode.ToString();
                episodeLabel.ToolTipText = _episode.GetDescription();
            }
        }

        private List<Vector3> RemainingPigeons
        {
            get { return _remainingPigeons ?? new List<Vector3>(); }
            set {
                _remainingPigeons = value;

                string labelText = "";
                string tooltipText = "";
                if (_savegame != null) {
                    int total = (Episode == EpisodeType.IV) ? Pigeons.NumPigeons : Seagulls.NumSeagulls;
                    int killed = total - RemainingPigeons.Count;
                    labelText = $"{killed}/{total}";
                    tooltipText = $"{killed} out of {total} exterminated.";
                }
                pigeonCountLabel.Text = labelText;
                pigeonCountLabel.ToolTipText = tooltipText;
            }
        }

        private List<Vector3> CollectedPigeons
        {
            get {
                if (Savegame == null) {
                    return new List<Vector3>();
                }

                return AllPigeons.Keys.Except(RemainingPigeons).ToList();
            }
        }

        private Dictionary<Vector3, string> AllPigeons
        {
            get {
                if (Episode == EpisodeType.TLAD) {
                    return Seagulls.TladSeagulls;
                } else if (Episode == EpisodeType.TBOGT) {
                    return Seagulls.TbogtSeagulls;
                }

                return Pigeons.GetAllPigeons();
            }
        }

        private PointF MapCoordinates
        {
            get { return _mapCoordinates; }
            set {
                _mapCoordinates = value;

                mapXLabel.Text = string.Format("X: {0:0.000}", value.X);
                mapYLabel.Text = string.Format("Y: {0:0.000}", value.Y);
            }
        }

        private float MapZoom
        {
            get { return mapPanel.Zoom; }
            set {
                // Adjust map zoom level
                if (!suppressMapZoomUpdate) {
                    mapPanel.Zoom = value;
                }

                // Adjust zoom trackbar position
                if (!suppressZoomTrackBarUpdate) {
                    int trackBarVal = (int) (value * ZoomControlScaleFactor);
                    if (trackBarVal > zoomTrackBar.Maximum) {
                        trackBarVal = zoomTrackBar.Maximum;
                    } else if (trackBarVal < zoomTrackBar.Minimum) {
                        trackBarVal = zoomTrackBar.Minimum;
                    }
                    zoomTrackBar.Value = trackBarVal;
                }

                // Set zoom label text
                zoomLabel.Text = string.Format("{0:0%}", value);
            }
        }

        private string StatusText
        {
            get { return statusLabel.Text; }
            set { statusLabel.Text = value; }
        }

        private int BlipSizeIndex
        {
            get { return _blipSizeIndex; }
            set {
                if (value < 0) {
                    value = 0;
                } else if (value >= BlipSizes.Length) {
                    value = BlipSizes.Length - 1;
                }

                if (value == 0) {
                    decreaseBlipSizeMenuItem.Enabled = false;
                    increaseBlipSizeMenuItem.Enabled = true;
                } else if (value == BlipSizes.Length - 1) {
                    decreaseBlipSizeMenuItem.Enabled = true;
                    increaseBlipSizeMenuItem.Enabled = false;
                } else {
                    decreaseBlipSizeMenuItem.Enabled = true;
                    increaseBlipSizeMenuItem.Enabled = true;
                }

                _blipSizeIndex = value;
                RedrawPigeonBlips();
            }
        }

        private int BlipSize
        {
            get { return BlipSizes[BlipSizeIndex]; }
        }

        private bool ToolTipsEnabled
        {
            get { return viewLocationToolTipsMenuItem.Checked; }
            set { viewLocationToolTipsMenuItem.Checked = value; }
        }

        private bool ToolTipVisible
        {
            get { return _toolTipVisible; }
            set {
                _toolTipVisible = value;

                string text = ToolTipText;
                int x = ToolTipLocation.X;
                int y = ToolTipLocation.Y;
                int duration = short.MaxValue - 1;

                if (_toolTipVisible) {
                    locationInfoToolTip.Show(text, this, x, y, duration);
                } else {
                    locationInfoToolTip.Hide(this);
                }
            }
        }

        private string ToolTipText { get; set; }
        private Point ToolTipLocation { get; set; }

        public void ResetView()
        {
            pigeonCountLabel.Text = "";
            pigeonCountLabel.ToolTipText = "";
            episodeLabel.Text = "";
            episodeLabel.ToolTipText= "";
            platformLabel.Text = "";
            platformLabel.ToolTipText = "";

            Savegame = null;
            StatusText = "No file loaded.";
        }

        public void LoadConfig()
        {
            IniFile cfg = Program.GetConfig();

            string blipSizeStr = cfg.Read(Program.ConfigBlipSize);
            if (!int.TryParse(blipSizeStr, out int blipSize)) {
                blipSize = DefaultBlipSize;
            }
            BlipSizeIndex = blipSize;

            string showExterminatedStr = cfg.Read(Program.ConfigShowExterminated);
            if (!bool.TryParse(showExterminatedStr, out bool showExterminated)) {
                showExterminated = DefaultShowExterminated;
            }
            viewCollectedPigeonsMenuItem.Checked = showExterminated;

            string showRemainingStr = cfg.Read(Program.ConfigShowRemaining);
            if (!bool.TryParse(showRemainingStr, out bool showRemaining)) {
                showRemaining = DefaultShowRemaining;
            }
            viewRemainingPigeonsMenuItem.Checked = showRemaining;

            lastDirectory = cfg.Read(Program.ConfigLastDirectory);

            LoadRecentFiles();
        }

        /// <summary>
        /// Loads a GTA IV savegame from a file, then updates the
        /// pigeon map if the file is valid.
        /// If the file is not valid, an error message is shown.
        /// </summary>
        /// <param name="path">
        /// The path to the file to load.
        /// </param>
        private void LoadFile(string path)
        {
            if (Directory.Exists(path)) {
                string title = "Not A File";
                string fmt = "{0} is a directory.";
                ShowErrorMsgDialog(title, string.Format(fmt, path));
                return;
            }

            try {
                bool valid = SaveFile.GetFileFormat<GTA4Save>(path, out SaveFileFormat fmt);
                if (!valid) {
                    string title = "Invalid File Format";
                    string msg = "Not a valid GTA IV save file!";
                    ShowErrorMsgDialog(title, msg);
                    return;
                }

                Savegame = SaveFile.Load<GTA4Save>(path, fmt);
                Platform = fmt;
            } catch (FileNotFoundException ex) {
                Program.LogException(LogLevel.Info, ex);
                string title = "File Not Found";
                string fmt = "The following file could not be found: {0}";
                ShowErrorMsgDialog(title, string.Format(fmt, path));
                return;
            }

            if (Savegame.ScriptSpace == ScriptSpaceSizePC || Savegame.ScriptSpace == ScriptSpaceSizeConsoles) {
                Episode = EpisodeType.IV;
            } else if (Savegame.ScriptSpace == ScriptSpaceSizePC_TLAD || Savegame.ScriptSpace == ScriptSpaceSizeConsoles_TLAD) {
                Episode = EpisodeType.TLAD;
            } else if (Savegame.ScriptSpace == ScriptSpaceSizePC_TBOGT || Savegame.ScriptSpace == ScriptSpaceSizeConsoles_TBOGT) {
                Episode = EpisodeType.TBOGT;
            } else {
                string title = "Episode Unknown";
                string fmt = "Unable to determine episode!\n(script size = {0})\n\nAssuming vanilla GTA IV.";
                ShowWarnMsgDialog(title, string.Format(fmt, Savegame.ScriptSpace));
                Episode = EpisodeType.IV;
            }

            List<Vector3> hiddenPackages = new List<Vector3>();
            foreach (Pickup p in Savegame.Pickups.PickupsArray) {
                if (p.PickupType == (int) PickupType.HiddenPackage &&
                   ((p.ObjectId == (int) ObjectType.Pigeon && Episode == EpisodeType.IV) ||
                    (p.ObjectId == (int) ObjectType.Seagull_TLAD && Episode == EpisodeType.TLAD) ||
                    (p.ObjectId == (int) ObjectType.Seagull_TBOGT && Episode == EpisodeType.TBOGT))) {
                    hiddenPackages.Add(new Vector3(p.Position.X, p.Position.Y, p.Position.Z));  // TODO: why does implicit operator not work?
                }
            }

            RemainingPigeons = hiddenPackages;
            StatusText = string.Format("Loaded '{0}'.", Savegame.Name);
            

            AddRecentFilePath(path);
            RedrawPigeonBlips();
        }

        /// <summary>
        /// Adds a new path to the queue of recently-opened files,
        /// then refreshes the "File > Open Recent" menu, and lastly
        /// updates the config file with the list of recently-opened files.
        /// </summary>
        /// <param name="path"></param>
        private void AddRecentFilePath(string path)
        {
            recentFilesQueue.Enqueue(path);

            ReloadRecentFilesMenu();
            SaveRecentFiles();
        }

        /// <summary>
        /// Populates the "File > Open Recent" menu with paths from the
        /// recently-opened files queue.
        /// </summary>
        private void ReloadRecentFilesMenu()
        {
            fileOpenRecentMenuItem.DropDownItems.Clear();

            int i = 1;
            foreach (string recentFile in recentFilesQueue.Reverse()) {
                ToolStripMenuItem recentFileItem = new ToolStripMenuItem();
                recentFileItem.Text = string.Format("{0}: {1}", i++, recentFile);
                recentFileItem.Tag = recentFile;
                recentFileItem.Click += OpenRecentMenuItem_OnClick;
                fileOpenRecentMenuItem.DropDownItems.Add(recentFileItem);
            }

            if (i == 1) {
                fileOpenRecentMenuItem.DropDownItems.Add(noRecentItemsMenuItem);
            }
        }

        /// <summary>
        /// Loads all recently-opened file paths from the config file on disk.
        /// </summary>
        private void LoadRecentFiles()
        {
            for (int i = 0; i < MaximumRecentFiles; i++) {
                string key = Program.ConfigRecentFileKey + i;
                string val = Program.GetConfig().Read(key);
                if (!string.IsNullOrWhiteSpace(val)) {
                    recentFilesQueue.Enqueue(val);
                }
            }

            ReloadRecentFilesMenu();
        }

        /// <summary>
        /// Writes all recently-opened file paths to the config file on disk.
        /// </summary>
        private void SaveRecentFiles()
        {
            for (int i = 0; i < MaximumRecentFiles; i++) {
                string key = Program.ConfigRecentFileKey + i;
                string val = recentFilesQueue.ElementAtOrDefault(i);
                Program.GetConfig().Write(key, val);
            }
        }

        /// <summary>
        /// Translates a mouse location on the UI to game world coordinates.
        /// </summary>
        /// <param name="mouseX">The mouse x-coordinate.</param>
        /// <param name="mouseY">The mouse y-coordinate</param>
        /// <returns>The game world coordinates.</returns>
        private PointF GetGameWorldCoords(int mouseX, int mouseY)
        {
            float worldX = ((mouseX + mapPanel.ViewRectangle.X) / mapPanel.Zoom) - (mapPanel.Image.Width / 2);
            worldX *= GameWorldScaleFactor;
            worldX += MapCenterOffsetX;

            float worldY = (-(mouseY + mapPanel.ViewRectangle.Y) / mapPanel.Zoom) + (mapPanel.Image.Height / 2);
            worldY *= GameWorldScaleFactor;
            worldY += MapCenterOffsetY;

            return new PointF(worldX, worldY);
        }

        /// <summary>
        /// Translates a game world location to the location of a pixel on the map image.
        /// </summary>
        /// <param name="worldX">The game world x-coordinate.</param>
        /// <param name="worldY">The game world y-coordinate.</param>
        /// <returns>The map image pixel coordinate.</returns>
        private Point GetMapImagePixel(float worldX, float worldY)
        {
            int mapX = (int) ((worldX - MapCenterOffsetX) / GameWorldScaleFactor);
            mapX += (mapPanel.Image.Width / 2);
            int mapY = (int) -((worldY - MapCenterOffsetY) / GameWorldScaleFactor);
            mapY += (mapPanel.Image.Height / 2);

            return new Point(mapX, mapY);
        }

        /// <summary>
        /// Checks whether a given point falls within the boundaries of a square.
        /// </summary>
        /// <param name="p">The point to check.</param>
        /// <param name="squareCenter">The center of the square.</param>
        /// <param name="squareDim">The side length of the square.</param>
        /// <returns>
        /// True if <paramref name="p"/> falls within the square,
        /// False otherwise.
        /// </returns>
        private bool IsPointInSquare(PointF p, PointF squareCenter, float squareDim)
        {
            float xDelta = Math.Abs(p.X - squareCenter.X);
            float yDelta = Math.Abs(p.Y - squareCenter.Y);

            return xDelta <= squareDim / 2
                && yDelta <= squareDim / 2;
        }

        /// <summary>
        /// Resets the map, then redraws all remaining pigeon blips.
        /// </summary>
        private void RedrawPigeonBlips()
        {
            // Refresh map
            mapPanel.Image = Resources.Map_Blue_3072x2304;

            // Get blip image
            Bitmap blipImage = Resources.Pigeon_64x64;
            Graphics mapGraphics = Graphics.FromImage(mapPanel.Image);

            // Draw blips on map
            if (viewRemainingPigeonsMenuItem.Checked) {
                blipImage.FloodFill(new Point(40, 40), Color.FromArgb(224, 224, 224, 224));
                foreach (Vector3 loc in RemainingPigeons) {
                    DrawBlip(mapGraphics, blipImage, loc.X, loc.Y);
                }
            }

            if (viewCollectedPigeonsMenuItem.Checked) {
                blipImage.FloodFill(new Point(40, 40), Color.FromArgb(192, 255, 192, 192));
                foreach (Vector3 loc in CollectedPigeons) {
                    DrawBlip(mapGraphics, blipImage, loc.X, loc.Y);
                }
            }

            // Re-paint map
            mapPanel.Invalidate();
        }

        /// <summary>
        /// Draws a blip on the map.
        /// </summary>
        /// <param name="mapGraphics">The map's <see cref="Graphics"/> object.</param>
        /// <param name="blipImg">The blip sprite.</param>
        /// <param name="worldX">Game world x-coordinate.</param>
        /// <param name="worldY">Game world y-coordinate.</param>
        private void DrawBlip(Graphics mapGraphics, Bitmap blipImg, float worldX, float worldY)
        {
            Point mapPixel = GetMapImagePixel(worldX, worldY);

            mapGraphics.DrawImage(
                blipImg,
                mapPixel.X - (BlipSize / 2),
                mapPixel.Y - (BlipSize / 2),
                BlipSize,
                BlipSize);
        }

        /// <summary>
        /// Gets all nearest pigeons 
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="squareDim"></param>
        /// <returns></returns>
        private Vector3[] GetNearestPigeons(PointF loc, float squareDim)
        {
            return RemainingPigeons
                .Where(vect => IsPointInSquare(new PointF(vect.X, vect.Y), loc, squareDim) && viewRemainingPigeonsMenuItem.Checked)
                .Union(CollectedPigeons.Where(vect => IsPointInSquare(new PointF(vect.X, vect.Y), loc, squareDim) && viewCollectedPigeonsMenuItem.Checked))
                .ToArray();
        }

        /// <summary>
        /// Gets the path to the GTA IV user data directory.
        /// </summary>
        /// <returns></returns>
        private string GetDefaultSaveDirectory()
        {
            return Environment.GetEnvironmentVariable("LocalAppData") + @"\Rockstar Games\GTA IV\savegames";
        }

        /// <summary>
        /// Displays a dialog containing savegame metadata.
        /// </summary>
        private void ShowFileInfoDialog()
        {
            string fileInfo =
                $"Platform: {Savegame.FileFormat}\n" +
                $"Episode: {Episode}\n" +
                $"Version: {Savegame.SaveVersion}\n" +
                $"Name: {Savegame.Name}\n" +
                $"Time Last Saved: {Savegame.TimeLastSaved : MMM d, yyyy HH:mm:ss}\n" +
                $"File Size: {Savegame.SaveSizeInBytes} bytes";
            ShowInfoMsgDialog("File Information", fileInfo);
        }

        /// <summary>
        /// Displays program 'About' dialog.
        /// </summary>
        private void ShowAboutDialog()
        {
            FileVersionInfo ver = Program.GetVersion();

            string desc = "Reveals the remaining flying rats in a saved GTA IV game.";
            string specialThanks = "Special thanks to GTAKid667 for testing and " +
                "providing feedback during the development process.";
            string verString = (ver != null)
                ? string.Format("{0} (build {1})", ver.ProductVersion, ver.FilePrivatePart)
                : "null";

            ShowInfoMsgDialog("About",
                $"{Program.GetAssemblyTitle()}\n" +
                $"Version: {verString}\n\n" +
                $"{desc}\n\n\n" +
                $"{Program.GetCopyrightString()}\n\n" +
                $"{specialThanks}");
        }

        /// <summary>
        /// Displays an informational message box with 'OK' button and blue 'i' icon.
        /// </summary>
        /// <param name="title">The message box title.</param>
        /// <param name="msg">The message box message.</param>
        private void ShowInfoMsgDialog(string title, string msg)
        {
            MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays an error message box with 'OK' button and red 'x' icon.
        /// </summary>
        /// <param name="title">The message box title.</param>
        /// <param name="msg">The message box message.</param>
        private void ShowErrorMsgDialog(string title, string msg)
        {
            MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowWarnMsgDialog(string title, string msg)
        {
            MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #region Event Handlers
        private void FileOpenMenuItem_OnClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ValidateNames = true;
            fileDialog.Multiselect = false;
            fileDialog.InitialDirectory = lastDirectory;

            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                LoadFile(fileDialog.FileName);
                lastDirectory = Path.GetDirectoryName(fileDialog.FileName);
            }

            Program.GetConfig().Write(Program.ConfigLastDirectory, lastDirectory);
        }

        private void OpenRecentMenuItem_OnClick(object sender, EventArgs e)
        {
            string path = (string) ((ToolStripMenuItem) sender).Tag;
            LoadFile(path);
        }

        private void FileInformationMenuItem_OnClick(object sender, EventArgs e)
        {
            if (Savegame == null) {
                return;
            }

            ShowFileInfoDialog();
        }

        private void ExitMenuItem_OnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewRemainingPigeonsMenuItem_OnClick(object sender, EventArgs e)
        {
            RedrawPigeonBlips();
            Program.GetConfig().Write(Program.ConfigShowRemaining, viewRemainingPigeonsMenuItem.Checked.ToString());
        }

        private void ViewCollectedPigeonsMenuItem_OnClick(object sender, EventArgs e)
        {
            RedrawPigeonBlips();
            Program.GetConfig().Write(Program.ConfigShowExterminated, viewCollectedPigeonsMenuItem.Checked.ToString());
        }

        private void IncreaseBlipSizeMenuItem_OnClick(object sender, EventArgs e)
        {
            BlipSizeIndex += 1;
            Program.GetConfig().Write(Program.ConfigBlipSize, BlipSizeIndex.ToString());
        }

        private void DecreaseBlipSizeMenuItem_OnClick(object sender, EventArgs e)
        {
            BlipSizeIndex -= 1;
            Program.GetConfig().Write(Program.ConfigBlipSize, BlipSizeIndex.ToString());
        }

        private void AboutMenuItem_OnClick(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        private void ThrowExceptionMenuItem_OnClick(object sender, EventArgs e)
        {
            #if DEBUG
            throw new Exception("Test exception.");
            #endif
        }

        private void CauseIndexOutOfRangeExceptionMenuItem_OnClick(object sender, EventArgs e)
        {
            #if DEBUG
            byte[] b = new byte[4];
            b[4] = 0xFE;
            #endif
        }

        private void ZoomTrackBar_OnMouseUp(object sender, MouseEventArgs e)
        {
            mapPanel.Focus();
        }

        private void ZoomTrackBar_OnScroll(object sender, EventArgs e)
        {
            suppressZoomTrackBarUpdate = true;
            MapZoom = zoomTrackBar.Value / ZoomControlScaleFactor;
            suppressZoomTrackBarUpdate = false;
        }

        private void MapPanel_OnZoom(object sender, ImagePanel.ZoomEventArgs e)
        {
            suppressMapZoomUpdate = true;
            MapZoom = e.NewValue;
            suppressMapZoomUpdate = false;
        }

        private void MapPanel_OnMouseMove(object sender, MouseEventArgs e)
        {
            MapCoordinates = GetGameWorldCoords(e.X, e.Y);

            toolTipTimer.Stop();

            if (IsPointInSquare(new PointF(e.X, e.Y), ToolTipLocation, BlipSize)) {
                if (ToolTipVisible) {
                    return;
                }
            } else if (ToolTipVisible) {
                ToolTipVisible = false;
            }

            ToolTipLocation = new Point(e.X, e.Y);
            toolTipTimer.Start();
        }

        private void ToolTipTimer_OnTick(object sender, EventArgs e)
        {
            if (!ToolTipsEnabled) {
                if (ToolTipVisible) {
                    ToolTipVisible = false;
                }
                return;
            }

            Vector3[] nearest = GetNearestPigeons(MapCoordinates, BlipSize * 2);
            if (nearest.Length == 0) {
                if (ToolTipVisible) {
                    ToolTipVisible = false;
                }
                return;
            }

            if (ToolTipVisible) {
                return;
            }

            string desc = "";
            for (int i = 0; i < nearest.Length; i++) {
                // Append index (if necessary)
                if (nearest.Length > 1) {
                    desc += (i + 1) + ") ";
                }


                // Append description

                bool hasDesc = AllPigeons.TryGetValue(nearest[i], out string s);
                bool isCollected = CollectedPigeons.Contains(nearest[i]);
                if (isCollected) {
                    desc += "(exterminated)\n";
                }
                if (hasDesc && !string.IsNullOrEmpty(s)) {
                    desc += s;
                } else {
                    desc += "(no information available)";
                }

                // Add a blank line (if necessary)
                if (nearest.Length > 1 && i != nearest.Length - 1) {
                    desc += "\n\n";
                }
            }

            ToolTipText = desc;
            ToolTipVisible = true;
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Copy;
            } else {
                e.Effect = DragDropEffects.None;
            }
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[]) e.Data.GetData(DataFormats.FileDrop);
            if (paths.Length > 1) {
                ShowErrorMsgDialog("Too Many Files", "Only one file may be opened at a time.");
                return;
            }

            LoadFile(paths[0]);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            #if DEBUG
            debugMenu.Enabled = true;
            debugMenu.Visible = true;
            #endif

            // If no file was loaded at startup, ensure UI components reflect
            // that nothing was loaded
            if (Savegame == null) {
                ResetView();
            }

            // Initialize other components controlled by properties
            MapCoordinates = new PointF();
            ToolTipText = "";
            MapZoom = mapPanel.Zoom;

            // Center the map in the view window (approximate)
            mapPanel.ViewPosition = new PointF(0, 4.5f / 7f);

            // Ensure zoom and pan with mouse and keys works out-of-the-box
            mapPanel.Focus();
        }
        #endregion

        enum EpisodeType
        {
            [Description("Grand Theft Auto IV")]
            IV,

            [Description("The Lost and Damned")]
            TLAD,

            [Description("The Ballad Of Gay Tony")]
            TBOGT
        };

        enum ObjectType
        {
            Pigeon = 0x08DC,
            Seagull_TLAD = 0x01AF,
            Seagull_TBOGT = 0x0574
        }

        enum PickupType
        {
            HiddenPackage = 3
        }
    }
}
