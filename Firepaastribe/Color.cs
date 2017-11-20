using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firepaastribe
{
    public static class Color
    {
        public const int None = 0;
        public const int Red = 1;
        public const int Blue = 2;
        public const int First = Red;

        public static int Next(int color)
        {
            return (int)((color % 2) + 1);
        }
    }
}
