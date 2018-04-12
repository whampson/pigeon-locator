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
            LocationInfo = new Dictionary<Vect3d, string>()
            {
                /**
                 * Numbering and descriptions taken from the
                 * GTA IV Signature Series Strategy Guide by BradyGames.
                 */

                // Bohan/Dukes/Broker 1
                { new Vect3d(410.42f, 2053.21f, 7.252f),
                    "Boulevard\n" +
                    "On a discarded concrete road median near\n" +
                    "the shoreline docks." },

                // Bohan/Dukes/Broker 2
                { new Vect3d(746.96f, 2096.22f, 0.326f),
                    "Boulevard\n" +
                    "On a little sandbar under a pier." },

                // Bohan/Dukes/Broker 3
                { new Vect3d(610.22f, 1868.56f, 32.11f),
                    "Boulevard\n" +
                    "On a little rock jutting out from the north\n" +
                    "side of Valdez St. Stand near the rail and\n" +
                    "look over, or try shooting it with the\n" +
                    "sniper rifle from the nearby pond area." },

                // Bohan/Dukes/Broker 4
                { new Vect3d(909.99f, 1894.83f, 37.115f),
                    "Northern Gardens\n" +
                    "Near the rail tunnel entrance across the\n" +
                    "street from the LCPD station. It's on top of\n" +
                    "an old rail station building. Walk along the\n" +
                    "attached road wall to reach it, or snipe it\n" +
                    "from the distant, higher road." },

                // Bohan/Dukes/Broker 5
                { new Vect3d(626.59f, 1756.49f, 39.383f),
                    "Boulevard\n" +
                    "On top of the gatepost at the entrance to\n" +
                    "1665 Grand Boulevard. Shoot it from the\n" +
                    "sidewalk." },

                // Bohan/Dukes/Broker 6
                { new Vect3d(807.54f, 1805.71f, 38.67f),
                    "Boulevard\n" +
                    "On the east side of 1665 Grand Boulevard.\n" +
                    "It's on top of a brick gate section that runs\n" +
                    "along a sidewalk." },

                // Bohan/Dukes/Broker 7
                { new Vect3d(1074.9f, 1821.2f, 13.32f),
                    "Northern Gardens\n" +
                    "In the middle of the circular cul-de-sac\n" +
                    "street. It's on the knee-high brick \"Welcome\n" +
                    "to Northern Gardens\" wall." },

                // Bohan/Dukes/Broker 8
                { new Vect3d(1256.98f, 1834.21f, 10.135f),
                    "Northern Gardens\n" +
                    "In a dark alley between ghetto apartment\n" +
                    "buildings. It's on a pipe near the ground." },

                // Bohan/Dukes/Broker 9
                { new Vect3d(1507.46f, 1822.24f, 1.9f),
                    "Little Bay\n" +
                    "On a boulder jutting out of the water on the\n" +
                    "shoreline." },

                // Bohan/Dukes/Broker 10
                { new Vect3d(397.7f, 1709.24f, 18.432f),
                    "Fortside\n" +
                    "On a tall metal fence post, deep in a\n" +
                    "winding alley." },

                // Bohan/Dukes/Broker 11
                { new Vect3d(390.23f, 1656.38f, 15.4f),
                    "Fortside\n" +
                    "In an enclosed wooden work area under the\n" +
                    "train station." },

                // Bohan/Dukes/Broker 12
                { new Vect3d(482.58f, 1496.73f, 16.806f),
                    "South Bohan\n" +
                    "On top of the sidewalk girder arch." },

                // Bohan/Dukes/Broker 13
                { new Vect3d(482.58f, 1495.37f, 13.07f),
                    "South Bohan\n" +
                    "On the short wall piece, on the sidewalk\n" +
                    "girder arch's side." },

                // Bohan/Dukes/Broker 14
                { new Vect3d(572.84f, 1505.42f, 22.158f),
                    "South Bohan\n" +
                    "On the corner of the Cleaners building rooftop." },

                // Bohan/Dukes/Broker 15
                { new Vect3d(572.98f, 1507f, 22.158f),
                    "South Bohan\n" +
                    "On the edge of the Cleaners building rooftop." },

                // Bohan/Dukes/Broker 16
                { new Vect3d(968.92f, 1629f, 32.45f),
                    "Industrial\n" +
                    "On the Menala Metal building rooftop's\n" +
                    "northeast corner (above the junkyard\n" +
                    "corner). Snipe it from around the front of\n" +
                    "the junkyard." },

                // Bohan/Dukes/Broker 17
                { new Vect3d(1031.62f, 1573f, 9.125f),
                    "Industrial\n" +
                    "In the cabin window of the rusted-out ship\n" +
                    "docked at the rickety pier." },

                // Bohan/Dukes/Broker 18
                { new Vect3d(1251.81f, 1557.32f, 20.8f),
                    "Industrial\n" +
                    "On top of a streetlight attached to an\n" +
                    "abandoned building." },

                // Bohan/Dukes/Broker 19
                { new Vect3d(299.44f, 1361.46f, 8.38f),
                    "South Bohan\n" +
                    "Atop the smallest of the series of boulders\n" +
                    "that jut out into the water." },

                // Bohan/Dukes/Broker 20
                { new Vect3d(512.38f, 1246.44f, 1.655f),
                    "South Bohan\n" +
                    "Next to the girder stack near the bridge\n" +
                    "inside the large pipe section." },

                // Bohan/Dukes/Broker 21
                { new Vect3d(701.3f, 1289.44f, 10.255f),
                    "South Bohan/Chase Point\n" +
                    "On the walkway railing underneath a raised\n" +
                    "road (Attica Avenue)." },

                // Bohan/Dukes/Broker 22
                { new Vect3d(785.17f, 1402.99f, 15.52f),
                    "Chase Point\n" +
                    "On the metal railing at the building entrance\n" +
                    "by two semi trailers. Just east of your\n" +
                    "Bohan safehouse." },

                // Bohan/Dukes/Broker 23
                { new Vect3d(1414f, 1242f, 1.45f),
                    "Dukes Bay Bridge\n" +
                    "Underneath the bridge, on the support\n" +
                    "platform." },

                // Bohan/Dukes/Broker 24
                { new Vect3d(909.86f, 941.18f, 11.86f),
                    "Steinway\n" +
                    "On the peal of a mausoleum along the\n" +
                    "cemetery path." },

                // Bohan/Dukes/Broker 25
                { new Vect3d(1095.84f, 999.46f, 15.355f),
                    "Steinway\n" +
                    "Atop a play structure in the playground." },

                // Bohan/Dukes/Broker 26
                { new Vect3d(1252.98f, 994.53f, 15.047f),
                    "Steinway\n" +
                    "Atop the wall along the sidewalk, next to\n" +
                    "Gantry Park parking lot." },

                // Bohan/Dukes/Broker 27
                { new Vect3d(1254.6f, 996.55f, 12.74f),
                    "Steinway\n" +
                    "On the sidewalk next to the wall that lines\n" +
                    "the Gantry Park parking lot." },

                // Bohan/Dukes/Broker 28
                { new Vect3d(1118.95f, 914.51f, 32.21f),
                    "Steinway\n" +
                    "On a boulder underneath a bushy tree; it's\n" +
                    "hard to see." },

                // Bohan/Dukes/Broker 29
                { new Vect3d(1271.25f, 895.93f, 30.775f),
                    "Steinway\n" +
                    "On a boulder underneath a ramp." },

                // Bohan/Dukes/Broker 30
                { new Vect3d(744.34f, 606.49f, 34.86f),
                    "East Borough Bridge\n" +
                    "On the railing of the bridge's south side\n" +
                    "walkway." },

                // Bohan/Dukes/Broker 31
                { new Vect3d(860f, 587f, 9.195f),
                    "East Island City\n" +
                    "On the ground in the pedestrian underpass\n" +
                    "below Franklin St." },

                // Bohan/Dukes/Broker 32
                { new Vect3d(893.5f, 702f, 18.972f),
                    "Steinway\n" +
                    "On the highest tier of the pool's diving\n" +
                    "platform." },

                // Bohan/Dukes/Broker 33
                { new Vect3d(1169.19f, 777.56f, 37.79f),
                    "Steinway\n" +
                    "In the tree across the street from Blarney's\n" +
                    "pub." },

                // Bohan/Dukes/Broker 34
                { new Vect3d(1148.74f, 686.82f, 39.8f),
                    "Steinway\n" +
                    "On the top corner of the wooden fence in a\n" +
                    "back alley." },

                // Bohan/Dukes/Broker 35
                { new Vect3d(1270.12f, 772.34f, 51.673f),
                    "East Island City\n" +
                    "On the rafter under the train station\n" +
                    "platform's roof." },

                // Bohan/Dukes/Broker 36
                { new Vect3d(1320f, 666f, 50.55f),
                    "East Island City\n" +
                    "On the corner of the NUCA Design Store\n" +
                    "(with NUCA banners hanging outside)\n" +
                    "building's rooftop. It's inside the roof\n" +
                    "enclosure, on the floor. Throw a Molotov or\n" +
                    "grenade up from the street, or drop onto\n" +
                    "the roof via helicopter." },

                // Bohan/Dukes/Broker 37
                { new Vect3d(1609f, 852f, 14.85f),
                    "Meadows Park\n" +
                    "At the abandoned circus big top that's\n" +
                    "missing a tent. It's inside a doorway." },

                // Bohan/Dukes/Broker 38
                { new Vect3d(1489.13f, 614.275f, 29.553f),
                    "Meadows Park\n" +
                    "On the plaque at the base of the \"Goosed\"\n" +
                    "statue." },

                // Bohan/Dukes/Broker 39
                { new Vect3d(1886.12f, 781.04f, 22.33f),
                    "Francis International Airport\n" +
                    "In the middle of a wooded area, on the\n" +
                    "small pump utility house's top edge." },

                // Bohan/Dukes/Broker 40
                { new Vect3d(1748.98f, 651.22f, 33.475f),
                    "Willis\n" +
                    "On top of an apartment building's green\n" +
                    "entrance awning." },

                // Bohan/Dukes/Broker 41
                { new Vect3d(1619.84f, 443.09f, 43.247f),
                    "Meadow Hills\n" +
                    "On the rooftop across the street from\n" +
                    "the train station, in a recessed roof door\n" +
                    "entry. From the train station platform, use\n" +
                    "the bench to jump and climb onto the\n" +
                    "westernmost structure's roof. Then follow\n" +
                    "the roof across the street to the opposite roof." },

                // Bohan/Dukes/Broker 42
                { new Vect3d(1823.34f, 397.18f, 32.03f),
                    "Willis\n" +
                    "On the raised train tracks' cross-strut,\n" +
                    "near the Car Wash & Lube." },

                // Bohan/Dukes/Broker 43
                { new Vect3d(2303.47f, 616.15f, 16.02f),
                    "Francis International Airport\n" +
                    "Tucked between two air conditioning units\n" +
                    "on the airport terminal roof. It's in the flat\n" +
                    "area between the two curved rooftops.\n" +
                    "From the airport parking lot, climb the stairs\n" +
                    "up to the train station platform. Follow the\n" +
                    "tracks north until they overlap the terminal\n" +
                    "roof. Jump down onto the roof and follow it\n" +
                    "to the air conditioning units." },

                // Bohan/Dukes/Broker 44
                { new Vect3d(2367.38f, 368f, 10.68f),
                    "Francis International Airport\n" +
                    "In the terminal support strut's circular hole.\n" +
                    "From the airport parking lot, climb the stairs\n" +
                    "up to the train station platform. Follow the\n" +
                    "tracks south until you can get a clear shot\n" +
                    "with the sniper rifle." },

                // Bohan/Dukes/Broker 45
                { new Vect3d(2317.83f, 336.87f, 6.49f),
                    "Francis International Airport\n" +
                    "On the low post just under the airport parking\n" +
                    "lot's main entrance gate, across from the pay\n" +
                    "booth." },

                // Bohan/Dukes/Broker 46
                { new Vect3d(2618.475f, 416f, 79.835f),
                    "Francis International Airport\n" +
                    "On the balcony railing outside the airport\n" +
                    "control tower's topmost level. Target it with\n" +
                    "a sniper rifle near the opening to the runway\n" +
                    "tarmac." },

                // Bohan/Dukes/Broker 47
                { new Vect3d(948.05f, 416.73f, 17.085f),
                    "BOABO\n" +
                    "Behind the Creek St Diner and next to\n" +
                    "the big \"Storage\" sign, about 10 feet\n" +
                    "up a freeway retaining wall." },

                // Bohan/Dukes/Broker 48
                { new Vect3d(1175.78f, 439.37f, 32.385f),
                    "Cerveza Heights\n" +
                    "Atop the basketball backboard in the back-\n" +
                    "alley court." },

                // Bohan/Dukes/Broker 49
                { new Vect3d(1382.54f, 532f, 44.908f),
                    "Meadows Park\n" +
                    "Atop the row house's chimney on\n" +
                    "Savannah Ave, at the end of the same block\n" +
                    "as Ma McReary's place. Enter the door and\n" +
                    "climb the stairs to the rooftop. Then climb\n" +
                    "a bit to get a clear shot." },

                // Bohan/Dukes/Broker 50
                { new Vect3d(1411f, 405.42f, 35.12f),
                    "Cerveza Heights\n" +
                    "On the roof over the stairs that lead up to\n" +
                    "the Huntington St train station's first level,\n" +
                    "directly behind the bank of three ticket-\n" +
                    "dispensing machines." },
            };
    }
}
