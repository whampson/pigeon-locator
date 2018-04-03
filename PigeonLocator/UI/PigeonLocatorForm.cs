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
        private const int PigeonCount = 200;
        private const float ZoomControlScaleFactor = 100.0f;
        private const float GameWorldScaleFactor = 500f / 256f; // Each 256 pixels corresponds to 500 meters
        private const int MapCenterOffsetX = 500;
        private const int MapCenterOffsetY = 750;

        private IvSavegame _savegame;
        private PointF _cursorCoords;
        private ToolTip locationInfoToolTip;
        private bool isToolTipShowing;
        private Point toolTipCoords;
        private Vect3d[] pigeonCoords;

        public PigeonLocatorForm()
        {
            _savegame = null;
            _cursorCoords = new PointF();
            BlipDimension = 25;
            locationInfoToolTip = new ToolTip();
            isToolTipShowing = false;
            toolTipCoords = new Point();
            pigeonCoords = new Vect3d[0];

            InitializeComponent();
        }

        private IvSavegame Savegame
        {
            get { return _savegame; }
            set {
                _savegame = value;
                fileInformationMenuItem.Enabled = (_savegame != null);
            }
        }

        private PointF MapCoords
        {
            get { return _cursorCoords; }
            set {
                _cursorCoords = value;

                mapXLabel.Text = string.Format("X: {0:0.000}", value.X);
                mapYLabel.Text = string.Format("Y: {0:0.000}", value.Y);
            }
        }

        //private float MapZoom
        //{

        //}

        private string StatusText
        {
            get { return statusLabel.Text; }
            set { statusLabel.Text = value; }
        }

        private int BlipDimension
        {
            get;
            set;
        }

        private bool ToolTipsEnabled
        {
            get { return viewLocationToolTipsMenuItem.Checked; }
        }

        private void LoadFile(string path)
        {
            try {
                Savegame = IvSavegame.Load(path);
            } catch (FileNotFoundException ex) {
                string title = "File Not Found";
                string fmt = "The following file could not be found: {0}";
                ShowErrorMsgDialog(title, string.Format(fmt, path));
                return;
            } catch (InvalidDataException ex) {
                string title = "Invalid File Format";
                string msg = "Not a valid GTA IV savedata file!";
                ShowErrorMsgDialog(title, msg);
                return;
            }

            pigeonCoords = Savegame.GetRemainingPigeonLocations();
            StatusText = string.Format("Loaded '{0}'.", Savegame.LastMissionName);

            foreach (Vect3d loc in pigeonCoords) {
                Console.WriteLine(loc);
            }

            RedrawPigeonBlips();
        }

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

        private Point GetMapImagePixel(float worldX, float worldY)
        {
            int mapX = (int) ((worldX - MapCenterOffsetX) / GameWorldScaleFactor);
            mapX += (mapPanel.Image.Width / 2);
            int mapY = (int) -((worldY - MapCenterOffsetY) / GameWorldScaleFactor);
            mapY += (mapPanel.Image.Height / 2);

            return new Point(mapX, mapY);
        }

        private bool IsPointInSquare(PointF p, PointF squareCenter, float squareDim)
        {
            float xDelta = Math.Abs(p.X - squareCenter.X);
            float yDelta = Math.Abs(p.Y - squareCenter.Y);

            return xDelta <= squareDim / 2
                && yDelta <= squareDim / 2;
        }

        private void RedrawPigeonBlips()
        {
            mapPanel.Image = Resources.GTAIV_Map_3072x2304;
            Bitmap blipImage = Resources.GTAIV_Pigeon_240x240;
            Graphics g = Graphics.FromImage(mapPanel.Image);

            foreach (Vect3d loc in pigeonCoords) {
                PlotPigeonBlip(g, blipImage, loc.X, loc.Y);
            }

            mapPanel.Invalidate();
        }

        private void PlotPigeonBlip(Graphics g, Bitmap blipImg, float worldX, float worldY)
        {
            Point mapPixel = GetMapImagePixel(worldX, worldY);
            //g.FillRectangle(
            //    Brushes.Red,
            //    mapPixel.X - (BlipDimension / 2),
            //    mapPixel.Y - (BlipDimension / 2),
            //    BlipDimension,
            //    BlipDimension);

            g.DrawImage(
                blipImg,
                mapPixel.X - (BlipDimension / 2),
                mapPixel.Y - (BlipDimension / 2),
                BlipDimension,
                BlipDimension);
        }

        private Vect3d[] GetNearestPigeons(PointF loc, float squareDim)
        {
            return pigeonCoords
                .Where(vect => IsPointInSquare(new PointF(vect.X, vect.Y), loc, squareDim))
                .ToArray();
        }

        private void ShowLocationToolTip(int windowX, int windowY, string text)
        {
            locationInfoToolTip.Show(text, this, windowX, windowY, short.MaxValue - 1);
            isToolTipShowing = true;
        }

        private void HideLocationToolTip()
        {
            locationInfoToolTip.Hide(this);
            isToolTipShowing = false;
        }

        private string GetGameUserDataDirectory()
        {
            return Environment.GetEnvironmentVariable("LocalAppData")
                + @"\Rockstar Games\GTA IV";
        }

        private void ShowFileInfoDialog()
        {
            string fileInfo = string.Format(
                "Mission Name: {0}\n" +
                "Timestamp: {1}\n" +
                "File Size: {2} bytes\n" +
                "File Version: {3}\n\n" +
                "Pigeons Killed: {4}/{5}",
                Savegame.LastMissionName,
                Savegame.Timestamp.ToString("MMM d, yyyy HH:mm:ss"),
                Savegame.FileSize,
                Savegame.FileVersion,
                PigeonCount - pigeonCoords.Length,
                PigeonCount);
            ShowInfoMsgDialog("File Information", fileInfo);
        }

        private void ShowAboutDialog()
        {
            string desc = "Maps-out all remaining flying rats in a GTA IV savegame.";
            FileVersionInfo vers = PigeonLocator.GetProgramVersion();

            string aboutString = string.Format(
                "{0}\n" +
                "Version: {1}\n\n" +
                "{2}\n\n" +
                "{3}",
                PigeonLocator.GetProgramName(),
                (vers == null)
                    ? "null"
                    : string.Format("{0} (build {1})", vers.ProductVersion, vers.FilePrivatePart),
                desc,
                PigeonLocator.GetCopyrightString());
            ShowInfoMsgDialog("About", aboutString);
        }

        private void ShowInfoMsgDialog(string title, string msg)
        {
            MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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

        private void ZoomTrackBar_OnScroll(object sender, EventArgs e)
        {
            mapPanel.Zoom = zoomTrackBar.Value / ZoomControlScaleFactor;
            zoomLabel.Text = string.Format("{0:0%}", mapPanel.Zoom);
        }

        private void ZoomTrackBar_OnMouseUp(object sender, MouseEventArgs e)
        {
            mapPanel.Focus();
        }

        private void MapPanel_OnZoom(object sender, ImagePanel.ZoomEventArgs e)
        {
            int val = (int) (e.NewValue * ZoomControlScaleFactor);
            if (val > zoomTrackBar.Maximum) {
                val = zoomTrackBar.Maximum;
            } else if (val < zoomTrackBar.Minimum) {
                val = zoomTrackBar.Minimum;
            }

            zoomTrackBar.Value = val;
            zoomLabel.Text = string.Format("{0:0%}", e.NewValue);
            //RedrawPigeonBlips();
        }

        private void MapPanel_OnMouseMove(object sender, MouseEventArgs e)
        {
            MapCoords = GetGameWorldCoords(e.X, e.Y);

            toolTipTimer.Stop();

            if (IsPointInSquare(new PointF(e.X, e.Y), toolTipCoords, BlipDimension)) {
                if (isToolTipShowing) {
                    return;
                }
            } else if (isToolTipShowing) {
                HideLocationToolTip();
            }

            toolTipCoords = new Point(e.X, e.Y);
            toolTipTimer.Start();
        }

        private void ToolTipTimer_OnTick(object sender, EventArgs e)
        {
            if (!ToolTipsEnabled) {
                if (isToolTipShowing) {
                    HideLocationToolTip();
                }
                return;
            }

            Vect3d[] nearest = GetNearestPigeons(MapCoords, BlipDimension * 2);
            if (nearest.Length == 0) {
                if (isToolTipShowing) {
                    HideLocationToolTip();
                }
                return;
            }

            if (isToolTipShowing) {
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

            ShowLocationToolTip(toolTipCoords.X, toolTipCoords.Y, desc);
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
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

            // Update UI elements
            Savegame = null;
            StatusText = "No file loaded.";
            MapCoords = new PointF(0, 0);
            zoomLabel.Text = string.Format("{0:0%}", mapPanel.Zoom);

            mapPanel.ViewPosition = new PointF(0, 2f / 3f);
            mapPanel.Focus();
        }
    }
}
