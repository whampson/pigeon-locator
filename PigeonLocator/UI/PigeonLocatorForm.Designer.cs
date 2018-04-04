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
            this.fileMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileInformationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBlipPropertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewRemainingPigeonsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCollectedPigeonsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewLocationToolTipsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugMenuStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugExceptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugExceptionsThrowExceptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugExceptionsCauseIndexOutOfRangeExceptionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripPaddingLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.pigeonCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.fileMenuStripItem,
            this.editMenuStripItem,
            this.viewMenuStripItem,
            this.helpMenuStripItem,
            this.debugMenuStripItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1254, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileMenuStripItem
            // 
            this.fileMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenuItem,
            this.fileMenuSeparator1,
            this.fileInformationMenuItem,
            this.fileMenuSeparator2,
            this.fileExitMenuItem});
            this.fileMenuStripItem.Name = "fileMenuStripItem";
            this.fileMenuStripItem.Size = new System.Drawing.Size(64, 36);
            this.fileMenuStripItem.Text = "&File";
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
            this.fileInformationMenuItem.Enabled = false;
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
            // editMenuStripItem
            // 
            this.editMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editBlipPropertiesMenuItem});
            this.editMenuStripItem.Enabled = false;
            this.editMenuStripItem.Name = "editMenuStripItem";
            this.editMenuStripItem.Size = new System.Drawing.Size(67, 36);
            this.editMenuStripItem.Text = "&Edit";
            this.editMenuStripItem.Visible = false;
            // 
            // editBlipPropertiesMenuItem
            // 
            this.editBlipPropertiesMenuItem.Name = "editBlipPropertiesMenuItem";
            this.editBlipPropertiesMenuItem.Size = new System.Drawing.Size(283, 38);
            this.editBlipPropertiesMenuItem.Text = "Blip &Properties...";
            // 
            // viewMenuStripItem
            // 
            this.viewMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewRemainingPigeonsMenuItem,
            this.viewCollectedPigeonsMenuItem,
            this.viewMenuSeparator1,
            this.viewLocationToolTipsMenuItem});
            this.viewMenuStripItem.Name = "viewMenuStripItem";
            this.viewMenuStripItem.Size = new System.Drawing.Size(78, 36);
            this.viewMenuStripItem.Text = "&View";
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
            this.viewRemainingPigeonsMenuItem.Visible = false;
            // 
            // viewCollectedPigeonsMenuItem
            // 
            this.viewCollectedPigeonsMenuItem.CheckOnClick = true;
            this.viewCollectedPigeonsMenuItem.Enabled = false;
            this.viewCollectedPigeonsMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewCollectedPigeonsMenuItem.Name = "viewCollectedPigeonsMenuItem";
            this.viewCollectedPigeonsMenuItem.Size = new System.Drawing.Size(318, 38);
            this.viewCollectedPigeonsMenuItem.Text = "Pigeons &Collected";
            this.viewCollectedPigeonsMenuItem.Visible = false;
            // 
            // viewMenuSeparator1
            // 
            this.viewMenuSeparator1.Name = "viewMenuSeparator1";
            this.viewMenuSeparator1.Size = new System.Drawing.Size(315, 6);
            this.viewMenuSeparator1.Visible = false;
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
            // helpMenuStripItem
            // 
            this.helpMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpAboutMenuItem});
            this.helpMenuStripItem.Name = "helpMenuStripItem";
            this.helpMenuStripItem.Size = new System.Drawing.Size(77, 36);
            this.helpMenuStripItem.Text = "&Help";
            // 
            // helpAboutMenuItem
            // 
            this.helpAboutMenuItem.Name = "helpAboutMenuItem";
            this.helpAboutMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpAboutMenuItem.Size = new System.Drawing.Size(219, 38);
            this.helpAboutMenuItem.Text = "&About";
            this.helpAboutMenuItem.Click += new System.EventHandler(this.HelpAboutMenuItem_OnClick);
            // 
            // debugMenuStripItem
            // 
            this.debugMenuStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugExceptionsMenuItem});
            this.debugMenuStripItem.Enabled = false;
            this.debugMenuStripItem.Name = "debugMenuStripItem";
            this.debugMenuStripItem.Size = new System.Drawing.Size(99, 36);
            this.debugMenuStripItem.Text = "Debug";
            this.debugMenuStripItem.Visible = false;
            // 
            // debugExceptionsMenuItem
            // 
            this.debugExceptionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.debugExceptionsThrowExceptionMenuItem,
            this.debugExceptionsCauseIndexOutOfRangeExceptionMenuItem});
            this.debugExceptionsMenuItem.Name = "debugExceptionsMenuItem";
            this.debugExceptionsMenuItem.Size = new System.Drawing.Size(227, 38);
            this.debugExceptionsMenuItem.Text = "Exceptions";
            // 
            // debugExceptionsThrowExceptionMenuItem
            // 
            this.debugExceptionsThrowExceptionMenuItem.Name = "debugExceptionsThrowExceptionMenuItem";
            this.debugExceptionsThrowExceptionMenuItem.Size = new System.Drawing.Size(479, 38);
            this.debugExceptionsThrowExceptionMenuItem.Text = "Throw Test Exception";
            this.debugExceptionsThrowExceptionMenuItem.Click += new System.EventHandler(this.DebugExceptionsThrowExceptionMenuItem_OnClick);
            // 
            // debugExceptionsCauseIndexOutOfRangeExceptionMenuItem
            // 
            this.debugExceptionsCauseIndexOutOfRangeExceptionMenuItem.Name = "debugExceptionsCauseIndexOutOfRangeExceptionMenuItem";
            this.debugExceptionsCauseIndexOutOfRangeExceptionMenuItem.Size = new System.Drawing.Size(479, 38);
            this.debugExceptionsCauseIndexOutOfRangeExceptionMenuItem.Text = "Cause IndexOutOfRangeException";
            this.debugExceptionsCauseIndexOutOfRangeExceptionMenuItem.Click += new System.EventHandler(this.DebugExceptionsCauseIndexOutOfRangeExceptionMenuItem_OnClick);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusStripPaddingLabel,
            this.pigeonCountLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 852);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1254, 37);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(109, 32);
            this.statusLabel.Text = "<status>";
            // 
            // statusStripPaddingLabel
            // 
            this.statusStripPaddingLabel.Name = "statusStripPaddingLabel";
            this.statusStripPaddingLabel.Size = new System.Drawing.Size(1022, 32);
            this.statusStripPaddingLabel.Spring = true;
            // 
            // pigeonCountLabel
            // 
            this.pigeonCountLabel.Name = "pigeonCountLabel";
            this.pigeonCountLabel.Size = new System.Drawing.Size(108, 32);
            this.pigeonCountLabel.Text = "<count>";
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomTrackBar.LargeChange = 20;
            this.zoomTrackBar.Location = new System.Drawing.Point(992, 747);
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
            // mapPanel
            // 
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.CanvasSize = new System.Drawing.Size(3072, 2304);
            this.mapPanel.Cursor = System.Windows.Forms.Cursors.Cross;
            this.mapPanel.Image = global::WHampson.PigeonLocator.Properties.Resources.Map_Blue_3072x2304;
            this.mapPanel.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Margin = new System.Windows.Forms.Padding(6);
            this.mapPanel.MaximumZoom = 2F;
            this.mapPanel.MinimumZoom = 0.2F;
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(1254, 738);
            this.mapPanel.TabIndex = 6;
            this.mapPanel.ViewPosition = ((System.Drawing.PointF)(resources.GetObject("mapPanel.ViewPosition")));
            this.mapPanel.Zoom = 0.2F;
            this.mapPanel.ZoomEvent += new WHampson.PigeonLocator.ImagePanel.ZoomEventHandler(this.MapPanel_OnZoom);
            this.mapPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapPanel_OnMouseMove);
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
            this.Icon = global::WHampson.PigeonLocator.Properties.Resources.Pigeon_Bordered_Icon_240x240;
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
        private System.Windows.Forms.ToolStripMenuItem fileMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileInformationMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem helpAboutMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private ImagePanel mapPanel;
        private System.Windows.Forms.Label mapXLabel;
        private System.Windows.Forms.Label mapYLabel;
        private System.Windows.Forms.ToolStripMenuItem editMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem editBlipPropertiesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem viewRemainingPigeonsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCollectedPigeonsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLocationToolTipsMenuItem;
        private System.Windows.Forms.ToolStripSeparator viewMenuSeparator1;
        private System.Windows.Forms.Timer toolTipTimer;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.ToolStripStatusLabel statusStripPaddingLabel;
        private System.Windows.Forms.ToolStripStatusLabel pigeonCountLabel;
        private System.Windows.Forms.ToolTip locationInfoToolTip;
        private System.Windows.Forms.ToolStripMenuItem debugMenuStripItem;
        private System.Windows.Forms.ToolStripMenuItem debugExceptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugExceptionsThrowExceptionMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugExceptionsCauseIndexOutOfRangeExceptionMenuItem;
    }
}