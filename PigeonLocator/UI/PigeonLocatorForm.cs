#region License
/* Copyright (c) 2018 W. Hampson
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

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WHampson.PigeonLocator.Properties;

namespace WHampson.PigeonLocator
{
    internal partial class PigeonLocatorForm : Form
    {
        private const float ZoomControlScaleFactor = 100.0f;
        private const float GameWorldScaleFactor = 500f / 256f;
        private const int MapCenterOffsetX = 500;
        private const int MapCenterOffsetY = 750;

        private IvSavegame _savegame;
        private Vect3d[] _remainingPigeons;
        private PointF _mapCoordinates;
        private bool _toolTipVisible;
        private bool suppressZoomTrackBarUpdate;
        private bool suppressMapZoomUpdate;

        public PigeonLocatorForm()
        {
            suppressZoomTrackBarUpdate = false;
            suppressMapZoomUpdate = false;
            BlipDimension = 35;

            InitializeComponent();
        }

        public PigeonLocatorForm(string path)
            : this()
        {
            LoadFile(path);
        }

        /// <summary>
        /// Gets or sets the currently-loaded GTA IV savegame.
        /// </summary>
        /// <remarks>
        /// Enables the File > File Information menu item if the
        /// the value is not null.
        /// </remarks>
        private IvSavegame Savegame
        {
            get { return _savegame; }
            set {
                _savegame = value;
                fileInformationMenuItem.Enabled = (_savegame != null);
            }
        }

        /// <summary>
        /// Gets or sets the array of coordinates for remaining pigeons.
        /// </summary>
        /// <remarks>
        /// Also sets the text of the 'Collected' label.
        /// </remarks>
        private Vect3d[] RemainingPigeons
        {
            get { return _remainingPigeons ?? new Vect3d[0]; }
            set {
                _remainingPigeons = value;

                string labelText = "";
                if (_savegame != null) {
                    labelText = string.Format("{0}/{1} Collected",
                        Pigeons.NumPigeons - _remainingPigeons.Length,
                        Pigeons.NumPigeons);
                }
                pigeonCountLabel.Text = labelText;
            }
        }

        /// <summary>
        /// Gets or sets the current map coordinates.
        /// </summary>
        /// <remarks>
        /// Also sets the text of the 'X' and 'Y' labels.
        /// </remarks>
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

        /// <summary>
        /// Gets or sets the status text.
        /// </summary>
        private string StatusText
        {
            get { return statusLabel.Text; }
            set { statusLabel.Text = value; }
        }

        /// <summary>
        /// Gets or sets the dimension of the blip square in pixels.
        /// </summary>
        private int BlipDimension
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets whether to display pigeon location tool tips.
        /// </summary>
        private bool ToolTipEnabled
        {
            get { return viewLocationToolTipsMenuItem.Checked; }
            set { viewLocationToolTipsMenuItem.Checked = value; }
        }

        /// <summary>
        /// Gets or sets whether a pigeon location tool tip is currently displaying.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the pigeon location tool tip text.
        /// </summary>
        private string ToolTipText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the pigeon location tool tip location.
        /// </summary>
        private Point ToolTipLocation
        {
            get;
            set;
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
                Savegame = IvSavegame.Load(path);
            } catch (FileNotFoundException ex) {
                Program.LogException(LogLevel.Info, ex);
                string title = "File Not Found";
                string fmt = "The following file could not be found: {0}";
                ShowErrorMsgDialog(title, string.Format(fmt, path));
                return;
            } catch (InvalidDataException ex) {
                Program.LogException(LogLevel.Info, ex);
                string title = "Invalid File Format";
                string msg = "Not a valid GTA IV savedata file!";
                ShowErrorMsgDialog(title, msg);
                return;
            }

            RemainingPigeons = Savegame.GetRemainingPigeonLocations();
            StatusText = string.Format("Loaded '{0}'.", Savegame.LastMissionName);

            RedrawPigeonBlips();
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
            mapPanel.Image = Resources.GTAIV_Map_3072x2304;

            // Get blip image
            Bitmap blipImage = Resources.GTAIV_Pigeon_Bordered_240x240;
            Graphics mapGraphics = Graphics.FromImage(mapPanel.Image);

            // Draw blips on map
            foreach (Vect3d loc in RemainingPigeons) {
                DrawBlip(mapGraphics, blipImage, loc.X, loc.Y);
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
                mapPixel.X - (BlipDimension / 2),
                mapPixel.Y - (BlipDimension / 2),
                BlipDimension,
                BlipDimension);
        }

        /// <summary>
        /// Gets all nearest pigeons 
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="squareDim"></param>
        /// <returns></returns>
        private Vect3d[] GetNearestPigeons(PointF loc, float squareDim)
        {
            return RemainingPigeons
                .Where(vect => IsPointInSquare(new PointF(vect.X, vect.Y), loc, squareDim))
                .ToArray();
        }

        /// <summary>
        /// Gets the path to the GTA IV user data directory.
        /// </summary>
        /// <returns></returns>
        private string GetGameUserDataDirectory()
        {
            return Environment.GetEnvironmentVariable("LocalAppData")
                + @"\Rockstar Games\GTA IV";
        }

        /// <summary>
        /// Displays a dialog containing savegame metadata.
        /// </summary>
        private void ShowFileInfoDialog()
        {
            string fileInfo = string.Format(
                "Mission Name: {0}\n" +
                "Timestamp: {1}\n" +
                "File Size: {2} bytes\n" +
                "File Version: {3}",
                Savegame.LastMissionName,
                Savegame.Timestamp.ToString("MMM d, yyyy HH:mm:ss"),
                Savegame.FileSize,
                Savegame.FileVersion);
            ShowInfoMsgDialog("File Information", fileInfo);
        }

        /// <summary>
        /// Displays program 'About' dialog.
        /// </summary>
        private void ShowAboutDialog()
        {
            string desc = "Maps-out all remaining flying rats in a GTA IV savegame.";
            FileVersionInfo vers = Program.GetProgramVersion();

            string aboutString = string.Format(
                "{0}\n" +
                "Version: {1}\n\n" +
                "{2}\n\n" +
                "{3}",
                Program.GetProgramName(),
                (vers == null)
                    ? "null"
                    : string.Format("{0} (build {1})", vers.ProductVersion, vers.FilePrivatePart),
                desc,
                Program.GetCopyrightString());
            ShowInfoMsgDialog("About", aboutString);
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

        private void FileOpenMenuItem_OnClick(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ValidateNames = true;
            fileDialog.Multiselect = false;
            fileDialog.InitialDirectory = GetGameUserDataDirectory();

            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK) {
                LoadFile(fileDialog.FileName);
            }
        }

        private void FileInformationMenuItem_OnClick(object sender, EventArgs e)
        {
            if (Savegame == null) {
                return;
            }

            ShowFileInfoDialog();
        }

        private void FileExitMenuItem_OnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpAboutMenuItem_OnClick(object sender, EventArgs e)
        {
            ShowAboutDialog();
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

            if (IsPointInSquare(new PointF(e.X, e.Y), ToolTipLocation, BlipDimension)) {
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
            if (!ToolTipEnabled) {
                if (ToolTipVisible) {
                    ToolTipVisible = false;
                }
                return;
            }

            Vect3d[] nearest = GetNearestPigeons(MapCoordinates, BlipDimension * 2);
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
                bool hasDesc = Pigeons.Descriptions.TryGetValue(nearest[i], out string s);
                if (hasDesc) {
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
            debugMenuStripItem.Enabled = true;
            debugMenuStripItem.Visible = true;
            #endif

            // If no file was loaded at startup, ensure UI components reflect
            // that nothing was loaded
            if (Savegame == null) {
                Savegame = null;
                StatusText = "No file loaded.";
                RemainingPigeons = new Vect3d[0];
            }

            // Initialize other components controlled by properties
            MapCoordinates = new PointF();
            ToolTipText = "";
            MapZoom = mapPanel.Zoom;

            // Center the map in the view window (approximate)
            mapPanel.ViewPosition = new PointF(0, 4f / 7f);

            // Ensure zoom and pan with mouse and keys works out-of-the-box
            mapPanel.Focus();
        }

        private void DebugExceptionsThrowExceptionMenuItem_OnClick(object sender, EventArgs e)
        {
            #if DEBUG
            throw new Exception("Test exception.");
            #endif
        }

        private void DebugExceptionsCauseIndexOutOfRangeExceptionMenuItem_OnClick(object sender, EventArgs e)
        {
            #if DEBUG
            byte[] b = new byte[4];
            b[4] = 0xFE;
            #endif
        }
    }
}
