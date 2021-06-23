﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public bool instaLaser;
    private float speed = 3;
    public GameObject laser;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLaser", 10f, 3f);
    }

    void SpawnLaser()
    {
        instaLaser = true;
        StartCoroutine("Stop");
        Instantiate(laser, transform.position, transform.rotation);
    }

    IEnumerator Stop()
    {
        speed = 0;
        yield return new WaitForSeconds(2f);
        speed = 3;
        instaLaser = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}