using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour
{

    public Canvas menu;
    public Text planetLabel;
    public Text planetFacts;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && menu != null && StoryConstants.Instance.launchDone || StoryConstants.Instance.isDoneL)
        {
            animator.SetBool("Open", true);
            planetLabel.enabled = true;
            planetFacts.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera") && menu != null)
        {
            animator.SetBool("Open", false);
            StartCoroutine(RemoveLabelsCO());
        }
    }

    private IEnumerator RemoveLabelsCO()
    {
        yield return new WaitForSeconds(0.5f);

        if (!animator.GetBool("Open"))
        {
            planetLabel.enabled = false;
            planetFacts.enabled = false;
        }
        
    }
}
