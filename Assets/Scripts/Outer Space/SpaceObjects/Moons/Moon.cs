using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scales;

public class Moon : MonoBehaviour
{
    public Orbiter orbiter;
    public Planet planet;
    public double timeScale = 1f;

    public double angularVelocity; // in rad/s

    public double mass; // in kg
    public double perigee; // in m
    public double apogee; // in m
    public double bodyRadius; // in m
    public double orbitCompletion; // in deg
    public double orbitInclination; // in deg
    public double semimajorAxis; // in m
    public float orbitSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = (float)(mass * Scale.massScale);

        orbiter.transform.localRotation = Quaternion.Euler(0, 0, (float)orbitInclination);
        double completionRadians = orbitCompletion * (System.Math.PI / 180);

        base.transform.localPosition = new Vector3((float)((planet.transform.localScale.x) + ((apogee / 152099995648 * Scale.distScale))), 0, (float)(apogee / 152099995648 * Scale.distScale * System.Math.Sin(completionRadians)));
        rb.transform.localScale = new Vector3((float)(bodyRadius * Scale.radiusScale), (float)(bodyRadius * Scale.radiusScale), (float)(bodyRadius * Scale.radiusScale));

    }

    private void Update()
    {
        transform.Rotate(0, (float)(-angularVelocity * Time.deltaTime * timeScale * Scale.timeScale), 0);
    }
}
