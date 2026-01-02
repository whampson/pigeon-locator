#region License
/* Copyright (c) 2018-2026 Wes Hampson
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
            DukesBrokerPigeons = new Dictionary<Vector3, string>()
        {
            // Dukes/Broker 1
            { new Vector3(1414f, 1242f, 1.45f),
                "Dukes Bay Bridge\n" +
                "Underneath the bridge, on the support\n" +
                "platform." },

            // Dukes/Broker 2
            { new Vector3(909.86f, 941.18f, 11.86f),
                "Steinway\n" +
                "On the peal of a mausoleum along the\n" +
                "cemetery path." },

            // Dukes/Broker 3
            { new Vector3(1095.84f, 999.46f, 15.355f),
                "Steinway\n" +
                "Atop a play structure in the playground." },

            // Dukes/Broker 4
            { new Vector3(1252.98f, 994.53f, 15.047f),
                "Steinway\n" +
                "Atop the wall along the sidewalk, next to\n" +
                "Gantry Park parking lot." },

            // Dukes/Broker 5
            { new Vector3(1254.6f, 996.55f, 12.74f),
                "Steinway\n" +
                "On the sidewalk next to the wall that lines\n" +
                "the Gantry Park parking lot." },

            // Dukes/Broker 6
            { new Vector3(1118.95f, 914.51f, 32.21f),
                "Steinway\n" +
                "On a boulder underneath a bushy tree; it's\n" +
                "hard to see." },

            // Dukes/Broker 7
            { new Vector3(1271.25f, 895.93f, 30.775f),
                "Steinway\n" +
                "On a boulder underneath a ramp." },

            // Dukes/Broker 8
            { new Vector3(744.34f, 606.49f, 34.86f),
                "East Borough Bridge\n" +
                "On the railing of the bridge's south side\n" +
                "walkway." },

            // Dukes/Broker 9
            { new Vector3(860f, 587f, 9.195f),
                "East Island City\n" +
                "On the ground in the pedestrian underpass\n" +
                "below Franklin St." },

            // Dukes/Broker 10
            { new Vector3(893.5f, 702f, 18.972f),
                "Steinway\n" +
                "On the highest tier of the pool's diving\n" +
                "platform." },

            // Dukes/Broker 11
            { new Vector3(1169.19f, 777.56f, 37.79f),
                "Steinway\n" +
                "In the tree across the street from Blarney's\n" +
                "pub." },

            // Dukes/Broker 12
            { new Vector3(1148.74f, 686.82f, 39.8f),
                "Steinway\n" +
                "On the top corner of the wooden fence in a\n" +
                "back alley." },

            // Dukes/Broker 13
            { new Vector3(1270.12f, 772.34f, 51.673f),
                "East Island City\n" +
                "On the rafter under the train station\n" +
                "platform's roof." },

            // Dukes/Broker 14
            { new Vector3(1320f, 666f, 50.55f),
                "East Island City\n" +
                "On the corner of the NUCA Design Store\n" +
                "(with NUCA banners hanging outside)\n" +
                "building's rooftop. It's inside the roof\n" +
                "enclosure, on the floor. Throw a Molotov or\n" +
                "grenade up from the street, or drop onto\n" +
                "the roof via helicopter." },

            // Dukes/Broker 15
            { new Vector3(1609f, 852f, 14.85f),
                "Meadows Park\n" +
                "At the abandoned circus big top that's\n" +
                "missing a tent. It's inside a doorway." },

            // Dukes/Broker 16
            { new Vector3(1489.13f, 614.275f, 29.553f),
                "Meadows Park\n" +
                "On the plaque at the base of the \"Goosed\"\n" +
                "statue." },

            // Dukes/Broker 17
            { new Vector3(1886.12f, 781.04f, 22.33f),
                "Francis International Airport\n" +
                "In the middle of a wooded area, on the\n" +
                "small pump utility house's top edge." },

            // Dukes/Broker 18
            { new Vector3(1748.98f, 651.22f, 33.475f),
                "Willis\n" +
                "On top of an apartment building's green\n" +
                "entrance awning." },

            // Dukes/Broker 19
            { new Vector3(1619.84f, 443.09f, 43.247f),
                "Meadow Hills\n" +
                "On the rooftop across the street from\n" +
                "the train station, in a recessed roof door\n" +
                "entry. From the train station platform, use\n" +
                "the bench to jump and climb onto the\n" +
                "westernmost structure's roof. Then follow\n" +
                "the roof across the street to the opposite roof." },

            // Dukes/Broker 20
            { new Vector3(1823.34f, 397.18f, 32.03f),
                "Willis\n" +
                "On the raised train tracks' cross-strut,\n" +
                "near the Car Wash & Lube." },

            // Dukes/Broker 21
            { new Vector3(2303.47f, 616.15f, 16.02f),
                "Francis International Airport\n" +
                "Tucked between two air conditioning units\n" +
                "on the airport terminal roof. It's in the flat\n" +
                "area between the two curved rooftops.\n" +
                "From the airport parking lot, climb the stairs\n" +
                "up to the train station platform. Follow the\n" +
                "tracks north until they overlap the terminal\n" +
                "roof. Jump down onto the roof and follow it\n" +
                "to the air conditioning units." },

            // Dukes/Broker 22
            { new Vector3(2367.38f, 368f, 10.68f),
                "Francis International Airport\n" +
                "In the terminal support strut's circular hole.\n" +
                "From the airport parking lot, climb the stairs\n" +
                "up to the train station platform. Follow the\n" +
                "tracks south until you can get a clear shot\n" +
                "with the sniper rifle." },

            // Dukes/Broker 23
            { new Vector3(2317.83f, 336.87f, 6.49f),
                "Francis International Airport\n" +
                "On the low post just under the airport parking\n" +
                "lot's main entrance gate, across from the pay\n" +
                "booth." },

            // Dukes/Broker 24
            { new Vector3(2618.475f, 416f, 79.835f),
                "Francis International Airport\n" +
                "On the balcony railing outside the airport\n" +
                "control tower's topmost level. Target it with\n" +
                "a sniper rifle near the opening to the runway\n" +
                "tarmac." },

            // Dukes/Broker 25
            { new Vector3(948.05f, 416.73f, 17.085f),
                "BOABO\n" +
                "Behind the Creek St Diner and next to\n" +
                "the big \"Storage\" sign, about 10 feet\n" +
                "up a freeway retaining wall." },

            // Dukes/Broker 26
            { new Vector3(1175.78f, 439.37f, 32.385f),
                "Cerveza Heights\n" +
                "Atop the basketball backboard in the back-\n" +
                "alley court." },

            // Dukes/Broker 27
            { new Vector3(1382.54f, 532f, 44.908f),
                "Meadows Park\n" +
                "Atop the row house's chimney on\n" +
                "Savannah Ave, at the end of the same block\n" +
                "as Ma McReary's place. Enter the door and\n" +
                "climb the stairs to the rooftop. Then climb\n" +
                "a bit to get a clear shot." },

            // Dukes/Broker 28
            { new Vector3(1411f, 405.42f, 35.12f),
                "Cerveza Heights\n" +
                "On the roof over the stairs that lead up to\n" +
                "the Huntington St train station's first level,\n" +
                "directly behind the bank of three ticket-\n" +
                "dispensing machines." },

            // Dukes/Broker 29
            { new Vector3(652f, 242.72f, 42.615f),
                "Algonquin Bridge\n" +
                "On a road railing near the bridge's south\n" +
                "side center support beams." },

            // Dukes/Broker 30
            { new Vector3(795.66f, 130.3f, 11.112f),
                "BOABO\n" +
                "In a small, dead-end alley accessible from\n" +
                "the sidewalk by Brucie's apartment. On the\n" +
                "first-level fire escape railing." },

            // Dukes/Broker 31
            { new Vector3(1140.54f, 234.4f, 35.276f),
                "Schottler\n" +
                "Under the expressway in a tunnel. It's perched\n" +
                "atop an entryway girder inside the tunnel." },

            // Dukes/Broker 32
            { new Vector3(1303.61f, 162.83f, 33.09f),
                "Schottler\n" +
                "On a project home's stoop railing." },

            // Dukes/Broker 33
            { new Vector3(1433.78f, 206.45f, 31.575f),
                "Beechwood City\n" +
                "On a street-facing apartment's first-level\n" +
                "fire escape. It's next to the open-door\n" +
                "apartment on the end that allows roof access." },

            // Dukes/Broker 34
            { new Vector3(1602.08f, 175f, 22.48f),
                "Beechwood City\n" +
                "Just below the broken railing on the Broker-\n" +
                "Dukes Expressway. It's on a slab of concrete\n" +
                "amongst a small roadside construction project." },

            // Dukes/Broker 35
            { new Vector3(1084.14f, 38.68f, 37.493f),
                "Downtown\n" +
                "Atop a bus information shelter's roof." },

            // Dukes/Broker 36
            { new Vector3(1328.84f, -43.45f, 27.308f),
                "South Slopes\n" +
                "On the sidewalk steps' rail between the\n" +
                "Jerk 'N' Gizzard Jamaican Restaurant and the\n" +
                "Schottler train station." },

            // Dukes/Broker 37
            { new Vector3(791.1f, -233f, 21.07f),
                "East Hook\n" +
                "On top of the Broker Navy Yard entryway arch's\n" +
                "west support column. Shoot it from the short\n" +
                "rooftop behind Roman's car service building, or\n" +
                "from an upper level on the crane in the shipyard." },

            // Dukes/Broker 38
            { new Vector3(853.46f, -176.96f, 13.86f),
                "East Hook\n" +
                "On top of an air-conditioning unit on the west\n" +
                "side of the Woodfellas lumber yard building." },

            // Dukes/Broker 39
            { new Vector3(1069.46f, -170.66f, 30.052f),
                "Outlook\n" +
                "On the gazebo railing in the park." },

            // Dukes/Broker 40
            { new Vector3(1308f, -175f, 27.52f),
                "South Slopes\n" +
                "On top of a garage with rooftop railings in a\n" +
                "back alley. Toss a grenade or Molotov onto the\n" +
                "rooftop, or climb onto the roof using the dumpster\n" +
                "below the fire escape." },

            // Dukes/Broker 41
            { new Vector3(956.22f, -292.42f, 24.628f),
                "Hove Beach\n" +
                "On top of the Perestroika theater marquee." },

            // Dukes/Broker 42
            { new Vector3(1288.84f, -316.48f, 24.05f),
                "Firefly Projects\n" +
                "On a sidewalk brick wall, near the broken\n" +
                "section under the tracks and expressway." },

            // Dukes/Broker 43
            { new Vector3(724.28f, -440.55f, 2.265f),
                "Hove Beach\n" +
                "On a pier post under the Broker Bridge." },

            // Dukes/Broker 44
            { new Vector3(1162.44f, -458f, 17.195f),
                "Hove Beach\n" +
                "On top of a door that faces the small\n" +
                "courtyard park in an alley." },

            // Dukes/Broker 45
            { new Vector3(1513.12f, -420.3f, 32.502f),
                "Firefly Projects\n" +
                "On the center median on the expressway." },

            // Dukes/Broker 46
            { new Vector3(822.59f, -585.99f, 16.785f),
                "Firefly Island\n" +
                "On top of the \"Welcome to Fantastic Firefly Island\"\n" +
                "signpost on the gazebo pier." },

            // Dukes/Broker 47
            { new Vector3(1006.105f, -655f, 17.613f),
                "Firefly Island\n" +
                "On the lowest support strut directly below the\n" +
                "Liberty Eye abandoned ferris wheel's center." },

            // Dukes/Broker 48
            { new Vector3(1153.08f, -589.14f, 39.51f),
                "Hove Beach\n" +
                "On the tiptop of the abandoned Screamer\n" +
                "rollercoaster's north side rail. Shoot it from\n" +
                "Crockett Ave or the raised train tracks." },

            // Dukes/Broker 49
            { new Vector3(1312.18f, -508.95f, 14.94f),
                "Firefly Projects\n" +
                "On top of the sidewalk fence in the large apartment\n" +
                "complex's southwest corner." },

            // Dukes/Broker 50
            { new Vector3(932f, -849.12f, 0.541f),
                "Firefly Island\n" +
                "Under a large pier on the shoreline, next to a\n" +
                "support column." },

            // Dukes/Broker 51
            { new Vector3(1384.9f, -739.52f, 9.417f),
                "Beachgate\n" +
                "On a house's back porch rail." }
        };
    }
}
