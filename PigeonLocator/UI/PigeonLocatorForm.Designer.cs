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
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenRecentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noRecentItemsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileInformationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRemainingPigeonsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollectedPigeonsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLocationToolTipsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.increaseBlipSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseBlipSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exceptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.throwExceptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.causeIndexOutOfRangeExceptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripPaddingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pigeonCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.episodeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.platformLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.mapXLabel = new System.Windows.Forms.Label();
            this.mapYLabel = new System.Windows.Forms.Label();
            this.toolTipTimer = new System.Windows.Forms.Timer(this.components);
            this.zoomLabel = new System.Windows.Forms.Label();
            this.locationInfoToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mapPanel = new WHampson.PigeonLocator.ImagePanel();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.viewMenu,
            this.helpMenu,
            this.debugMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 1, 0, 1);
            this.menuStrip.Size = new System.Drawing.Size(840, 26);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenuItem,
            this.fileOpenRecentMenuItem,
            this.fileMenuSeparator1,
            this.fileInformationMenuItem,
            this.fileMenuSeparator2,
            this.exitMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(46, 24);
            this.fileMenu.Text = "&File";
            // 
            // fileOpenMenuItem
            // 
            this.fileOpenMenuItem.Name = "fileOpenMenuItem";
            this.fileOpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenuItem.Size = new System.Drawing.Size(233, 26);
            this.fileOpenMenuItem.Text = "&Open...";
            this.fileOpenMenuItem.Click += new System.EventHandler(this.FileOpenMenuItem_OnClick);
            // 
            // fileOpenRecentMenuItem
            // 
            this.fileOpenRecentMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noRecentItemsMenuItem});
            this.fileOpenRecentMenuItem.Name = "fileOpenRecentMenuItem";
            this.fileOpenRecentMenuItem.Size = new System.Drawing.Size(233, 26);
            this.fileOpenRecentMenuItem.Text = "Open Recent";
            // 
            // noRecentItemsMenuItem
            // 
            this.noRecentItemsMenuItem.Enabled = false;
            this.noRecentItemsMenuItem.Name = "noRecentItemsMenuItem";
            this.noRecentItemsMenuItem.Size = new System.Drawing.Size(204, 26);
            this.noRecentItemsMenuItem.Text = "(no recent items)";
            // 
            // fileMenuSeparator1
            // 
            this.fileMenuSeparator1.Name = "fileMenuSeparator1";
            this.fileMenuSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // fileInformationMenuItem
            // 
            this.fileInformationMenuItem.Enabled = false;
            this.fileInformationMenuItem.Name = "fileInformationMenuItem";
            this.fileInformationMenuItem.Size = new System.Drawing.Size(233, 26);
            this.fileInformationMenuItem.Text = "View File &Information";
            this.fileInformationMenuItem.Click += new System.EventHandler(this.FileInformationMenuItem_OnClick);
            // 
            // fileMenuSeparator2
            // 
            this.fileMenuSeparator2.Name = "fileMenuSeparator2";
            this.fileMenuSeparator2.Size = new System.Drawing.Size(230, 6);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenuItem.Size = new System.Drawing.Size(233, 26);
            this.exitMenuItem.Text = "E&xit";
            this.exitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_OnClick);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRemainingPigeonsMenuItem,
            this.viewCollectedPigeonsMenuItem,
            this.viewMenuSeparator1,
            this.viewLocationToolTipsMenuItem,
            this.viewMenuSeparator2,
            this.increaseBlipSizeMenuItem,
            this.decreaseBlipSizeMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(55, 24);
            this.viewMenu.Text = "&View";
            // 
            // viewRemainingPigeonsMenuItem
            // 
            this.viewRemainingPigeonsMenuItem.Checked = true;
            this.viewRemainingPigeonsMenuItem.CheckOnClick = true;
            this.viewRemainingPigeonsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewRemainingPigeonsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewRemainingPigeonsMenuItem.Name = "viewRemainingPigeonsMenuItem";
            this.viewRemainingPigeonsMenuItem.Size = new System.Drawing.Size(295, 26);
            this.viewRemainingPigeonsMenuItem.Text = "Pigeons &Remaining";
            this.viewRemainingPigeonsMenuItem.Click += new System.EventHandler(this.ViewRemainingPigeonsMenuItem_OnClick);
            // 
            // viewCollectedPigeonsMenuItem
            // 
            this.viewCollectedPigeonsMenuItem.CheckOnClick = true;
            this.viewCollectedPigeonsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewCollectedPigeonsMenuItem.Name = "viewCollectedPigeonsMenuItem";
            this.viewCollectedPigeonsMenuItem.Size = new System.Drawing.Size(295, 26);
            this.viewCollectedPigeonsMenuItem.Text = "Pigeons &Exterminated";
            this.viewCollectedPigeonsMenuItem.Click += new System.EventHandler(this.ViewCollectedPigeonsMenuItem_OnClick);
            // 
            // viewMenuSeparator1
            // 
            this.viewMenuSeparator1.Name = "viewMenuSeparator1";
            this.viewMenuSeparator1.Size = new System.Drawing.Size(292, 6);
            // 
            // viewLocationToolTipsMenuItem
            // 
            this.viewLocationToolTipsMenuItem.Checked = true;
            this.viewLocationToolTipsMenuItem.CheckOnClick = true;
            this.viewLocationToolTipsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewLocationToolTipsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewLocationToolTipsMenuItem.Name = "viewLocationToolTipsMenuItem";
            this.viewLocationToolTipsMenuItem.Size = new System.Drawing.Size(295, 26);
            this.viewLocationToolTipsMenuItem.Text = "Location &Tooltips";
            // 
            // viewMenuSeparator2
            // 
            this.viewMenuSeparator2.Name = "viewMenuSeparator2";
            this.viewMenuSeparator2.Size = new System.Drawing.Size(292, 6);
            // 
            // increaseBlipSizeMenuItem
            // 
            this.increaseBlipSizeMenuItem.Name = "increaseBlipSizeMenuItem";
            this.increaseBlipSizeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.increaseBlipSizeMenuItem.Size = new System.Drawing.Size(295, 26);
            this.increaseBlipSizeMenuItem.Text = "&Increase Blip Size";
            this.increaseBlipSizeMenuItem.Click += new System.EventHandler(this.IncreaseBlipSizeMenuItem_OnClick);
            // 
            // decreaseBlipSizeMenuItem
            // 
            this.decreaseBlipSizeMenuItem.Name = "decreaseBlipSizeMenuItem";
            this.decreaseBlipSizeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.decreaseBlipSizeMenuItem.Size = new System.Drawing.Size(295, 26);
            this.decreaseBlipSizeMenuItem.Text = "&Decrease Blip Size";
            this.decreaseBlipSizeMenuItem.Click += new System.EventHandler(this.DecreaseBlipSizeMenuItem_OnClick);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(55, 24);
            this.helpMenu.Text = "&Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutMenuItem.Size = new System.Drawing.Size(157, 26);
            this.aboutMenuItem.Text = "&About";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_OnClick);
            // 
            // debugMenu
            // 
            this.debugMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exceptionsMenuItem});
            this.debugMenu.Enabled = false;
            this.debugMenu.Name = "debugMenu";
            this.debugMenu.Size = new System.Drawing.Size(68, 24);
            this.debugMenu.Text = "Debug";
            this.debugMenu.Visible = false;
            // 
            // exceptionsMenuItem
            // 
            this.exceptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.throwExceptionMenuItem,
            this.causeIndexOutOfRangeExceptionMenuItem});
            this.exceptionsMenuItem.Name = "exceptionsMenuItem";
            this.exceptionsMenuItem.Size = new System.Drawing.Size(163, 26);
            this.exceptionsMenuItem.Text = "Exceptions";
            // 
            // throwExceptionMenuItem
            // 
            this.throwExceptionMenuItem.Name = "throwExceptionMenuItem";
            this.throwExceptionMenuItem.Size = new System.Drawing.Size(318, 26);
            this.throwExceptionMenuItem.Text = "Throw Test Exception";
            this.throwExceptionMenuItem.Click += new System.EventHandler(this.ThrowExceptionMenuItem_OnClick);
            // 
            // causeIndexOutOfRangeExceptionMenuItem
            // 
            this.causeIndexOutOfRangeExceptionMenuItem.Name = "causeIndexOutOfRangeExceptionMenuItem";
            this.causeIndexOutOfRangeExceptionMenuItem.Size = new System.Drawing.Size(318, 26);
            this.causeIndexOutOfRangeExceptionMenuItem.Text = "Cause IndexOutOfRangeException";
            this.causeIndexOutOfRangeExceptionMenuItem.Click += new System.EventHandler(this.CauseIndexOutOfRangeExceptionMenuItem_OnClick);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusStripPaddingLabel,
            this.episodeLabel,
            this.platformLabel,
            this.pigeonCountLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 670);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip.ShowItemToolTips = true;
            this.statusStrip.Size = new System.Drawing.Size(840, 30);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(67, 24);
            this.statusLabel.Text = "<status>";
            // 
            // statusStripPaddingLabel
            // 
            this.statusStripPaddingLabel.Name = "statusStripPaddingLabel";
            this.statusStripPaddingLabel.Size = new System.Drawing.Size(496, 24);
            this.statusStripPaddingLabel.Spring = true;
            // 
            // pigeonCountLabel
            // 
            this.pigeonCountLabel.AutoSize = false;
            this.pigeonCountLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.pigeonCountLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.pigeonCountLabel.Name = "pigeonCountLabel";
            this.pigeonCountLabel.Size = new System.Drawing.Size(75, 24);
            this.pigeonCountLabel.Text = "<count>";
            // 
            // episodeLabel
            // 
            this.episodeLabel.AutoSize = false;
            this.episodeLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.episodeLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.episodeLabel.Name = "episodeLabel";
            this.episodeLabel.Size = new System.Drawing.Size(75, 24);
            this.episodeLabel.Text = "<episode>";
            // 
            // platformLabel
            // 
            this.platformLabel.AutoSize = false;
            this.platformLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.platformLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.platformLabel.Name = "platformLabel";
            this.platformLabel.Size = new System.Drawing.Size(75, 24);
            this.platformLabel.Text = "<platform>";
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomTrackBar.LargeChange = 20;
            this.zoomTrackBar.Location = new System.Drawing.Point(607, 588);
            this.zoomTrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zoomTrackBar.Maximum = 200;
            this.zoomTrackBar.Minimum = 20;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(223, 56);
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
            this.mapXLabel.Location = new System.Drawing.Point(11, 598);
            this.mapXLabel.Name = "mapXLabel";
            this.mapXLabel.Size = new System.Drawing.Size(73, 17);
            this.mapXLabel.TabIndex = 7;
            this.mapXLabel.Text = "X: <x_val>";
            // 
            // mapYLabel
            // 
            this.mapYLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mapYLabel.AutoSize = true;
            this.mapYLabel.Location = new System.Drawing.Point(11, 618);
            this.mapYLabel.Name = "mapYLabel";
            this.mapYLabel.Size = new System.Drawing.Size(74, 17);
            this.mapYLabel.TabIndex = 8;
            this.mapYLabel.Text = "Y: <y_val>";
            // 
            // toolTipTimer
            // 
            this.toolTipTimer.Enabled = true;
            this.toolTipTimer.Interval = 500;
            this.toolTipTimer.Tick += new System.EventHandler(this.ToolTipTimer_OnTick);
            // 
            // zoomLabel
            // 
            this.zoomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomLabel.Location = new System.Drawing.Point(733, 640);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(96, 20);
            this.zoomLabel.TabIndex = 9;
            this.zoomLabel.Text = "<percent>";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mapPanel
            // 
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.CanvasSize = new System.Drawing.Size(3072, 2304);
            this.mapPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapPanel.Image = global::WHampson.PigeonLocator.Properties.Resources.Map_Blue_3072x2304;
            this.mapPanel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.mapPanel.Location = new System.Drawing.Point(0, 36);
            this.mapPanel.Margin = new System.Windows.Forms.Padding(5);
            this.mapPanel.MaximumZoom = 2F;
            this.mapPanel.MinimumZoom = 0.2F;
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(840, 545);
            this.mapPanel.TabIndex = 6;
            this.mapPanel.ViewPosition = ((System.Drawing.PointF)(resources.GetObject("mapPanel.ViewPosition")));
            this.mapPanel.Zoom = 0.2F;
            this.mapPanel.ZoomEvent += new WHampson.PigeonLocator.ImagePanel.ZoomEventHandler(this.MapPanel_OnZoom);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPanel_OnMouseMove);
            // 
            // PigeonLocatorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 700);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.mapPanel);
            this.Controls.Add(this.mapYLabel);
            this.Controls.Add(this.mapXLabel);
            this.Controls.Add(this.zoomTrackBar);
            this.Controls.Add(this.statusStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenRecentMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noRecentItemsMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileInformationMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem viewRemainingPigeonsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCollectedPigeonsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLocationToolTipsMenuItem;
        private System.Windows.Forms.ToolStripSeparator viewMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem increaseBlipSizeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseBlipSizeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugMenu;
        private System.Windows.Forms.ToolStripMenuItem exceptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem throwExceptionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem causeIndexOutOfRangeExceptionMenuItem;
        private ImagePanel mapPanel;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.Label mapXLabel;
        private System.Windows.Forms.Label mapYLabel;
        private System.Windows.Forms.ToolTip locationInfoToolTip;
        private System.Windows.Forms.Timer toolTipTimer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusStripPaddingLabel;
        private System.Windows.Forms.ToolStripStatusLabel pigeonCountLabel;
        private System.Windows.Forms.ToolStripSeparator viewMenuSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel episodeLabel;
        private System.Windows.Forms.ToolStripStatusLabel platformLabel;
    }
}