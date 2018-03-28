using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WHampson.PigeonLocator
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct Vect3d
    {
        public float X;
        public float Y;
        public float Z;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct FileHeader
    {
        public uint FileVersion;
        public uint FileSize;
        public uint GlobalVarsSize;
        public fixed byte Signature[4];
        public fixed char LastMissionName[128];
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct BlockHeader
    {
        public fixed byte Signature[5];
        public uint BlockSize;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct Pickup
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
        public ObjectType ObjectId;
        public short ReferenceNumber;
        public PickupType Type;
        public byte AvailabilityFlags;
        public short _Unknown4C;
        public uint _Unknown50;
    }

    internal enum PickupType : byte
    {
        Pigeon = 3
    }

    internal enum ObjectType : short
    {
        Pigeon = 0x08DC
    }
}
