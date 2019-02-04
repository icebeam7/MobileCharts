using System;

namespace MobileCharts.Helpers
{
    public static class MathHelper
    {
        static Random random = new Random();

        public static float GetRandomValue(int li, int ls)
        {
            return (float)(random.NextDouble() * (ls - li) + li);
        }

        public static bool GetRandomBool()
        {
            return (random.Next(0, 2) == 1);
        }

        public static double f(double x)
        {
            // ecuacion: f(x) = 2x^3 - x^2 - 5x
            return (2 * Math.Pow(x, 3) - Math.Pow(x, 2) - 5 * x);
        }

        public static double Rastrigin(double x, double y)
        {
            return 0.2 * (Math.Sin(10 * x - Math.PI / 2) + Math.Sin(10 * y - Math.PI / 2)) + Math.Pow(x, 2) + Math.Pow(y, 2);
        }

        public static double[] CreateVector(double x0, double x1, int n)
        {
            var vector = new double[n + 1];
            var m = (x1 - x0) / n;

            for (int i = 0; i < n; i++)
                vector[i] = x0 + i * m;

            return vector;
        }
    }
}
