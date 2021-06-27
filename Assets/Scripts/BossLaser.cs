using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser : MonoBehaviour
{
    public bool instaLaser;
    public float speed = 1;
    public GameObject laser;
    [SerializeField]
    private bool right = true;
    [SerializeField]
    private bool left = false;
    public Vector3 offset;

    public Vector3 offsetBis;
    public GameObject alerte;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnLaser", 10f, 10f);
        
    }

    void SpawnLaser()
    {
        instaLaser = true;
        StartCoroutine("Stop");
        StartCoroutine("Laser");
        alerte.SetActive(true);
    }
    IEnumerator Laser()
    {
        yield return new WaitForSeconds(1f);
        if (GameplayManager.Instance.switchBoss == false)
        {
            Instantiate(laser, transform.position + offsetBis, transform.rotation);
        }
        else
        {
            Instantiate(laser, transform.position + offset, transform.rotation);
        }
        
    }

    IEnumerator Stop()
    {
        speed = 0;
        yield return new WaitForSeconds(4f);
        speed = 1;
        alerte.SetActive(false);
        instaLaser = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(right == true && left == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (right == false && left == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "mark1")
        {
            right = true;
            left = false;
        }
        if (other.tag == "mark2")
        {
            
            left = true;
            right = false;
        }
    }
}
