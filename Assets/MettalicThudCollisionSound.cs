using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MettalicThudCollisionSound : MonoBehaviour
{


    private void OnCollisionEnter(Collision other)
    {
        PlaySoundEffect.Instance.PlayMetalCollision();
    }

}
