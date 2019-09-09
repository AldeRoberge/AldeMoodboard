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

    public TMP_Text badLabel;
    public TMP_Text goodLabel;

    public GameObject Rain;

    bool badIsCollided;
    bool goodIsCollided;

    private ChoiceContainer selectedLeftChoice;
    private ChoiceContainer selectedRightChoice;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading FallingObjectSpawner");

        FallingObjectSpawner = gameObject.AddComponent<FallingBoxesSpawner>();
        FallingObjectSpawner.infoText = infoText;
        FallingObjectSpawner.badLabel = badLabel;
        FallingObjectSpawner.goodLabel = goodLabel;

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


            if (!Countdown.Instance.IsAlreadyCounting)
            {
                Countdown.Instance.BeginCountdown(() =>
                {
                    if (triggerThunder != null)
                    {
                        ShowAnswer();

                        Invoke(nameof(SpawnNewBoxes), 1.0f);
                    }
                    else
                    {
                        Debug.LogError("FATAL: TriggerThunder is null.");
                    }
                });
            }
        }
        else
        {
            if (Countdown.Instance.IsAlreadyCounting)
            {
                Debug.Log("Stopping countdown...");

                Countdown.Instance.StopCountdown();
            }
        }
    }

    private void ShowAnswer()
    {
        selectedLeftChoice.parent.SetActive(false);
        selectedRightChoice.parent.SetActive(false);


        if (selectedLeftChoice.choice.isRight)
        {
            OkayOrNotPanel.Instance.SetIsRight(true);
            BirdSpawner.Instance.SpawnBirds(5);

            PlaySoundEffect.Instance.Cheers();

            Rain.SetActive(false);
            triggerThunder.Deactivate();
        }
        else
        {
            Rain.SetActive(true);
            triggerThunder.Activate();

            OkayOrNotPanel.Instance.SetIsRight(false);
        }

        Reset();
    }

    private void Reset()
    {
        selectedRightChoice = null;
        selectedLeftChoice = null;

        goodCollider.SetLightActiveTo(false);
        badCollider.SetLightActiveTo(false);

        badIsCollided = false;
        goodIsCollided = false;
    }

    public void SpawnNewBoxes()
    {
        FallingObjectSpawner.Activate();
    }
}