using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    public GameObject laser;
    public bool instaLaser;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnLaser", 10f, 3f);
    }

    void spawnLaser()
    {
        instaLaser = true;
        StartCoroutine("Stop");
        Instantiate(laser, transform.position, transform.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
