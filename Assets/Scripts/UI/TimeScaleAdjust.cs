using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleAdjust : MonoBehaviour
{
    private Slider slider;

    public Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onValueChange() {
        Scales.Scale.timeScale = slider.value;
        if (slider.value == 1)
        {
            timeText.text = "Time: Realtime";
        } else
        {
            timeText.text = "Time: " + slider.value + "x";
        }
        
    }

}
