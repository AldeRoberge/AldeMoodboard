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
    
    private ChoiceContainer selectedLeftChoice;
    private ChoiceContainer selectedRightChoice;

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
            goodCollider.onCollisionEnter = (e) =>
            {
                selectedLeftChoice = e;
                goodIsCollided = true;
                UpdateCollisions();
            };
            goodCollider.onCollisionExit = () =>
            {
                selectedLeftChoice = null;
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
            badCollider.onCollisionEnter = (e) =>
            {
                selectedRightChoice = e;
                badIsCollided = true;
                UpdateCollisions();
            };
            badCollider.onCollisionExit = () =>
            {
                selectedRightChoice = null;
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
                    ShowAnswer();
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

    private void ShowAnswer()
    {
        
        
        selectedLeftChoice.parent.SetActive(false);
        selectedRightChoice.parent.SetActive(false);
        
        
        if (selectedLeftChoice.choice.isRight)
        {
            OkayOrNotPanel.Instance.SetIsRight(true);
        }
        else
        {
            OkayOrNotPanel.Instance.SetIsRight(false);
        }
    }

    public void SpawnNewBoxes()
    {
        //Rain.SetActive(true);
        //triggerThunder.Activate();
        
        FallingObjectSpawner.Activate();

        
    }
}