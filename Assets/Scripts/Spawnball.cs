using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnball : MonoBehaviour
{
    public GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBullet", 1.0f, 0.6f);
        
    }
    void SpawnBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
