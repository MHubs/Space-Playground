using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementSpeedAdjust : MonoBehaviour
{
    public FreeFlyCamera cam;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onValueChange()
    {
        cam._movementSpeed = slider.value;

    }
}
