﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public GameObject coreBroken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player"&& Input.GetKeyDown("c")) 
        {

            Debug.Log("c");
            Instantiate(coreBroken, transform.position, transform.rotation);
            Destroy(gameObject);
        }  
    }
}
