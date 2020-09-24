using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOrbitPaths : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeOrbitPaths()
    {
        StoryConstants.Instance.orbitPaths = !StoryConstants.Instance.orbitPaths;
    }
}
