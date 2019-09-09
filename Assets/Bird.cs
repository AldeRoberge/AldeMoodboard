using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private float _speed = 0.002f;

    public void Start()
    {
        float scale = Random.Range(0.05f, 0.20f);

        _speed = scale / 5;

        this.gameObject.transform.localScale = new Vector3(scale, scale);
        
        Invoke(nameof(Run), 10.0f);
    }

    private void Run()
    {
        Destroy(this);
    }

    void Update()
    {
        //Go up and left
        transform.position = new Vector3(transform.position.x - _speed, transform.position.y + _speed,
            transform.position.z);
    }
}