﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserAttak : MonoBehaviour
{ private float y=0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (y <= 49 && y >= 0)
        {
            transform.Rotate(0, 0, 1.5f);
            y = y+1;
        }

    }
}
