using UnityEngine;
using Scales;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public Orbiter orbiter;
    public GameObject system;
    public double timeScale = 1;

    public double angularVelocity; // in rad/s

    public double mass; // in kg
    public double perihelion; // in m
    public double aphelion; // in m
    public double bodyRadius; // in m
    public double orbitCompletion; // in deg
    public double orbitInclination; // in deg
    public double semimajorAxis; // in m

    public Torus orbitPaths;


    // Start is called before the first frame update
    void Start()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = (float)(mass * Scale.massScale);

       
        orbiter.transform.localRotation = Quaternion.Euler(0, 0, (float)orbitInclination);

        rb.transform.localPosition = Vector3.zero;

        double completionRadians = orbitCompletion * (System.Math.PI / 180);

        system.transform.localPosition = new Vector3((float)((aphelion / 152099995648) * Scale.distScale), 0, (float)(aphelion / 152099995648 * Scale.distScale * System.Math.Sin(completionRadians)));

        rb.transform.localScale = new Vector3((float)(bodyRadius * Scale.radiusScale), (float)(bodyRadius * Scale.radiusScale), (float)(bodyRadius * Scale.radiusScale));

    }

    

    private void Update()
    {
        transform.Rotate(0, (float)(-angularVelocity * Time.deltaTime * timeScale * Scale.timeScale), 0);

        if (StoryConstants.Instance.orbitPaths)
        {
            if (!orbitPaths.isActiveAndEnabled)
            {
                orbitPaths.gameObject.SetActive(true);
            }

        }
        else
        {
            if (orbitPaths.isActiveAndEnabled)
            {
                orbitPaths.gameObject.SetActive(false);
            }
        }
    }
}
