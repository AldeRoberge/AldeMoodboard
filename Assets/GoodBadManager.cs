using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


//TODO I'M very well aware this is utter spag code. This comment won't fix anything, but eh.
public class GoodBadManager : MonoBehaviour
{
    public TriggerThunder triggerThunder; //Found on MainCamera

    public GoodOrBadDetector goodCollider;
    public GoodOrBadDetector badCollider;

    private FallingBoxesSpawner FallingObjectSpawner;
    public TMP_Text infoText;

    public GameObject Rain;
    
    bool badIsCollided;
    bool goodIsCollided;

    // Start is called before the first frame update
    void Start()
    {
        FallingObjectSpawner = gameObject.AddComponent<FallingBoxesSpawner>();
        FallingObjectSpawner.infoText = infoText;
        
        if (goodCollider == null)
        {
            Debug.LogError("FATAL: Good detector is null.");
        }
        else
        {
            goodCollider.onCollisionEnter = () =>
            {
                goodIsCollided = true;
                UpdateCollisions();
            };
            goodCollider.onCollisionExit = () =>
            {
                goodIsCollided = false;
                UpdateCollisions();
            };
        }

        if (badCollider == null)
        {
            Debug.LogError("FATAL: Bad detector is null.");
        }
        else
        {
            badCollider.onCollisionEnter = () =>
            {
                badIsCollided = true;
                UpdateCollisions();
            };
            badCollider.onCollisionExit = () =>
            {
                badIsCollided = false;
                UpdateCollisions();
            };
        }
    }

    private void UpdateCollisions()
    {
        if (goodIsCollided && badIsCollided)
        {
            Debug.Log("Beginning countdown...");

            Countdown.Instance.BeginCountdown(() =>
            {
                if (triggerThunder != null)
                {
                    SpawnNewBoxes();
                }
                else
                {
                    Debug.LogError("FATAL: TriggerThunder is null.");
                }
            });
        }
        else
        {
            Debug.Log("Stopping countdown...");

            Countdown.Instance.StopCountdown();
        }
    }

    public void SpawnNewBoxes()
    {
       triggerThunder.Activate();
       FallingObjectSpawner.Activate();
       
       Rain.SetActive(true);
    }
}