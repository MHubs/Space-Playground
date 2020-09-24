using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFly : MonoBehaviour
{
    public GameObject cockpit;

    public GameObject earth;
    public Camera mainCamera;
    public GameObject sky;
    public GameObject mainMenu;
    public Animator menuAnimator;
    public AudioSource countDownAudio;
    public AudioSource launchAudio;

    public GameObject controlsMenu;
    public GameObject backToMenu;

    public GameObject fadingPanel;
    public PanelManager panelManager;

    private bool launching = false;
    float speed = 10.0f;
    float amount = 0.05f;
    private Vector3 cockpitPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (launching)
        {
            cockpit.transform.localPosition = new Vector3(cockpitPos.x + (Mathf.Sin(Time.time * speed) * amount), cockpitPos.y, cockpitPos.z);
        }
        else if (StoryConstants.Instance.launchDone)
        {
            cockpit.transform.localPosition = cockpitPos;
        }
    }

    public void startStory()
    {
        
        sky.SetActive(true);
        cockpit.SetActive(true);
        Animator animator = sky.GetComponent<Animator>();
        animator.SetBool("launch", false);
        mainCamera.transform.position = new Vector3(earth.transform.position.x - 3, earth.transform.position.y, earth.transform.position.z - 3);
        mainCamera.transform.LookAt(earth.transform, Vector3.up);

        mainMenu.SetActive(false);
        // Play prelaunch sequence
        countDownAudio.loop = false;
        float clipLength = countDownAudio.clip.length;
        countDownAudio.Play(0);

        StartCoroutine(afterCountdown(clipLength));
    }

    private IEnumerator afterCountdown(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        Launch();
    }

    public void Launch()
    {
        float clipLength = launchAudio.clip.length;
        cockpitPos = cockpit.transform.localPosition;
        launching = true;
        launchAudio.Play(0);
        Animator animator = sky.GetComponent<Animator>();
        animator.SetBool("launch", true);


        StartCoroutine(afterLaunch(clipLength));

    }

    private IEnumerator afterLaunch(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);

        launching = false;
        StoryConstants.Instance.launchDone = true;
        FreeFlyCamera ffc = mainCamera.GetComponent<FreeFlyCamera>();
        ffc._active = true;

        backToMenu.SetActive(true);

        //Display controls
        panelManager.OpenPanel(controlsMenu.GetComponent<Animator>());
        StartCoroutine(removeControls());

        // Restore sky

        Material skyMaterial = sky.GetComponent<MeshRenderer>().material;
        skyMaterial.color = Color.white;

        Animator animator = sky.GetComponent<Animator>();
        animator.SetBool("launch", false);

        sky.SetActive(false);
    }

    private IEnumerator removeControls()
    {
        yield return new WaitForSeconds(10);

        panelManager.CloseCurrent();

    }


    public void BackToMain()
    {
        StoryConstants.Instance.launchDone = false;
        FreeFlyCamera ffc = mainCamera.GetComponent<FreeFlyCamera>();
        ffc._active = false;
        backToMenu.SetActive(false);
        startFade();
    }

    private void startFade()
    {

        fadingPanel.SetActive(true);

        fadingPanel.GetComponent<Animator>().SetBool("fadeOn", true);

        StartCoroutine(endFade(2));
    }

    private IEnumerator endFade(float length)
    {
        yield return new WaitForSeconds(length);
        mainCamera.transform.position = new Vector3(0, 600, -100);
        mainCamera.transform.rotation = Quaternion.Euler(0, 0, 0);

        cockpit.SetActive(false);

        Material skyMaterial = sky.GetComponent<MeshRenderer>().material;
        skyMaterial.color = Color.white;

        Animator animator = sky.GetComponent<Animator>();
        animator.SetBool("launch", false);

        launching = false;
        StoryConstants.Instance.launchDone = false;
        fadingPanel.GetComponent<Animator>().SetBool("fadeOn", false);
        mainMenu.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        sky.SetActive(false);
        panelManager.OpenPanel(menuAnimator);
        fadingPanel.SetActive(false);

    }
}
