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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PigeonLocatorForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileInformationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBlipPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRemainingPigeonsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollectedPigeonsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLocationToolTipsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.mapXLabel = new System.Windows.Forms.Label();
            this.mapYLabel = new System.Windows.Forms.Label();
            this.toolTipTimer = new System.Windows.Forms.Timer(this.components);
            this.mapPanel = new WHampson.PigeonLocator.ImagePanel();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
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
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenuItem.Size = new System.Drawing.Size(341, 38);
            this.fileOpenMenuItem.Text = "&Open...";
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
            this.fileInformationMenuItem.Text = "View File &Information";
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
            this.fileExitMenuItem.Text = "E&xit";
            this.fileExitMenuItem.Click += new System.EventHandler(this.FileExitMenuItem_OnClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editBlipPropertiesMenuItem});
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 36);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // editBlipPropertiesMenuItem
            // 
            this.editBlipPropertiesMenuItem.Name = "editBlipPropertiesMenuItem";
            this.editBlipPropertiesMenuItem.Size = new System.Drawing.Size(283, 38);
            this.editBlipPropertiesMenuItem.Text = "Blip &Properties...";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRemainingPigeonsMenuItem,
            this.viewCollectedPigeonsMenuItem,
            this.viewMenuSeparator1,
            this.viewLocationToolTipsMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(78, 36);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // viewRemainingPigeonsMenuItem
            // 
            this.viewRemainingPigeonsMenuItem.Checked = true;
            this.viewRemainingPigeonsMenuItem.CheckOnClick = true;
            this.viewRemainingPigeonsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewRemainingPigeonsMenuItem.Enabled = false;
            this.viewRemainingPigeonsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewRemainingPigeonsMenuItem.Name = "viewRemainingPigeonsMenuItem";
            this.viewRemainingPigeonsMenuItem.Size = new System.Drawing.Size(318, 38);
            this.viewRemainingPigeonsMenuItem.Text = "Pigeons &Remaining";
            // 
            // viewCollectedPigeonsMenuItem
            // 
            this.viewCollectedPigeonsMenuItem.CheckOnClick = true;
            this.viewCollectedPigeonsMenuItem.Enabled = false;
            this.viewCollectedPigeonsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewCollectedPigeonsMenuItem.Name = "viewCollectedPigeonsMenuItem";
            this.viewCollectedPigeonsMenuItem.Size = new System.Drawing.Size(318, 38);
            this.viewCollectedPigeonsMenuItem.Text = "Pigeons &Collected";
            // 
            // viewMenuSeparator1
            // 
            this.viewMenuSeparator1.Name = "viewMenuSeparator1";
            this.viewMenuSeparator1.Size = new System.Drawing.Size(315, 6);
            // 
            // viewLocationToolTipsMenuItem
            // 
            this.viewLocationToolTipsMenuItem.Checked = true;
            this.viewLocationToolTipsMenuItem.CheckOnClick = true;
            this.viewLocationToolTipsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewLocationToolTipsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewLocationToolTipsMenuItem.Name = "viewLocationToolTipsMenuItem";
            this.viewLocationToolTipsMenuItem.Size = new System.Drawing.Size(318, 38);
            this.viewLocationToolTipsMenuItem.Text = "&Location Tooltips";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(77, 36);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            this.helpAboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpAboutMenuItem.Size = new System.Drawing.Size(219, 38);
            this.helpAboutMenuItem.Text = "&About";
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
            // zoomTrackBar
            // 
            this.zoomTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomTrackBar.LargeChange = 20;
            this.zoomTrackBar.Location = new System.Drawing.Point(992, 759);
            this.zoomTrackBar.Maximum = 200;
            this.zoomTrackBar.Minimum = 20;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(250, 90);
            this.zoomTrackBar.SmallChange = 10;
            this.zoomTrackBar.TabIndex = 5;
            this.zoomTrackBar.TabStop = false;
            this.zoomTrackBar.TickFrequency = 20;
            this.zoomTrackBar.Value = 20;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.ZoomTrackBar_OnScroll);
            this.zoomTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZoomTrackBar_OnMouseUp);
            // 
            // mapXLabel
            // 
            this.mapXLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mapXLabel.AutoSize = true;
            this.mapXLabel.Location = new System.Drawing.Point(12, 759);
            this.mapXLabel.Name = "mapXLabel";
            this.mapXLabel.Size = new System.Drawing.Size(113, 25);
            this.mapXLabel.TabIndex = 7;
            this.mapXLabel.Text = "X: <x_val>";
            // 
            // mapYLabel
            // 
            this.mapYLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mapYLabel.AutoSize = true;
            this.mapYLabel.Location = new System.Drawing.Point(12, 784);
            this.mapYLabel.Name = "mapYLabel";
            this.mapYLabel.Size = new System.Drawing.Size(114, 25);
            this.mapYLabel.TabIndex = 8;
            this.mapYLabel.Text = "Y: <y_val>";
            // 
            // toolTipTimer
            // 
            this.toolTipTimer.Enabled = true;
            this.toolTipTimer.Interval = 500;
            this.toolTipTimer.Tick += new System.EventHandler(this.ToolTipTimer_OnTick);
            // 
            // mapPanel
            // 
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.CanvasSize = new System.Drawing.Size(3072, 2304);
            this.mapPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapPanel.Image = global::WHampson.PigeonLocator.Properties.Resources.GTAIV_Map_3072x2304;
            this.mapPanel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Margin = new System.Windows.Forms.Padding(6);
            this.mapPanel.MaximumZoom = 2F;
            this.mapPanel.MinimumZoom = 0.2F;
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(1254, 750);
            this.mapPanel.TabIndex = 6;
            this.mapPanel.ViewPosition = ((System.Drawing.PointF)(resources.GetObject("mapPanel.ViewPosition")));
            this.mapPanel.Zoom = 0.2F;
            this.mapPanel.ZoomEvent += new WHampson.PigeonLocator.ImagePanel.ZoomEventHandler(this.MapPanel_OnZoom);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPanel_OnMouseMove);
            // 
            // zoomLabel
            // 
            this.zoomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomLabel.Location = new System.Drawing.Point(1134, 812);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(108, 25);
            this.zoomLabel.TabIndex = 9;
            this.zoomLabel.Text = "<percent>";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PigeonLocatorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 889);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.mapYLabel);
            this.Controls.Add(this.mapXLabel);
            this.Controls.Add(this.zoomTrackBar);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.Icon = global::WHampson.PigeonLocator.Properties.Resources.GTAIV_PigeonIcon_240x240;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "PigeonLocatorForm";
            this.Text = "GTA IV Pigeon Locator";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.OnDragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
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
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private ImagePanel mapPanel;
        private System.Windows.Forms.Label mapXLabel;
        private System.Windows.Forms.Label mapYLabel;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBlipPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewRemainingPigeonsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCollectedPigeonsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLocationToolTipsMenuItem;
        private System.Windows.Forms.ToolStripSeparator viewMenuSeparator1;
        private System.Windows.Forms.Timer toolTipTimer;
        private System.Windows.Forms.Label zoomLabel;
    }
}