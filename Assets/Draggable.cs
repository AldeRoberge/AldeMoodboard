﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector3 = UnityEngine.Vector3;
/* 
 * Esse Script movimenta o GameObject quando você clica ou
 * mantém o botão esquerdo do mouse apertado.
 * 
 * Para usá-lo, adicione esse script ao gameObject que você quer mover
 * seja o Player ou outro
 * 
 * Autor: Vinicius Rezendrix - Brasil
 * Data: 11/08/2012
 * 
 * This script moves the GameObject when you
 * click or click and hold the LeftMouseButton
 * 
 * Simply attach it to the GameObject you wanna move (player or not)
 * 
 * Autor: Vinicius Rezendrix - Brazil
 * Data: 11/08/2012 
 *
 */
using UnityEngine;
using System.Collections;
using Plane = UnityEngine.Plane;
using Quaternion = UnityEngine.Quaternion;
using UnityEngine;
using System.Collections;
using Vector2 = UnityEngine.Vector2;

public class Draggable : MonoBehaviour
{
    public Action onClick;

    Vector3 targetPosition;
    Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = transform.position;

        myBody = gameObject.GetComponent<Rigidbody>();
    }


    private Rigidbody myBody;


    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
            gameObject.transform.position.y, initialPosition.z);
        
        myBody.useGravity = true;

        if (Input.GetMouseButtonDown(0))
        {
            PlaySoundEffect.Instance.PlayMetalCollision();

            // Turns off gravity to avoid problems with label and mous drag
            myBody.useGravity = false;
        }

        if (Input.GetMouseButtonUp(0))
        {
            myBody.useGravity = true;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            foreach (RaycastHit raycastHit in Physics.RaycastAll(ray, Single.PositiveInfinity))
            {
                if (raycastHit.collider == gameObject.GetComponent<Collider>())
                {
                    //Debug.Log("HIT CUBE!");

                    targetPosition = new Vector3(raycastHit.point.x, raycastHit.point.y,
                        gameObject.transform.position.z);
                    gameObject.transform.position = targetPosition;
                    
       
                    

                    if (onClick != null)
                    {
                        onClick.Invoke();
                    }
                    
                    myBody.useGravity = false;
                }
            }
        }
    }
}