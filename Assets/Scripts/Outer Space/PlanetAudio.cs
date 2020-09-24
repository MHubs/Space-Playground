using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAudio : MonoBehaviour
{

    public AudioSource audioSource;
    public float volume = 1.0f;
    public float maxDist = 50f;
    public bool loop = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.maxDistance = maxDist;
        audioSource.loop = loop;
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position, volume);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
