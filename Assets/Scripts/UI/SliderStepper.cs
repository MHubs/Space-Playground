using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderStepper : MonoBehaviour
{
    private Slider slider;
    public int startStep;
    public int mediumStep;
    public int highStep;
    public int ultraStep;
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
        if (slider.value < 10)
        {
            slider.value = slider.value - (slider.value % startStep);
        } else if (slider.value < 100)
        {
            slider.value = slider.value - (slider.value % mediumStep);
        } else if (slider.value < 1000)
        {
            slider.value = slider.value - (slider.value % highStep);
        }  else
        {
            slider.value = slider.value - (slider.value % ultraStep); 
        }
        
    }
}
