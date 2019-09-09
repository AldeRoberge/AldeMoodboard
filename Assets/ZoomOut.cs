using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZoomOut : MonoBehaviour
{
    public float initialFOV = 9;

    private float currentFOV;

    public float targetFOV = 40;

    public float smooth = 5;


    // Update is called once per frame
    void Update()
    {
        //store current field of view value in variable
        currentFOV = Camera.main.fieldOfView;
        UpdateFOV();
    }

    //function to zoom in the FOV
    void UpdateFOV()
    {
        //check that current FOV is different than Zoomed
        if (Math.Abs(currentFOV - targetFOV) > 0.05)
        {
            //check if current FOV is grater than the Zoomed in FOV input and increment the FOV smoothly
            if (targetFOV > currentFOV)
            {
                Camera.main.fieldOfView += (smooth * Time.deltaTime);
            }
            else
            {
                Camera.main.fieldOfView -= (smooth * Time.deltaTime);
            }
        }
    }
}