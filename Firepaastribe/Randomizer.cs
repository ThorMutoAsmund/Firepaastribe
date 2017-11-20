using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firepaastribe
{
    public static class Randomizer
    {
        private static Random r = new Random();

        public static int Next(int maxValue)
        {
            return r.Next(maxValue);
        }
    }
}
