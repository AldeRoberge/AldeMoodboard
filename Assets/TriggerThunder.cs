using System;
using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;


[RequireComponent(typeof(CameraShaker))]
public class TriggerThunder : MonoBehaviour
{
    public GameObject thunder;

    public void Activate()
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
}
