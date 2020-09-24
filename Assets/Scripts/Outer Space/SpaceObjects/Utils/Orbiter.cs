using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public float timeScale;
    public float angularVelocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, (float)(-angularVelocity * Time.deltaTime * timeScale * Scales.Scale.timeScale), 0);
    }
}
