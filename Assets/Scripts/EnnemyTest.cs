using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTest : MonoBehaviour
{
    public GameObject player;

    public float Enemyspeed;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    public float xPos;
    private Transform target;
    public Transform[] moveSpots;//creation of gameobject which will serve as indicators
    public GameObject light1;
    public GameObject light2;

    public Transform Target1 { get => target; set => target = value; }

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {

        if (xPos != 0) //Rotate player sprite to the left
        {
            GetComponent<SpriteRenderer>().flipX = xPos < 0;
        }

        if (xPos < 0)
        {
            light1.SetActive(false);
            light2.SetActive(true);
        }

        if (xPos >= 0)
        {
            light1.SetActive(true);
            light2.SetActive(false);
        }

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

        if (player.GetComponent<PlayerMove>().isDeath==true)
        {
            Enemyspeed = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Spot")
        {
          xPos = -1;
        }
        if (collision.gameObject.tag == "Spot2")
        {
            xPos = 1;
        }
    }
}
