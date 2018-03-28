using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WHampson.PigeonLocator.IvSave;

namespace WHampson.PigeonLocator
{
    class PigeonLocator
    {
        static void PrintSizeOf(Type t)
        {
            Console.WriteLine("SizeOf({0}) = {1}", t.Name, Marshal.SizeOf(t));
        }

        static void Main(string[] args)
        {
            PrintSizeOf(typeof(FileHeader));
            PrintSizeOf(typeof(BlockHeader));
            PrintSizeOf(typeof(Pickup));
            Console.ReadLine();
        }
    }
}
