using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;


[RequireComponent(typeof(CameraShaker))]
public class TriggerThunder : MonoBehaviour
{
    public GameObject thunder;

    // Start is called before the first frame update
    void Start()
    {
        CameraShaker.Instance.ShakeOnce(0.5f, 0.5f, .1f, 2f);


       
        
        if (thunder == null)
        {
            Debug.Log("Fatal : Could not find Thunder.");
        }
        else
        {
            thunder.SetActive(true);
            
            Flicker f = thunder.GetComponent<Flicker>();
            f.triggerFlicker = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
