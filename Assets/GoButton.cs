using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButton : MonoBehaviour
{

    public GoodBadManager GoodBadManager;
    
    public ZoomOut ZoomOut;
    
    public void Run()
    {
        
        //Hides the button
        this.gameObject.SetActive(false);
        
        //Zoom the camera out
        ZoomOut.enabled = true;
        
        Countdown.Instance.BeginCountdown(() =>
        {
            GoodBadManager.SpawnNewBoxes();
        });
    }
}
