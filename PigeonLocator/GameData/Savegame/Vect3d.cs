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
using System.Runtime.InteropServices;

namespace WHampson.PigeonLocator.IvGameData
{
    /// <summary>
    /// Represents a vector in 3-space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Vect3d : IEquatable<Vect3d>
    {
        private const int DecimalPlaces = 4;

        /// <summary>
        /// Creates a new <see cref="Vect3d"/> with the specified
        /// x, y, and z coordinates.
        /// </summary>
        /// <param name="x">The x component of the vector.</param>
        /// <param name="y">The y component of the vector.</param>
        /// <param name="z">The z component of the vector.</param>
        public Vect3d(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The x-component of the vector.
        /// </summary>
        public float X { get; }

        /// <summary>
        /// The y-component of the vector.
        /// </summary>
        public float Y { get; }

        /// <summary>
        /// The z-component of the vector.
        /// </summary>
        public float Z { get; }

        public override string ToString()
        {
            return string.Format("<{0}, {1}, {2}>", X, Y, Z);
        }

        public override int GetHashCode()
        {
            float xRound = (float) Math.Round(X, DecimalPlaces);
            float yRound = (float) Math.Round(Y, DecimalPlaces);
            float zRound = (float) Math.Round(Z, DecimalPlaces);

            int hash = 13;
            hash = (hash * 17) + xRound.GetHashCode();
            hash = (hash * 17) + yRound.GetHashCode();
            hash = (hash * 17) + zRound.GetHashCode();

            return hash;
        }

        public bool Equals(Vect3d p)
        {
            float compareDelta = 1f / (float) Math.Pow(10, DecimalPlaces);

            float xDelta = Math.Abs(X - p.X);
            float yDelta = Math.Abs(Y - p.Y);
            float zDelta = Math.Abs(Z - p.Z);

            return xDelta <= compareDelta
                && yDelta <= compareDelta
                && zDelta <= compareDelta;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vect3d)) {
                return false;
            }

            return Equals((Vect3d) obj);
        }

        public static bool operator ==(Vect3d a, Vect3d b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vect3d a, Vect3d b)
        {
            return !a.Equals(b);
        }
    }
}
