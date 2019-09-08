﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;
 
public class SlightCameraMovement : MonoBehaviour {
 
 
    public Transform cameraTransform;
    public float shakeLength = 5;
    public float shakeTimer;
    public float shakeAmount = 3;
    public float shakeSpeed = 20;
    public bool isShaking = false;
    Vector3 originalPos;
    Vector3 newPos;
 
    void Awake()
    {
        shakeTimer = shakeLength;
    }
         
    void OnEnable()
    {

        if (cameraTransform == null)
        {
            cameraTransform = this.gameObject.transform;
        }
        
        originalPos = cameraTransform.position;

        Shake();
    }
         
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !isShaking) {
            shakeTimer = shakeLength;
            newPos = cameraTransform.position;
        }

    }
         
    public void Shake() {
        if (shakeTimer > 0)
        {
            isShaking = true;
 
            if (Vector3.Distance(newPos,cameraTransform.position)<=shakeAmount/30) {newPos = originalPos+Random.insideUnitSphere * shakeAmount;}
 
            cameraTransform.position = Vector3.Lerp(cameraTransform.position, newPos , Time.deltaTime*shakeSpeed);
                 
            shakeTimer -= Time.deltaTime;
        }
        else 
        {
            shakeTimer = 0f;
            cameraTransform.position = originalPos;
            isShaking = false;
        }
    }
}