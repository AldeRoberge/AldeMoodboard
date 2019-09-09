using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownToGameBegin : MonoBehaviour
{

    public GoodBadManager GoodBadManager;
    
    public ZoomOut ZoomOut;
    
    public void Run()
    {
        
        //Spawns a bird
        BirdSpawner.Instance.SpawnBirds(8);
        
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
