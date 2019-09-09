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
            Destroy(gameObject);
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
        audioSource = gameObject.AddComponent<AudioSource>();


        droppingBar1 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar5");
        droppingBar2 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar6");
        droppingBar3 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar7");
        droppingBar4 = Resources.Load<AudioClip>("Sounds/MetalicThud/droppingBar8");
    }


    public void PlayMetalCollision()
    {
        audioSource.volume = 0.05f;

        if (audioSource.isPlaying) return;

        switch (Random.Range(0, 3))
        {
            case 0:
                audioSource.PlayOneShot(droppingBar1);
                break;
            case 1:
                audioSource.PlayOneShot(droppingBar2);
                break;
            case 2:
                audioSource.PlayOneShot(droppingBar3);
                break;
            case 3:
                audioSource.PlayOneShot(droppingBar4);
                break;
        }
    }
}