using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryStart : MonoBehaviour
{
    public GameObject cockpit;
    private bool launching = false;
    float speed = 10.0f; 
    float amount = 0.05f;
    private Vector3 cockpitPos;


    public GameObject earth;
    public Camera mainCamera;
    public GameObject sky;
    public GameObject mainMenu;
    public Animator menuAnimator;
    private float cameraRotateSpeed = 75.0f;
    public float rotateSpeed = 10.0f;
    public GameObject[] planetOrder;
    private GameObject currentPlanet;
    private bool movingTowards = false;
    private Transform prevPos;
    private bool ending = false;
    public GameObject fadingPanel;
    public PanelManager panelManager;

    private float timeToPlanet = 100f;
    private float currT;
    private float currTR;


    //Add audio files
    public AudioSource countDownAudio;
    public AudioSource launchAudio;
    public AudioSource beginJourneyAudio;

    public AudioSource[] planetFactAudio;

    public AudioSource endingAudio;
     //Make audio count, increments when audio done playing, start next one?


    // Start is called before the first frame update
    void Start()
    {
        cockpitPos = cockpit.transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (launching)
        {
            cockpit.transform.localPosition = new Vector3(cockpitPos.x + (Mathf.Sin(Time.time * speed) * amount), cockpitPos.y, cockpitPos.z);
        }
        else
        {
            cockpit.transform.localPosition = cockpitPos;
        }


        if (currentPlanet != null)
        {
            if (movingTowards)
            {

                Vector3 sub = currentPlanet.transform.position - prevPos.position;
                SphereCollider col = currentPlanet.GetComponent<SphereCollider>();

                Vector3 newPos = prevPos.position + (sub.normalized * (Vector3.Distance(prevPos.position, currentPlanet.transform.position) - col.radius - currentPlanet.transform.localScale.x + 5));

                currTR += Time.deltaTime / 1.5f;
                mainCamera.transform.rotation = Quaternion.Slerp(prevPos.rotation, Quaternion.LookRotation(sub), currTR);

                currT += Time.deltaTime / timeToPlanet;
                mainCamera.transform.position = Vector3.Slerp(prevPos.position, newPos, currT);

                if (Vector3.Distance(mainCamera.transform.position, newPos) <= 1)
                {
                    movingTowards = false;
                }

            } else
            {
                mainCamera.transform.LookAt(currentPlanet.transform, Vector3.up);
                mainCamera.transform.Translate(Vector3.right * rotateSpeed * Mathf.Min(currentPlanet.transform.localScale.x, 5) * Time.deltaTime);
            }
            if (ending)
            {
                Vector3 sub = currentPlanet.transform.position - prevPos.position;

                currTR += Time.deltaTime / 1.5f;
                mainCamera.transform.rotation = Quaternion.Slerp(prevPos.rotation, Quaternion.LookRotation(sub), currTR);
            }

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



    private void MoveToPlanet(GameObject obj)
    {
        movingTowards = true;
        prevPos = mainCamera.transform;
        currentPlanet = obj;
        
        
    }

    private IEnumerator afterCountdown(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        Launch();
    }

    private IEnumerator afterLaunch(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);

        launching = false;
        StoryConstants.Instance.isDoneL = true;


        FreeFlyCamera ffc = mainCamera.GetComponent<FreeFlyCamera>();
        ffc._active = false;

        StartCoroutine(removeControls());

        Material skyMaterial = sky.GetComponent<MeshRenderer>().material;
        skyMaterial.color = Color.white;

        Animator animator = sky.GetComponent<Animator>();
        animator.SetBool("launch", false);

        sky.SetActive(false);

        float length = beginJourneyAudio.clip.length;
        beginJourneyAudio.Play(0);
        StartCoroutine(startNextPlanet(length, 0));

    }

    private IEnumerator startNextPlanet(float clipLength, int index)
    {
        yield return new WaitForSeconds(clipLength);

        

        if (index < planetOrder.Length)
        {
            currT = 0;
            currTR = 0;
            float length = planetFactAudio[index].clip.length;
            planetFactAudio[index].Play(0);
            MoveToPlanet(planetOrder[index]);
            StartCoroutine(startNextPlanet(length, index + 1));
        } else
        {
            //Do end
            movingTowards = false;
            ending = true;
            currentPlanet = planetOrder[0];
            float len = endingAudio.clip.length;
            endingAudio.Play(0);
            StartCoroutine(startFade(len));
        }
    }

    private IEnumerator startFade(float length)
    {
        yield return new WaitForSeconds(length - 0.75f);

        fadingPanel.SetActive(true);
        currentPlanet = null;

        fadingPanel.GetComponent<Animator>().SetBool("fadeOn", true);

        StartCoroutine(endFade(2));
    }

    private IEnumerator removeControls()
    {
        yield return new WaitForSeconds(10);

        panelManager.CloseCurrent();

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
        StoryConstants.Instance.isDoneL = false;
        fadingPanel.GetComponent<Animator>().SetBool("fadeOn", false);
        mainMenu.SetActive(true);

        yield return new WaitForSeconds(1.0f);
        sky.SetActive(false);
        panelManager.OpenPanel(menuAnimator);
        fadingPanel.SetActive(false);
       
    }
}
