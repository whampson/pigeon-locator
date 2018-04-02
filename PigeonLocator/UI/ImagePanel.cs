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
using System.Drawing;
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
        public delegate void ZoomEventHandler(object sender, ZoomEventArgs e);

        public event ZoomEventHandler ZoomEvent;

        private Bitmap image;
        private float zoom;
        private float minZoom;
        private float maxZoom;
        private Size canvasSize;
        private int viewRectX;
        private int viewRectY;
        private int viewRectWidth;
        private int viewRectHeight;
        private bool controlPressed;
        private bool shiftPressed;

        public ImagePanel()
        {
            image = null;
            minZoom = 1.0f;
            maxZoom = 2.0f;
            zoom = 1.0f;
            canvasSize = new Size(60, 40);
            InterpolationMode = InterpolationMode.Default;

            viewRectX = 0;
            viewRectY = 0;
            viewRectWidth = 0;
            viewRectHeight = 0;
            controlPressed = false;
            shiftPressed = false;

            InitializeComponent();

            // Double-buffering options
            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint,
                true);

            MouseWheel += new MouseEventHandler(ImagePanel_OnMouseWheel);
            KeyDown += new KeyEventHandler(ImagePanel_OnKeyDown);
            KeyUp += new KeyEventHandler(ImagePanel_OnKeyUp);
        }

        protected virtual void OnZoomEvent(ZoomEventArgs e)
        {
            ZoomEvent?.Invoke(this, e);
        }

        public Bitmap Image
        {
            get { return image; }
            set {
                image = value;

                UpdateScrollbarVisibility();
                UpdateScrollbarValues();
                Invalidate();
            }
        }

        public Size CanvasSize
        {
            get { return canvasSize; }
            set {
                canvasSize = value;

                UpdateScrollbarVisibility();
                UpdateScrollbarValues();
                Invalidate();
            }
        }

        public float Zoom
        {
            get { return zoom; }
            set {
                if (value < minZoom) {
                    value = minZoom;
                }

                PointF viewPos = ViewPosition;

                zoom = value;
                UpdateScrollbarVisibility();
                UpdateScrollbarValues();

                if (float.IsNaN(viewPos.X) && !float.IsNaN(ViewPosition.X)) {
                    viewPos.X = 0.5f;
                }
                if (float.IsNaN(viewPos.Y) && !float.IsNaN(ViewPosition.Y)) {
                    viewPos.Y = 0.5f;
                }

                ViewPosition = viewPos;
                Invalidate();
            }
        }

        public float MinimumZoom
        {
            get { return minZoom; }
            set {
                if (value < 0) {
                    value = 0;
                } else if (value > maxZoom) {
                    value = maxZoom;
                }
                minZoom = value;

                if (zoom < minZoom) {
                    Zoom = minZoom;
                }
            }
        }

        public float MaximumZoom
        {
            get { return maxZoom; }
            set {
                if (value < minZoom) {
                    value = minZoom;
                }
                maxZoom = value;

                if (zoom > maxZoom) {
                    Zoom = maxZoom;
                }
            }
        }

        public InterpolationMode InterpolationMode
        {
            get;
            set;
        }

        public Rectangle ViewRectangle
        {
            get { return new Rectangle(viewRectX, viewRectY, viewRectWidth, viewRectHeight); }
        }

        public PointF ViewPosition
        {
            get {
                float xFrac = (float) hScrollBar.Value / (hScrollBar.Maximum - hScrollBar.Minimum);
                float yFrac = (float) vScrollBar.Value / (vScrollBar.Maximum - vScrollBar.Minimum);
                return new PointF(xFrac, yFrac);
            }
            set {
                if (value.X < 0) {
                    value.X = 0;
                } else if (value.X > 1) {
                    value.X = 1;
                }

                if (value.Y < 0) {
                    value.Y = 0;
                } else if (value.Y > 1) {
                    value.Y = 1;
                }

                if (!float.IsNaN(value.X)) {
                    hScrollBar.Value = (int) (value.X * (hScrollBar.Maximum - hScrollBar.Minimum));
                }
                if (!float.IsNaN(value.Y)) {
                    vScrollBar.Value = (int) (value.Y * (vScrollBar.Maximum - vScrollBar.Minimum));
                }
            }
        }

        public override Cursor Cursor
        {
            get { return base.Cursor; }
            set {
                base.Cursor = value;
                vScrollBar.Cursor = Cursors.Default;
                hScrollBar.Cursor = Cursors.Default;
            }
        }

        private void UpdateScrollbarValues()
        {
            const int LargeChangeModifier = 10;
            const int SmallChangeModifier = 20;

            int val;

            hScrollBar.Minimum = 0;
            vScrollBar.Minimum = 0;

            if (canvasSize.Width * zoom - viewRectWidth > 0) {
                hScrollBar.Maximum = (int) (canvasSize.Width * zoom) - viewRectWidth;
            }

            if (vScrollBar.Visible) {
                val = hScrollBar.Maximum - vScrollBar.Width;
                if (val < hScrollBar.Minimum) {
                    hScrollBar.Maximum = 0;
                } else {
                    hScrollBar.Maximum = val;
                }
            }

            hScrollBar.LargeChange = hScrollBar.Maximum / LargeChangeModifier;
            hScrollBar.SmallChange = hScrollBar.Maximum / SmallChangeModifier;

            hScrollBar.Maximum += hScrollBar.LargeChange;

            if (canvasSize.Height * zoom - viewRectHeight > 0) {
                vScrollBar.Maximum = (int) (canvasSize.Height * zoom) - viewRectHeight;
            }

            if (hScrollBar.Visible) {
                val = vScrollBar.Maximum - hScrollBar.Height;
                if (val < vScrollBar.Minimum) {
                    vScrollBar.Maximum = 0;
                } else {
                    vScrollBar.Maximum = val;
                }
            }

            vScrollBar.LargeChange = vScrollBar.Maximum / LargeChangeModifier;
            vScrollBar.SmallChange = vScrollBar.Maximum / SmallChangeModifier;

            vScrollBar.Maximum += vScrollBar.LargeChange;
        }

        private void UpdateScrollbarVisibility()
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

        private void AdjustScrollbar(ScrollBar scroll, int delta)
        {
            const float SpeedModifier = 5.0f;

            if (!scroll.Visible) {
                return;
            }

            int val = scroll.Value + (int) (zoom * delta / SpeedModifier);
            if (val < scroll.Minimum) {
                val = scroll.Minimum;
            } else if (val > scroll.Maximum - (scroll.LargeChange - 1)) {
                val = scroll.Maximum - (scroll.LargeChange - 1);
            }

            scroll.Value = val;
            Invalidate();
        }

        private void AdjustZoom(int delta)
        {
            const float SpeedModifier = 1250.0f;

            float val = zoom + (delta / SpeedModifier);
            if (val < MinimumZoom) {
                val = MinimumZoom;
            } else if (val > MaximumZoom) {
                val = MaximumZoom;
            }

            Zoom = val;
            OnZoomEvent(new ZoomEventArgs(val));
        }

        private void HScrollBar_OnValueChanged(object sender, EventArgs e)
        {
            viewRectX = hScrollBar.Value;
        }

        private void VScrollBar_OnValueChanged(object sender, EventArgs e)
        {
            viewRectY = vScrollBar.Value;
        }

        private void ImagePanel_OnMouseWheel(object sender, MouseEventArgs e)
        {
            ScrollBar scroll;
            if (shiftPressed) {
                scroll = hScrollBar;
            } else {
                scroll = vScrollBar;
            }

            if (controlPressed) {
                AdjustZoom(e.Delta);
            } else {
                AdjustScrollbar(scroll, -e.Delta);
            }
        }

        private void ImagePanel_OnKeyDown(object sender, KeyEventArgs e)
        {
            controlPressed = e.Control;
            shiftPressed = e.Shift;
        }

        private void ImagePanel_OnKeyUp(object sender, KeyEventArgs e)
        {
            controlPressed = e.Control;
            shiftPressed = e.Shift;
        }

        protected override void OnLoad(EventArgs e)
        {
            UpdateScrollbarVisibility();
            UpdateScrollbarValues();

            base.OnLoad(e);
        }

        protected override void OnResize(EventArgs e)
        {
            UpdateScrollbarVisibility();
            UpdateScrollbarValues();

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle srcRect;
            Rectangle destRect;
            Point pt;
            Matrix mtx;
            Graphics g;

            base.OnPaint(e);

            if (image == null) {
                return;
            }

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

        public class ZoomEventArgs : EventArgs
        {
            public ZoomEventArgs(float value)
            {
                Value = value;
            }

            public float Value { get; }
        }
    }
}
