using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateWhenSoundEnds : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying) return;
        
        this.gameObject.SetActive(false);
    }
}