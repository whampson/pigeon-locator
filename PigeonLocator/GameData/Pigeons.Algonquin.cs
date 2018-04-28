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
using WHampson.PigeonLocator.IvGameData;

namespace WHampson.PigeonLocator.GameData
{
    internal static partial class Pigeons
    {
        public static readonly Dictionary<Vect3d, string>
            AlgonquinPigeons = new Dictionary<Vect3d, string>()
        {
                // Algonquin 1
                { new Vect3d(-249.48f, 1771.16f, 1.96f),
                    "Northwood\n" +
                    "Inside a metal container in a barge." },

                // Algonquin 2
                { new Vect3d(-427.26f, 1551.23f, 21.98f),
                    "Northwood\n" +
                    "Atop a low ledge on the side of an\n" +
                    "apartment building." },

                // Algonquin 3
                { new Vect3d(-319.93f, 1509.29f, 19.063f),
                    "Northwood\n" +
                    "On a small concrete barricade post at the\n" +
                    "alley entrance between a corner store with\n" +
                    "apartments above it and an older style\n" +
                    "apartment building." },

                // Algonquin 4
                { new Vect3d(-205.94f, 1509.28f, 26.808f),
                    "Northwood\n" +
                    "Perched on a dark brick on the corner of a\n" +
                    "building with a destroyed wall." },

                // Algonquin 5
                { new Vect3d(-9.76f, 1497.03f, 18.867f),
                    "Northwood\n" +
                    "On the north side patio railing of the large,\n" +
                    "gray and olive apartment building." },

                // Algonquin 6
                { new Vect3d(-609.62f, 1397.3f, 8.37f),
                    "North Holland\n" +
                    "On the bulkhead wall near a construction\n" +
                    "hole." },

                // Algonquin 7
                { new Vect3d(-441.32f, 1288f, 42.015f),
                    "North Holland\n" +
                    "On the hospital's sixth floor balcony railing.\n" +
                    "Take the stairs from inside the hospital's carport\n" +
                    "to the sixth floor rooftop. The Pigeon is on the\n" +
                    "west end of the building." },

                // Algonquin 8
                { new Vect3d(-414.68f, 1308f, 93.905f),
                    "North Holland\n" +
                    "On top of an air conditioning unit on the hospital's\n" +
                    "rooftop. Take the stairs from inside the hospital's\n" +
                    "carport to the rooftop. Use the ladder to climb to the\n" +
                    "top of the air conditioning unit." },

                // Algonquin 9
                { new Vect3d(-369f, 1279f, 23.255f),
                    "North Holland\n" +
                    "On the median wall that separates the road from the\n" +
                    "train tunnel on the corner of Frankfort Ave and\n" +
                    "Uranium St." },

                // Algonquin 10
                { new Vect3d(-207.06f, 1233.33f, 22.04f),
                    "East Holland\n" +
                    "On the corner of a balcony wall behind an apartment\n" +
                    "building." },

                // Algonquin 11
                { new Vect3d(-30.36f, 1393.96f, 30.125f),
                    "/Northwood\n" +
                    "On the north side of a five-storey apartment\n" +
                    "building's second-level fire escape." },

                // Algonquin 12
                { new Vect3d(141.23f, 1303.44f, 2.652f),
                    "East Holland\n" +
                    "On a cement block next to the water." },

                // Algonquin 13
                { new Vect3d(-680.34f, 1166.44f, 11.08f),
                    "Hickey Bridge\n" +
                    "On the east side support under the bridge.\n" +
                    "Snipe it from the nearby pier or from across\n" +
                    "the river." },

                // Algonquin 14
                { new Vect3d(-668.63f, 1154.48f, 19.39f),
                    "Hickey Bridge\n" +
                    "On the bridge road wall, on the south side\n" +
                    "near the entrance." },

                // Algonquin 15
                { new Vect3d(-502.85f, 1125.48f, 11.905f),
                    "Varsity Heights\n" +
                    "At an old playground behind a parking lot.\n" +
                    "It's in a sandbox on the upper deck." },

                // Algonquin 16
                { new Vect3d(-466.78f, 1018.62f, 11.872f),
                    "Varsity Heights\n" +
                    "At the entrance to a small courtyard/park\n" +
                    "on Galveston Ave and Ruby St. It's on a fancy\n" +
                    "concrete fence post." },

                // Algonquin 17
                { new Vect3d(-209.18f, 1041.11f, 10.967f),
                    "Middle Park\n" +
                    "On a rooftop gable of the park boathouse\n" +
                    "(facing the pond). Climb up to the roof from\n" +
                    "the front side and shoot it." },

                // Algonquin 18
                { new Vect3d(-595.56f, 846f, 11.825f),
                    "Middle Park West\n" +
                    "On the low ledge on the west side of the\n" +
                    "memorial building." },

                // Algonquin 19
                { new Vect3d(-393.73f, 873.82f, 18.275f),
                    "Middle Park West\n" +
                    "On a first-storey windowsill of the Natural\n" +
                    "History Museum. It's near the main entrance\n" +
                    "to the left of the doors." },

                // Algonquin 20
                { new Vect3d(-72.98f, 942.98f, 20.365f),
                    "Middle Park West\n" +
                    "On the concrete entrance post to the park." },

                // Algonquin 21
                { new Vect3d(-25.51f, 840.46f, 18.612f),
                    "Middle Park\n" +
                    "On the southwest corner of the Liberty City\n" +
                    "Delivery building that faces the park. It's on\n" +
                    "the low ledge in the rounded nook." },

                // Algonquin 22
                { new Vect3d(116.9f, 917.86f, 15.162f),
                    "Lancaster\n" +
                    "On the corner of the Quartz St East subway\n" +
                    "entrance railing. It's on the sidewalk at the\n" +
                    "corner of Albany Ave and Quartz St." },

                // Algonquin 23
                { new Vect3d(344.64f, 1010f, 35.15f),
                    "East Borough Bridge\n" +
                    "On the first overhead girder of the bridge\n" +
                    "on the west side." },

                // Algonquin 24
                { new Vect3d(451.5f, 1112.56f, 3.565f),
                    "Charge Island\n" +
                    "On the end of a wooden sailboat that's\n" +
                    "dry-docked on the pier near the large boat\n" +
                    "warehouse." },

                // Algonquin 25
                { new Vect3d(-521.56f, 643.94f, 12.77f),
                    "Middle Park West\n" +
                    "On the pedestrian bridge's top level, on a\n" +
                    "tree planter." },

                // Algonquin 26
                { new Vect3d(-263.38f, 710.1f, 12.74f),
                    "Middle Park West\n" +
                    "In the park above the underground\n" +
                    "bathrooms close to a Hot Dog vendor. It's\n" +
                    "on top of a concrete stair post." },

                // Algonquin 27
                { new Vect3d(-35.41f, 721.84f, 18.947f),
                    "Middle Park West\n" +
                    "On the hotel entryway awning, facing\n" +
                    "Columbus Ave." },

                // Algonquin 28
                { new Vect3d(279.64f, 683.48f, 4.34f),
                    "Humboldt River\n" +
                    "On top of a barge's small cabin." },

                // Algonquin 29
                { new Vect3d(581.39f, 727.9f, 2.098f),
                    "Charge Island\n" +
                    "In a parking lot across from the water\n" +
                    "treatment plant. It's on the ground under\n" +
                    "the East Borough Bridge. Look for the car\n" +
                    "billboards." },

                // Algonquin 30
                { new Vect3d(-420.25f, 435.71f, 12.48f),
                    "Purgatory\n" +
                    "On a concrete step railing in the alleys\n" +
                    "behind Lucky Winkles bar." },

                // Algonquin 31
                { new Vect3d(-115.67f, 429.15f, 17.44f),
                    "Star Junction\n" +
                    "In a tree in the pathway between the\n" +
                    "Seagull Theater and Live Central. The\n" +
                    "tree is in front of the theater's east side\n" +
                    "entrance." },

                // Algonquin 32
                { new Vect3d(7.79f, 411.9f, 89.47f),
                    "Hatton Gardens\n" +
                    "On the tiptop of the cathedral's steeple.\n" +
                    "Snipe it from the south side on Lancet St." },

                // Algonquin 33
                { new Vect3d(145.1f, 478.12f, 18.85f),
                    "Hatton Gardens\n" +
                    "Inside the grounds of the Civilization Committee\n" +
                    "H.Q., underneath a statue on the pedestal. Entering\n" +
                    "this area gives an instant 4-star wanted level, so\n" +
                    "snipe the Pigeon from across the street." },

                // Algonquin 34
                { new Vect3d(-503.98f, 282.26f, 19.731f),
                    "Westminster\n" +
                    "Behind the girder on an old, abandoned\n" +
                    "raised rail line. This is across from Golden\n" +
                    "Pier and behind the Auto Limbo Pay 'n' Spray\n" +
                    "that has a working spray can on top." },

                // Algonquin 35
                { new Vect3d(-287.41f, 236.85f, 204.392f),
                    "Star Junction\n" +
                    "On a railing on the rooftop of the MeTV building.\n" +
                    "The flying rat is on the tier below the helipad.\n" +
                    "Use a helicopter or the window cleaning lift to\n" +
                    "access the rooftop." },
            };
    }
}
