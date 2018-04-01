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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WHampson.PigeonLocator.Properties;

namespace WHampson.PigeonLocator
{
    public partial class PigeonLocatorForm : Form
    {
        private IvSavegame _savegame;
        private bool ctrlPressed;

        public PigeonLocatorForm()
        {
            InitializeComponent();
            Savegame = null;
            ctrlPressed = false;
            Status = "No file loaded.";
            imagePanel1.Image = Resources.GTAIV_Map_3072x2304;
            imagePanel1.CanvasSize = imagePanel1.Size;
            imagePanel1.MinimumZoom = trackBar1.Minimum * 0.01f;
            imagePanel1.MaximumZoom = trackBar1.Maximum * 0.01f;
            imagePanel1.Zoom = imagePanel1.MinimumZoom;
            imagePanel1.ZoomEvent += new ImagePanel.ZoomEventHandler(ImagePanel_OnZoom);

            MouseWheel += new MouseEventHandler(PigeonLocatorForm_OnMouseWheel);
            KeyDown += new KeyEventHandler(PigeonLocatorForm_OnKeyDown);
            KeyUp += new KeyEventHandler(PigeonLocatorForm_OnKeyUp);
        }

        private void ImagePanel_OnZoom(object sender, ImagePanel.ZoomEventArgs e)
        {
            int val = (int) (e.Value * 100);
            if (val > trackBar1.Maximum) {
                val = trackBar1.Maximum;
            } else if (val < trackBar1.Minimum) {
                val = trackBar1.Minimum;
            }

            trackBar1.Value = val;
        }

        private void PigeonLocatorForm_OnMouseWheel(object sender, MouseEventArgs e)
        {
        }

        private void PigeonLocatorForm_OnKeyDown(object sender, KeyEventArgs e)
        {
            ctrlPressed = e.Control;
        }

        private void PigeonLocatorForm_OnKeyUp(object sender, KeyEventArgs e)
        {
            ctrlPressed = e.Control;
        }

        private IvSavegame Savegame
        {
            get { return _savegame; }
            set {
                _savegame = value;
                fileInformationMenuItem.Enabled = (_savegame != null);
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
                ShowErrorDialog(title, string.Format(fmt, path));
            } catch (InvalidDataException ex) {
                string title = "Invalid File Format";
                string msg = "Not a valid GTA IV savedata file!";
                ShowErrorDialog(title, msg);
            }
        }

        private string GetGameUserDataDirectory()
        {
            return Environment.GetEnvironmentVariable("LocalAppData")
                + @"\Rockstar Games\GTA IV";
        }

        private void ShowErrorDialog(string title, string msg)
        {
            MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowInfoDialog(string title, string msg)
        {
            MessageBox.Show(this, msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            string fileInfo = string.Format(
                "Mission Name: {0}\n" +
                "File Size: {1}\n" +
                "File Version: {2}",
                Savegame.LastMissionName,
                Savegame.FileSize,
                Savegame.FileVersion);

            ShowInfoDialog("File Information", fileInfo);
        }

        private void FileExitMenuItem_OnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpAboutMenuItem_OnClick(object sender, EventArgs e)
        {
            string aboutString = string.Format(
                "{0}\nVersion: {1}\n\n{2}",
                PigeonLocator.GetProgramName(),
                PigeonLocator.GetProgramVersion(),
                PigeonLocator.GetCopyright());
            ShowInfoDialog("About", aboutString);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            DoScroll();
        }

        private void DoScroll()
        {
            imagePanel1.Zoom = trackBar1.Value * 0.01f;
        }
    }
}
