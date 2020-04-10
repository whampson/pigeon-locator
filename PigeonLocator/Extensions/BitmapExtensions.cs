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

using System;
using System.Collections.Generic;
using System.Drawing;

namespace WHampson.PigeonLocator.Extensions
{
    /// <summary>
    /// Extensions to the <see cref="Bitmap"/> class.
    /// </summary>
    internal static class BitmapExtensions
    {
        /// <summary>
        /// Fills a contiguous region of pixels with a new color.
        /// </summary>
        /// <param name="bmp">The image to perform the fill on.</param>
        /// <param name="start">The starting pixel location.</param>
        /// <param name="replacement">The color to fill with.</param>
        public static void FloodFill(this Bitmap bmp, Point start, Color replacement)
        {
            if (bmp == null) {
                throw new ArgumentNullException(nameof(bmp));
            }

            if (start.X < 0 || start.X >= bmp.Width || start.Y < 0 || start.Y >= bmp.Height) {
                throw new ArgumentOutOfRangeException(
                    "Pixel coordinate is out of range.", nameof(start));
            }

            if (replacement == null) {
                throw new ArgumentNullException(nameof(replacement));
            }

            Color target = bmp.GetPixel(start.X, start.Y);
            Queue<Point> q = new Queue<Point>();
            q.Enqueue(start);

            while (q.Count > 0) {
                Point p1 = q.Dequeue();
                Point p2 = new Point(p1.X + 1, p1.Y);

                if (!ColorEquals(bmp.GetPixel(p1.X, p1.Y), target)) {
                    continue;
                }

                while (p1.X >= 0 && ColorEquals(bmp.GetPixel(p1.X, p1.Y), target)) {
                    bmp.SetPixel(p1.X, p1.Y, replacement);
                    if (p1.Y > 0 && ColorEquals(bmp.GetPixel(p1.X, p1.Y - 1), target)) {
                        q.Enqueue(new Point(p1.X, p1.Y - 1));
                    }
                    if (p1.Y < bmp.Height - 1 && ColorEquals(bmp.GetPixel(p1.X, p1.Y + 1), target)) {
                        q.Enqueue(new Point(p1.X, p1.Y + 1));
                    }
                    p1.X--;
                }

                while (p2.X <= bmp.Width - 1 && ColorEquals(bmp.GetPixel(p2.X, p2.Y), target)) {
                    bmp.SetPixel(p2.X, p2.Y, replacement);
                    if ((p2.Y > 0) && ColorEquals(bmp.GetPixel(p2.X, p2.Y - 1), target)) {
                        q.Enqueue(new Point(p2.X, p2.Y - 1));
                    }
                    if (p2.Y < bmp.Height - 1 && ColorEquals(bmp.GetPixel(p2.X, p2.Y + 1), target)) {
                        q.Enqueue(new Point(p2.X, p2.Y + 1));
                    }
                    p2.X++;
                }
            }
        }

        private static bool ColorEquals(Color a, Color b)
        {
            int rgb1 = a.ToArgb() & 0x00FFFFFF;
            int rgb2 = b.ToArgb() & 0x00FFFFFF;

            return rgb1 == rgb2;
        }
    }
}
