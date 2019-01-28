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

using System.Runtime.InteropServices;

namespace WHampson.PigeonLocator.IvGameData
{
    /// <summary>
    /// A collectible object in the game world.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Pickup
    {
        public uint _Unknown00;
        public uint Index;
        public uint _Unknown08;
        public uint _Unknown0C;
        public uint Value;
        public uint _Unknown14;
        public uint _Unknown18;
        public uint _Unknown1C;
        public uint _Unknown20;
        public Vect3d Location;
        public uint _Unknown30;
        public uint _Unknown34;
        public float _Unknown38;
        public uint _Unknown3C;
        public float _Unknown40;
        public uint _Unknown44;
        public ObjectId Object;
        public short ReferenceNumber;
        public PickupId Type;
        public byte AvailabilityFlags;
        public short _Unknown4C;
        public uint _Unknown50;
    }
}
