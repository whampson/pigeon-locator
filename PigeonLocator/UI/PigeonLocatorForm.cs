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
using System.Windows.Forms;

namespace WHampson.PigeonLocator
{
    public partial class PigeonLocatorForm : Form
    {
        private const float ZoomControlScaleFactor = 100.0f;

        private IvSavegame _savegame;
        private PointF _mapCoords;
        private ToolTip locationInfoToolTip;
        private bool isLocationInfoShowing;

        public PigeonLocatorForm()
        {
            _savegame = null;
            _mapCoords = new PointF(0, 0);
            locationInfoToolTip = new ToolTip();
            isLocationInfoShowing = false;

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
            get { return _mapCoords; }
            set {
                _mapCoords = value;

                xLabel.Text = string.Format("X: {0:0.000}", value.X);
                yLabel.Text = string.Format("Y: {0:0.000}", value.Y);
            }
        }

        private string Status
        {
            get { return statusLabel.Text; }
            set { statusLabel.Text = value; }
        }

        private void LoadFile(string path)
        {
            try {
                Savegame = IvSavegame.Load(path);
                Status = string.Format("Loaded '{0}'.", Savegame.LastMissionName);
            } catch (FileNotFoundException ex) {
                string title = "File Not Found";
                string fmt = "The following file could not be found: {0}";
                ShowErrorMsgDialog(title, string.Format(fmt, path));
            } catch (InvalidDataException ex) {
                string title = "Invalid File Format";
                string msg = "Not a valid GTA IV savedata file!";
                ShowErrorMsgDialog(title, msg);
            }
        }

        private PointF GetGameWorldCoords(int mouseX, int mouseY)
        {
            const float MapCenterOffsetX = 500;
            const float MapCenterOffsetY = 750;
            const float GameWorldScaleFactor = 500f / 256f; // Each 256 pixels corresponds to 500 meters

            float worldX = ((mouseX + mapPanel.ViewRectangle.X) / mapPanel.Zoom) - (mapPanel.Image.Width / 2);
            worldX *= GameWorldScaleFactor;
            worldX += MapCenterOffsetX;

            float worldY = (-(mouseY + mapPanel.ViewRectangle.Y) / mapPanel.Zoom) + (mapPanel.Image.Height / 2);
            worldY *= GameWorldScaleFactor;
            worldY += MapCenterOffsetY;

            return new PointF(worldX, worldY);
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
                "File Version: {3}",
                Savegame.LastMissionName,
                Savegame.Timestamp.ToString("MMM d, yyyy HH:mm:ss"),
                Savegame.FileSize,
                Savegame.FileVersion);
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

        private void TrackOar_OnScroll(object sender, EventArgs e)
        {
            mapPanel.Zoom = trackBar.Value / ZoomControlScaleFactor;
        }

        private void MapPanel_OnZoom(object sender, ImagePanel.ZoomEventArgs e)
        {
            int val = (int) (e.NewValue * ZoomControlScaleFactor);
            if (val > trackBar.Maximum) {
                val = trackBar.Maximum;
            } else if (val < trackBar.Minimum) {
                val = trackBar.Minimum;
            }

            trackBar.Value = val;
        }

        private void MapPanel_OnMouseMove(object sender, MouseEventArgs e)
        {
            MapCoords = GetGameWorldCoords(e.X, e.Y);

            //if (Math.Abs(gameCoords.X - 1160) <= 10 && Math.Abs(gameCoords.Y + 570) <= 10) {
            //    if (!isLocationInfoShowing) {
            //        locationInfoToolTip.Show("Located underneath the bridge on the northernmost girder.\r\n" +
            //            "Stand on top of a car to see it.",
            //            this, e.X, e.Y, short.MaxValue - 1);
            //        isLocationInfoShowing = true;
            //    }
            //} else if (isLocationInfoShowing) {
            //    locationInfoToolTip.Hide(this);
            //    isLocationInfoShowing = false;
            //}
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Update UI elements
            Savegame = null;
            Status = "No file loaded.";
            MapCoords = new PointF(0, 0);

            mapPanel.ViewPosition = new PointF(0, 0.667f);
            mapPanel.Focus();
        }

    }
}
