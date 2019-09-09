﻿using System;
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
        CameraShaker.Instance.ShakeOnce(2f, 0.5f, .1f, 3f);

        if (thunder == null)
        {
            Debug.Log("Fatal : Could not find Thunder.");
        }
        else
        {
            thunder.SetActive(true);
            thunder.GetComponent<Flicker>().triggerFlicker = true;
        }
    }

    public void Deactivate()
    {
        if (thunder == null)
        {
            Debug.Log("Fatal : Could not find Thunder.");
        }
        else
        {
            thunder.SetActive(false);
            thunder.GetComponent<Flicker>().triggerFlicker = false;
        }
    }
}