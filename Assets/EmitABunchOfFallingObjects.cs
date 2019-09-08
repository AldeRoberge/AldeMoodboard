using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitABunchOfFallingObjects : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    
    
    private float minRespawn = 1;
    private float maxRespawn = 2;

    void Start()
    {
        Invoke (nameof(YourMethod), (Random.Range(minRespawn, maxRespawn)));
    }
 
    void YourMethod()
    {
        float delay = Random.Range (minRespawn, maxRespawn);
        //Do stuff

        Object.Instantiate(fallingObjectPrefab);
        fallingObjectPrefab.transform.parent = this.gameObject.transform;
        
        Invoke (nameof(YourMethod), delay);
    }
    
    
    
    
    
}