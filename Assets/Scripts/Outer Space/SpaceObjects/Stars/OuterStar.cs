using UnityEngine;
using System.Collections;
using Scales;

public class OuterStar : MonoBehaviour
{
    public double timeScale = 1f;

    public double apogee; // in m
    public double bodyRadius; // in m
    public double orbitCompletion; // in deg
    public double orbitInclination; // in deg


    // Start is called before the first frame update
    void Start()
    {
        
        double inclinationRadians = orbitInclination * (System.Math.PI / 180);
        double completionRadians = orbitCompletion * (System.Math.PI / 180);


        transform.localPosition = new Vector3((float)(apogee / 152099995648 * Scale.distScale * System.Math.Cos(inclinationRadians)), (float)(apogee / 152099995648 * Scale.distScale * System.Math.Sin(inclinationRadians)), (float)(apogee / 152099995648 * Scale.distScale * System.Math.Sin(completionRadians)));
        transform.localScale = new Vector3((float)(bodyRadius * Scale.radiusScale), (float)(bodyRadius * Scale.radiusScale), (float)(bodyRadius * Scale.radiusScale));
    }

    private void Update()
    {

    }
}
