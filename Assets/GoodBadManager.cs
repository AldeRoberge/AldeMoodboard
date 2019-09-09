using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBadManager : MonoBehaviour
{
    public GoodOrBadDetector goodCollider;
    public GoodOrBadDetector badCollider;

    bool badIsCollided;
    bool goodIsCollided;

    // Start is called before the first frame update
    void Start()
    {
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
            Countdown.Instance.BeginCountdown();
        }
        else
        {
            Countdown.Instance.StopCountdown();
        }
    }

    
}