﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowlyGoDown : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.0001f, this.transform.position.z);
    }
}
