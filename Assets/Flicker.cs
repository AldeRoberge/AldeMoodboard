using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    void Update()
    {
        if (Time.time < flickerEndTime)
        {
            Color flashAlpha = GetComponent<Renderer>().material.color;
            // PingPong between 0.3 and 1;
            flashAlpha.a = 0.3f + Mathf.PingPong(Time.time, 0.7f);
            // Assuming your renderer is on this.gameObject!
            GetComponent<Renderer>().material.color = flashAlpha;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    /// If this is in the future, we are flickering.
    float flickerEndTime { get; set; }
}
