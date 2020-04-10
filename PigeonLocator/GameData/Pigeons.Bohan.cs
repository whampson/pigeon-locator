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

using System.Collections.Generic;
using System.Numerics;

namespace WHampson.PigeonLocator.GameData
{
    internal static partial class Pigeons
    {
        public static readonly Dictionary<Vector3, string>
            BohanPigeons = new Dictionary<Vector3, string>()
        {
            // Bohan 1
            { new Vector3(410.42f, 2053.21f, 7.252f),
                "Boulevard\n" +
                "On a discarded concrete road median near\n" +
                "the shoreline docks." },

            // Bohan 2
            { new Vector3(746.96f, 2096.22f, 0.326f),
                "Boulevard\n" +
                "On a little sandbar under a pier." },

            // Bohan 3
            { new Vector3(610.22f, 1868.56f, 32.11f),
                "Boulevard\n" +
                "On a little rock jutting out from the north\n" +
                "side of Valdez St. Stand near the rail and\n" +
                "look over, or try shooting it with the\n" +
                "sniper rifle from the nearby pond area." },

            // Bohan 4
            { new Vector3(909.99f, 1894.83f, 37.115f),
                "Northern Gardens\n" +
                "Near the rail tunnel entrance across the\n" +
                "street from the LCPD station. It's on top of\n" +
                "an old rail station building. Walk along the\n" +
                "attached road wall to reach it, or snipe it\n" +
                "from the distant, higher road." },

            // Bohan 5
            { new Vector3(626.59f, 1756.49f, 39.383f),
                "Boulevard\n" +
                "On top of the gatepost at the entrance to\n" +
                "1665 Grand Boulevard. Shoot it from the\n" +
                "sidewalk." },

            // Bohan 6
            { new Vector3(807.54f, 1805.71f, 38.67f),
                "Boulevard\n" +
                "On the east side of 1665 Grand Boulevard.\n" +
                "It's on top of a brick gate section that runs\n" +
                "along a sidewalk." },

            // Bohan 7
            { new Vector3(1074.9f, 1821.2f, 13.32f),
                "Northern Gardens\n" +
                "In the middle of the circular cul-de-sac\n" +
                "street. It's on the knee-high brick \"Welcome\n" +
                "to Northern Gardens\" wall." },

            // Bohan 8
            { new Vector3(1256.98f, 1834.21f, 10.135f),
                "Northern Gardens\n" +
                "In a dark alley between ghetto apartment\n" +
                "buildings. It's on a pipe near the ground." },

            // Bohan 9
            { new Vector3(1507.46f, 1822.24f, 1.9f),
                "Little Bay\n" +
                "On a boulder jutting out of the water on the\n" +
                "shoreline." },

            // Bohan 10
            { new Vector3(397.7f, 1709.24f, 18.432f),
                "Fortside\n" +
                "On a tall metal fence post, deep in a\n" +
                "winding alley." },

            // Bohan 11
            { new Vector3(390.23f, 1656.38f, 15.4f),
                "Fortside\n" +
                "In an enclosed wooden work area under the\n" +
                "train station." },

            // Bohan 12
            { new Vector3(482.58f, 1496.73f, 16.806f),
                "South Bohan\n" +
                "On top of the sidewalk girder arch." },

            // Bohan 13
            { new Vector3(482.58f, 1495.37f, 13.07f),
                "South Bohan\n" +
                "On the short wall piece, on the sidewalk\n" +
                "girder arch's side." },

            // Bohan 14
            { new Vector3(572.84f, 1505.42f, 22.158f),
                "South Bohan\n" +
                "On the corner of the Cleaners building rooftop." },

            // Bohan 15
            { new Vector3(572.98f, 1507f, 22.158f),
                "South Bohan\n" +
                "On the edge of the Cleaners building rooftop." },

            // Bohan 16
            { new Vector3(968.92f, 1629f, 32.45f),
                "Industrial\n" +
                "On the Menala Metal building rooftop's\n" +
                "northeast corner (above the junkyard\n" +
                "corner). Snipe it from around the front of\n" +
                "the junkyard." },

            // Bohan 17
            { new Vector3(1031.62f, 1573f, 9.125f),
                "Industrial\n" +
                "In the cabin window of the rusted-out ship\n" +
                "docked at the rickety pier." },

            // Bohan 18
            { new Vector3(1251.81f, 1557.32f, 20.8f),
                "Industrial\n" +
                "On top of a streetlight attached to an\n" +
                "abandoned building." },

            // Bohan 19
            { new Vector3(299.44f, 1361.46f, 8.38f),
                "South Bohan\n" +
                "Atop the smallest of the series of boulders\n" +
                "that jut out into the water." },

            // Bohan 20
            { new Vector3(512.38f, 1246.44f, 1.655f),
                "South Bohan\n" +
                "Next to the girder stack near the bridge\n" +
                "inside the large pipe section." },

            // Bohan 21
            { new Vector3(701.3f, 1289.44f, 10.255f),
                "South Bohan/Chase Point\n" +
                "On the walkway railing underneath a raised\n" +
                "road (Attica Avenue)." },

            // Bohan 22
            { new Vector3(785.17f, 1402.99f, 15.52f),
                "Chase Point\n" +
                "On the metal railing at the building entrance\n" +
                "by two semi trailers. Just east of your\n" +
                "Bohan safehouse." }
        };
    }
}
