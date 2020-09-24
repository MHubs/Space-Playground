using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonActivity : MonoBehaviour
{
    public GameObject settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onSettingsClick()
    {
        settingsButton.SetActive(false);
    }

    public void onCloseClick()
    {
        StartCoroutine(buttonCo());
    }

    IEnumerator buttonCo()
    {
        yield return new WaitForSeconds(0.6f);
        Animator an = GetComponent<Animator>();
        settingsButton.SetActive(true);
        an.SetBool("Selected", false);
        an.SetBool("Normal", true);
    }
}
