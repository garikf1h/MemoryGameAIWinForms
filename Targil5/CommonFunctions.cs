using System;
using System.Collections.Generic;
using System.Text;

namespace Targil5
{
    internal static class CommonFunctions
    {
        private static readonly Random sr_Random = new Random();

        public static void Swap(ref GameCell i_GC1, ref GameCell i_GC2)
        {
            GameCell temp = i_GC1;
            i_GC1 = i_GC2;
            i_GC2 = temp;
        }

        public static int Random(int i_Range)
        {
            return sr_Random.Next(i_Range);
        }
    }
}
