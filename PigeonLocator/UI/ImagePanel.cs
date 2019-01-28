#region License
/* Copyright (c) 2018-2019 W. Hampson
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
    /// Implements a zoomable and pannable panel for viewing images.
    /// </summary>
    /// <remarks>
    /// Adapted from https://www.codeproject.com/Articles/26532/A-Zoomable-and-Scrollable-PictureBox.
    /// </remarks>
    internal partial class ImagePanel : UserControl
    {
        /// <summary>
        /// Represents the method that handles the Zoom event of an <see cref="ImagePanel"/>.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">A <see cref="ZoomEventArgs"/> that contains the event data.</param>
        public delegate void ZoomEventHandler(object sender, ZoomEventArgs e);

        /// <summary>
        /// Represents the event that occurs when the image is zoomed in or out.
        /// </summary>
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

        /// <summary>
        /// Instantiates a new <see cref="ImagePanel"/> object.
        /// </summary>
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
        }

        /// <summary>
        /// Gets or set the displayed image.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the maximum view boundaries.
        /// </summary>
        /// <remarks>
        /// When an image is loaded, this property is set to the image dimensions.
        /// </remarks>
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

        /// <summary>
        /// Gets or sets the current image scale factor.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the minimum image scale factor.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the maximum image scale factor.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the image graphics interpolation mode.
        /// </summary>
        public InterpolationMode InterpolationMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the viewing area dimensions and position.
        /// </summary>
        public Rectangle ViewRectangle
        {
            get { return new Rectangle(viewRectX, viewRectY, viewRectWidth, viewRectHeight); }
        }

        /// <summary>
        /// Gets or sets the current scroll position.
        /// The position is a fraction between 0 and 1.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the cursor that is displayed when the mouse pointer is over the control.
        /// </summary>
        public override Cursor Cursor
        {
            // Reimplementing to keep default cursor over scollbars.
            get { return base.Cursor; }
            set {
                base.Cursor = value;

                Cursor scrollCursor = (Parent != null)
                    ? Parent.Cursor
                    : Cursors.Default;
                vScrollBar.Cursor = scrollCursor;
                hScrollBar.Cursor = scrollCursor;
            }
        }

        /// <summary>
        /// Updates the scrollbar min, max, and delta values based on
        /// the current viewing area and scale factor.
        /// </summary>
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

        /// <summary>
        /// Updates the visibility of the scrollbars based on whether or not they are needed.
        /// </summary>
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

        /// <summary>
        /// Sets the value of a scrollbar and updates the viewing area.
        /// </summary>
        /// <param name="scroll">The <see cref="ScrollBar"/> to modify.</param>
        /// <param name="delta">The amount to scroll.</param>
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

        /// <summary>
        /// Increments the current zoom value.
        /// </summary>
        /// <param name="delta">The amount to adjust the zoom by.</param>
        /// <remarks>
        /// Triggers a <see cref="ZoomEvent"/>.
        /// </remarks>
        private void AdjustZoom(int delta)
        {
            const float SpeedModifier = 1250.0f;

            float oldVal, newVal;

            newVal = zoom + (delta / SpeedModifier);
            if (newVal < MinimumZoom) {
                newVal = MinimumZoom;
            } else if (newVal > MaximumZoom) {
                newVal = MaximumZoom;
            }

            oldVal = Zoom;
            Zoom = newVal;
            ZoomEvent?.Invoke(this, new ZoomEventArgs(oldVal, newVal));
        }

        private void HScrollBar_OnValueChanged(object sender, EventArgs e)
        {
            viewRectX = hScrollBar.Value;
        }

        private void VScrollBar_OnValueChanged(object sender, EventArgs e)
        {
            viewRectY = vScrollBar.Value;
        }

        private void HScrollBar_OnScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        private void VScrollBar_OnScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
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

        /// <summary>
        /// Provides data for the Zoom event.
        /// </summary>
        public class ZoomEventArgs : EventArgs
        {
            /// <summary>
            /// Creates a new <see cref="ZoomEventArgs"/> instance.
            /// </summary>
            /// <param name="oldValue">The old zoom value.</param>
            /// <param name="newValue">The new zoom value.</param>
            public ZoomEventArgs(float oldValue, float newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }

            /// <summary>
            /// Gets the old zoom value.
            /// </summary>
            public float OldValue { get; }

            /// <summary>
            /// Gets the new zoom value.
            /// </summary>
            public float NewValue { get; }
        }
    }
}
