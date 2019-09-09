using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    private static PlaySoundEffect _instance;

    public static PlaySoundEffect Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // BEGIN

    private AudioSource audioSource;

    AudioClip droppingBar1;
    AudioClip droppingBar2;
    AudioClip droppingBar3;
    AudioClip droppingBar4;

    public void Start()
    {
        this.audioSource = this.gameObject.AddComponent<AudioSource>();


        droppingBar1 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar1");
        droppingBar2 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar2");
        droppingBar3 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar3");
        droppingBar4 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar4");
    }


    public void PlayMetalicThud()
    {
        this.audioSource.volume = 0.25f;

        switch (Random.Range(0, 3))
        {
            case 0:
                this.audioSource.PlayOneShot(droppingBar1);
                break;
            case 1:
                this.audioSource.PlayOneShot(droppingBar2);
                break;
            case 2:
                this.audioSource.PlayOneShot(droppingBar3);
                break;
            case 3:
                this.audioSource.PlayOneShot(droppingBar4);
                break;
        }
    }
}