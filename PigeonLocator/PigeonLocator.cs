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
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WHampson.PigeonLocator
{
    class PigeonLocator
    {
        static void Main(string[] args)
        {
            string testFile = Environment.GetEnvironmentVariable("LocalAppData")
                + @"\Rockstar Games\GTA IV\savegames\user_1000100010001000\SGTA407";

            string testFile2 = @"C:\Users\Wes\Documents\GTA3 User Files\GTA3SF1.b";

            IvSavegame savegame = IvSavegame.Load(testFile);
            Console.WriteLine(savegame.ToString());

            Vect3d[] locs = savegame.GetRemainingPigeonLocations();
            foreach (Vect3d loc in locs)
            {
                Console.WriteLine(loc);
            }

            Console.ReadLine();
        }
    }
}
