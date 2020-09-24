using UnityEngine;
using System.Collections.Generic;

public class Attractor : MonoBehaviour {

    public Rigidbody rb;

    public static List<Attractor> Attractors;

    private void FixedUpdate()
    {
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
                Attract(attractor);
        }
    }

    void OnEnable ()
    {
        if (Attractors == null)
            Attractors = new List<Attractor>();

        Attractors.Add(this);
    }

    void OnDisable()
    {
        Attractors.Remove(this);
    }

    void Attract (Attractor objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.rb;

        Vector3 direction = rb.transform.position - rbToAttract.transform.position;
        double distance = direction.magnitude;

        if (distance == 0f)
            return;

        

        double forceMagnitude = Constant.G * (rb.mass * rbToAttract.mass) / System.Math.Pow(distance, 2);

        Vector3 force = direction.normalized * (float)forceMagnitude;

        //rbToAttract.AddForce(force);
    }

}