using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scales;

public class Star : MonoBehaviour
{
    public Light starLight;

    public double timeScale = 1f;

    public double angularVelocity; // in rad/s
    public double orbitalAngularVelocity; // in rad/s

    public double mass; // in kg
    public double perigee; // in m
    public double apogee; // in m
    public double bodyRadius; // in m
    public double orbitCompletion; // in deg
    public double orbitInclination; // in deg


    // Start is called before the first frame update
    private void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = (float)(mass * Scale.massScale);
        double inclinationRadians = orbitInclination * (System.Math.PI / 180);
        rb.transform.localPosition = new Vector3((float)(apogee / 152099995648 * Scale.distScale * System.Math.Cos(inclinationRadians)), (float)(apogee / 152099995648 * Scale.distScale * System.Math.Sin(inclinationRadians)), 0);
        rb.transform.localScale = new Vector3((float) (bodyRadius * Scale.radiusScale), (float)(bodyRadius * Scale.radiusScale), (float) (bodyRadius * Scale.radiusScale));

        if (starLight != null)
        {
            starLight.transform.localScale = rb.transform.localScale;
        }
    }

    private void Update()
    {
        transform.Rotate(0, (float)(-angularVelocity * Time.deltaTime * timeScale * Scale.timeScale), 0);
    }
}
