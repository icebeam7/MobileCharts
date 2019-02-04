using System;
using System.Collections.Generic;

namespace MobileCharts.Helpers
{
    public static class ColorHelper
    {
        static Random random = new Random();

        private static string GetRandomColor()
        {
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }

        public static IEnumerable<string> GetRandomColors()
        {
            for (var i = 0; i < 10; i++)
                yield return GetRandomColor();
        }
    }
}
