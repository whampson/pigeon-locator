using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WHampson.PigeonLocator
{
    internal class IvSavegame
    {
        public static IvSavegame Load(string path)
        {
            return null;
        }

        private IvSavegame()
        {

        }

        public Vect3d[] GetRemainingPigeonLocations()
        {
            return new Vect3d[0];
        }
    }
}
