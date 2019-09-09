using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodOrBadDetector : MonoBehaviour
{
    public Light light;

    public Action<ChoiceContainer> onCollisionEnter;
    public Action onCollisionExit;

    void Start()
    {
        // turns off lights
        SetLightActiveTo(false);
    }

    
    // When a cube enters the pillar
    void OnCollisionEnter(Collision hit)
    {
        Debug.Log("Collision");

        if (onCollisionEnter != null)
        {
            ChoiceContainer c = hit.gameObject.GetComponent<ChoiceContainer>();

            if (c != null)
            {
                PlaySoundEffect.Instance.PlayMetalicThud();
                onCollisionEnter.Invoke(c);
            }
            else
            {
                Debug.LogError("FATAL ERROR : No choice container in collision.");
            }
        }
        else
        {
            Debug.Log("FATAL: OnCollisionExit is null.");
        }

        SetLightActiveTo(true);
    }

    
    // When a cube leaves the pillar
    void OnCollisionExit(Collision hit)

    {
        if (onCollisionExit != null)
        {
            onCollisionExit.Invoke();
        }
        else
        {
            Debug.Log("FATAL: OnCollisionExit is null.");
        }

        SetLightActiveTo(false);
    }

    
    // Activates the pillar light
    private void SetLightActiveTo(bool b)
    {
        if (light == null)
        {
            Debug.Log("Fatal : Light is null.");
        }
        else
        {
            if (b)
            {
                light.intensity = 2f;
            }
            else
            {
                light.intensity = 0f;
            }
        }
    }
}