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

using System.Collections.Generic;

namespace WHampson.PigeonLocator
{
    internal static class Pigeons
    {
        public const int NumPigeons = 200;

        public static readonly Dictionary<Vect3d, string>
            Descriptions = new Dictionary<Vect3d, string>()
            {
                // Bohan/Dukes/Broker 14
                { new Vect3d(572.84f, 1505.42f, 22.158f),
                    "South Bohan, Joliet St.\n" +
                    "On the corner of the Cleaners building rooftop." },

                // Bohan/Dukes/Broker 15
                { new Vect3d(572.98f, 1507f, 22.158f),
                    "South Bohan, Joliet St.\n" +
                    "On the edge of the Cleaners building rooftop." },

                // Bohan/Dukes/Broker 21
                { new Vect3d(701.3f, 1289.44f, 10.255f),
                    "South Bohan/Chase Point, East Borough Bridge\n" +
                    "On the walkway railing underneath a raised\n" +
                    "road (Attica Avenue)." }
            };
    }
}
