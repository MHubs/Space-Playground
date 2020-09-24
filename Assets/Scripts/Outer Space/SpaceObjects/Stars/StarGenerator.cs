using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{

    public int starAmount = 100;
    public float radius = 7000000;
    public float distance = 900000000;
    public OuterStar star;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < starAmount; i++)
        {
            OuterStar s = Instantiate(star, new Vector3(distance, 0), Quaternion.identity) as OuterStar;
            s.transform.parent = this.transform;
            s.bodyRadius = radius;
            s.apogee = distance;
            s.orbitInclination = Random.Range(0, 360);
            s.orbitCompletion = Random.Range(0, 360);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
