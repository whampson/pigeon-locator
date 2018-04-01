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

namespace WHampson.PigeonLocator
{
    partial class PigeonLocatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileInformationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.imagePanel1 = new WHampson.PigeonLocator.ImagePanel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1254, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenuItem,
            this.fileMenuSeparator1,
            this.fileInformationMenuItem,
            this.fileMenuSeparator2,
            this.fileExitMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenuItem.Size = new System.Drawing.Size(341, 38);
            this.fileOpenMenuItem.Text = "Open...";
            this.fileOpenMenuItem.Click += new System.EventHandler(this.FileOpenMenuItem_OnClick);
            // 
            // fileMenuSeparator1
            // 
            this.fileMenuSeparator1.Name = "fileMenuSeparator1";
            this.fileMenuSeparator1.Size = new System.Drawing.Size(338, 6);
            // 
            // fileInformationMenuItem
            // 
            this.fileInformationMenuItem.Name = "fileInformationMenuItem";
            this.fileInformationMenuItem.Size = new System.Drawing.Size(341, 38);
            this.fileInformationMenuItem.Text = "View File Information";
            this.fileInformationMenuItem.Click += new System.EventHandler(this.FileInformationMenuItem_OnClick);
            // 
            // fileMenuSeparator2
            // 
            this.fileMenuSeparator2.Name = "fileMenuSeparator2";
            this.fileMenuSeparator2.Size = new System.Drawing.Size(338, 6);
            // 
            // fileExitMenuItem
            // 
            this.fileExitMenuItem.Name = "fileExitMenuItem";
            this.fileExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.fileExitMenuItem.Size = new System.Drawing.Size(341, 38);
            this.fileExitMenuItem.Text = "Exit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.FileExitMenuItem_OnClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            this.helpAboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpAboutMenuItem.Size = new System.Drawing.Size(219, 38);
            this.helpAboutMenuItem.Text = "About";
            this.helpAboutMenuItem.Click += new System.EventHandler(this.HelpAboutMenuItem_OnClick);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 852);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1254, 37);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(109, 32);
            this.statusLabel.Text = "<status>";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(992, 759);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Minimum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(250, 90);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 5;
            this.trackBar1.TabStop = false;
            this.trackBar1.TickFrequency = 20;
            this.trackBar1.Value = 20;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // imagePanel1
            // 
            this.imagePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel1.CanvasSize = new System.Drawing.Size(60, 40);
            this.imagePanel1.Image = null;
            this.imagePanel1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.imagePanel1.Location = new System.Drawing.Point(0, 43);
            this.imagePanel1.Margin = new System.Windows.Forms.Padding(6);
            this.imagePanel1.Name = "imagePanel1";
            this.imagePanel1.Size = new System.Drawing.Size(1254, 710);
            this.imagePanel1.TabIndex = 6;
            this.imagePanel1.Zoom = 1F;
            // 
            // PigeonLocatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 889);
            this.Controls.Add(this.imagePanel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PigeonLocatorForm";
            this.Text = "GTA IV Pigeon Locator";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileInformationMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TrackBar trackBar1;
        private ImagePanel imagePanel1;
    }
}