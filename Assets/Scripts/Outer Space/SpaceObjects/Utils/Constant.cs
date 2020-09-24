using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Constant : MonoBehaviour {

    public static double G
    {
        get {
            return 6.67430 * System.Math.Pow(10, -11);
        }
    }

    public static double SunMass
    {
        get
        {
            return 1.9885 * System.Math.Pow(10, 30) * Scales.Scale.massScale;
        }
    }

    public static double AU
    {
        get
        {
            return 1.496 * System.Math.Pow(10, 11);
        }
    }

    public static double K
    {
        get
        {
            return (4 * System.Math.Pow(System.Math.PI, 2)) / (G * SunMass);
        }
    }
}
