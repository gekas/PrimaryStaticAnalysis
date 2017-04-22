using static System.Math;
using System;

namespace Utils
{
    public static class Quantiles
    {
        public static double t_Student(double p, double v)
        {
            double up = u(p);
            return up + g1(up) / v + g2(up) / Pow(v, 2) + g3(up) / Pow(v, 3) + g4(up) / Pow(v, 4);
        }

        public static double u_Normal(double p) => u(p);
        public static double f_Fisher(double p, double v1, double v2) => Math.Exp(2 * z(p, v1, v2));

        //Student____________________________________________
        private static double phi(double a)
        {
            double c0 = 2.515517;
            double c1 = 0.802853;
            double c2 = 0.010328;
            double d1 = 1.432788;
            double d2 = 0.1892659;
            double d3 = 0.001308;

            double t = Math.Sqrt(-2 * Log(a));
            return t - (c0 + c1 * t + c2 * Pow(t, 2)) / (1 + d1 * t + d2 * Pow(t, 2) + d3 * Pow(t, 3));
        }

        private static double u(double p) => p <= 0.5 ? -phi(p) : phi(1 - p);
        private static double g1(double u) => (Pow(u, 3) + u) / 4.0;
        private static double g2(double u) => (5 * Pow(u, 5) + 16 * Pow(u, 3) + 3 * u) / 96.0;
        private static double g3(double u) => (3 * Pow(u, 7) + 19 * Pow(u, 5) + 17 * Pow(u, 3) - 15 * u) / 384.0;

        private static double g4(double u)
            => (79 * Pow(u, 9) + 779 * Pow(u, 7) + 1482 * Pow(u, 5) - 1920 * Pow(u, 3) - 945 * u) / 92160.0;

        //______________________________________________________

        private static double z(double p, double v1, double v2)
        {
            double u = Quantiles.u(p);
            double s = 1 / v1 + 1 / v2;
            double d = 1 / v1 - 1 / v2;
            double res = u * Sqrt(s / 2) - d * (u * u + 2) / 6 + Sqrt(s / 2) * (s * (u * u + 3 * u) / 24 + d * d * (u * u * u + 11 * u) / (72 * s)) -
                         s * d * (Pow(u, 4) + 9 * u * u + 8) / 120 + Pow(d, 3) * (3 * Pow(u, 4) + 7 * u * u - 16) / (3240 * s) +
                         Sqrt(s / 2) *
                         (s * s * (Pow(u, 5) + 20 * Pow(u, 3) + 15 * u) / 1920 + Pow(d, 4) * (Pow(u, 5) + 44 * Pow(u, 3) + 183 * u) / 2880 +
                          Pow(d, 4) * (9 * Pow(u, 5) - 284 * Pow(u, 3) - 1513 * u) / (155520 * s * s));
            return res;
        }
    }
}