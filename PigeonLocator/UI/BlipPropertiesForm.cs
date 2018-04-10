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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WHampson.PigeonLocator.Properties;

namespace WHampson.PigeonLocator
{
    public partial class BlipPropertiesForm : Form
    {
        public BlipPropertiesForm()
        {
            InitializeComponent();

            pictureBox1.Image = Scale(Resources.Pigeon_256x256, 0.20f);
        }

        private Bitmap Scale(Bitmap bmp, float scale)
        {
            return new Bitmap(bmp, new Size((int) (bmp.Width * scale), (int) (bmp.Height * scale)));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap img;
            int val = trackBar1.Value;
            if (val < 25) {
                img = Resources.Pigeon_64x64;
                val = 100 - (val - 25);
            } else {
                img = Resources.Pigeon_256x256;
            }

            pictureBox1.Image = Scale(img, val * 0.01f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.FullOpen = true;
            cd.ShowDialog();
        }
    }
}
