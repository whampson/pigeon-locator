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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WHampson.PigeonLocator
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Adapted from https://www.codeproject.com/Articles/26532/A-Zoomable-and-Scrollable-PictureBox.
    /// </remarks>
    public partial class ImagePanel : UserControl
    {
        private Bitmap image;
        private float zoom;
        private Size canvasSize;
        private int viewRectWidth;
        private int viewRectHeight;

        public ImagePanel()
        {
            image = null;
            zoom = 1.0f;
            canvasSize = new Size(60, 40);

            viewRectWidth = 0;
            viewRectHeight = 0;

            InitializeComponent();

            // Double-buffering options
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint,
                true);
        }

        public Bitmap Image
        {
            get { return image; }
            set {
                image = value;

                ShowScrollbar();
                UpdateScrollbarValues();
                Invalidate();
            }
        }

        public Size CanvasSize
        {
            get { return canvasSize; }
            set {
                canvasSize = value;

                ShowScrollbar();
                UpdateScrollbarValues();
                Invalidate();
            }
        }

        public float Zoom
        {
            get { return zoom; }
            set {
                if (value < 0.001f) {
                    value = 0.001f;
                }
                zoom = value;

                ShowScrollbar();
                UpdateScrollbarValues();
                hScrollBar.Value = hScrollBar.Maximum / 2;
                vScrollBar.Value = vScrollBar.Maximum / 2;
                Invalidate();
            }
        }

        public InterpolationMode InterpolationMode
        {
            get;
            set;
        }

        private void UpdateScrollbarValues()
        {
            hScrollBar.Minimum = 0;
            vScrollBar.Minimum = 0;

            if (canvasSize.Width * zoom - viewRectWidth > 0) {
                hScrollBar.Maximum = (int) (canvasSize.Width * zoom) - viewRectWidth;
            }

            //if (vScrollBar.Visible) {
            //    hScrollBar.Maximum += vScrollBar.Width;
            //}

            hScrollBar.LargeChange = hScrollBar.Maximum / 10;
            hScrollBar.SmallChange = hScrollBar.Maximum / 20;

            //hScrollBar.Maximum += hScrollBar.LargeChange;

            if (canvasSize.Height * zoom - viewRectHeight > 0) {
                vScrollBar.Maximum = (int) (canvasSize.Height * zoom) - viewRectHeight;
            }

            //if (hScrollBar.Visible) {
            //    vScrollBar.Maximum += hScrollBar.Height;
            //}

            vScrollBar.LargeChange = vScrollBar.Maximum / 10;
            vScrollBar.SmallChange = vScrollBar.Maximum / 20;

            //vScrollBar.Maximum += vScrollBar.LargeChange;
        }

        private void ShowScrollbar()
        {
            viewRectWidth = this.Width;
            viewRectHeight = this.Height;

            if (image != null) {
                canvasSize = image.Size;
            }

            if (viewRectWidth > canvasSize.Width * zoom) {
                hScrollBar.Visible = false;
                viewRectHeight = this.Height;
            } else {
                hScrollBar.Visible = true;
                viewRectHeight = this.Height - hScrollBar.Height;
            }

            if (viewRectHeight > canvasSize.Height * zoom) {
                vScrollBar.Visible = false;
                viewRectWidth = this.Width;
            } else {
                vScrollBar.Visible = true;
                viewRectWidth = this.Width - vScrollBar.Width;
            }

            hScrollBar.Location = new Point(0, this.Height - hScrollBar.Height);
            hScrollBar.Width = viewRectWidth;
            vScrollBar.Location = new Point(this.Width - vScrollBar.Width, 0);
            vScrollBar.Height = viewRectHeight;
        }

        protected override void OnLoad(EventArgs e)
        {
            ShowScrollbar();
            UpdateScrollbarValues();

            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            ShowScrollbar();
            UpdateScrollbarValues();

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (image == null) {
                return;
            }

            Rectangle srcRect;
            Rectangle destRect;
            Point pt;
            Matrix mtx;
            Graphics g;

            pt = new Point((int) (hScrollBar.Value / zoom), (int) (vScrollBar.Value / zoom));

            if (canvasSize.Width * zoom < viewRectWidth && canvasSize.Height * zoom < viewRectHeight) {
                srcRect = new Rectangle(0, 0, canvasSize.Width, canvasSize.Height);
            } else {
                srcRect = new Rectangle(pt, new Size((int) (viewRectWidth / zoom), (int) (viewRectHeight / zoom)));
            }

            destRect = new Rectangle(-srcRect.Width / 2, -srcRect.Height / 2, srcRect.Width, srcRect.Height);

            mtx = new Matrix();
            mtx.Scale(zoom, zoom);
            mtx.Translate(viewRectWidth / 2.0f, viewRectHeight / 2.0f, MatrixOrder.Append);

            g = e.Graphics;
            g.InterpolationMode = InterpolationMode;
            g.Transform = mtx;
            g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);

        }

        private void HScrollBar_OnScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        private void VScrollBar_OnScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }
    }
}
