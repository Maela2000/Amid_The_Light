using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformers : MonoBehaviour
{
    public float Enemyspeed;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    public Transform[] moveSpots;//creation of gameobject which will serve as indicators

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Enemyspeed * Time.deltaTime);//the player random move between the different gameobjects
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
