using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public ParticleSystem p1;
    public ParticleSystem p2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1.transform.localScale = this.transform.localScale;
        p2.transform.localScale = this.transform.localScale;
    }
}
