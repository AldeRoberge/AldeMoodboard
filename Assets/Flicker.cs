using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    /// If this is in the future, we are flickering.
    public float flickerEndTime;
    public bool triggerFlicker;
    
    void Update()
    {
        if (triggerFlicker)
        {
            triggerFlicker = false;
            // flicker for one second into the future
            flickerEndTime = Time.time + 0.2f;
        }
        
        if (Time.time > flickerEndTime)
        {
            Color flashAlpha = GetComponent<Renderer>().material.color;
            flashAlpha.a = 0;
            GetComponent<Renderer>().material.color = flashAlpha;
        }
    }
}