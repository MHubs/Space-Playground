using System;

namespace Scales
{
    public class Scale
    {
        //public static double distScale = 0.0005 / 6378137.0;
        public static double distScale = (1000 + (695507968.0000 / 6378137.0000));
        public static double radiusScale = (1.0000 / 6378137.0000);

        public static double massScale = 0.0005 / (5.97219 * System.Math.Pow(10, 24));
        public static double timeScale = 1.0;
    }
}

