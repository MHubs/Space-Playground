using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTeleport : MonoBehaviour
{

    public Camera cam;
    public Planet press0;
    public Planet press1;
    public Planet press2;
    public Planet press3;
    public Planet press4;
    public Planet press5;
    public Planet press6;
    public Planet press7;
    public Planet press8;
    public Planet press9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cam.transform.position = press0.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam.transform.position = press1.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam.transform.position = press2.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam.transform.position = press3.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam.transform.position = press4.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            cam.transform.position = press5.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            cam.transform.position = press6.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            cam.transform.position = press7.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            cam.transform.position = press8.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            cam.transform.position = press9.transform.position;
        }
    }
}
