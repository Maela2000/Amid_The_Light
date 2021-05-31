using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTest : MonoBehaviour
{
    public float Enemyspeed;
    private int randomSpot;
    private float waitTime;
    public float startWaitTime;
    private Transform target;
    public Transform[] moveSpots;//creation of gameobject which will serve as indicators
    public GameObject levier;

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
        float xPos = Input.GetAxis("Horizontal");
        /*transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, Enemyspeed * Time.deltaTime);//the player random move between the different gameobjects
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
        }*/
        FollowTarget();
        if (xPos != 0) //Rotate player sprite to the left
        { GetComponent<SpriteRenderer>().flipX = xPos < 0; }

        if(levier.GetComponent<LevierEnemy>().levierE == true)
        {
            Enemyspeed = 0;
        }
    }

    private void FollowTarget()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Enemyspeed * Time.deltaTime);//The enemy follow the player
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") //the enemy follow the player when the player enter on the collider's enemy
        {
            target = collision.transform;
            //Destroy(collision.gameObject);
        }
    }
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") //If the enemy touch boxcollider's player, it's destroy
        {
            Destroy(gameObject);
        }
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") //the enemy follow the player when the player enter on the collider's enemy
        {
            target = null;
            //Destroy(collision.gameObject);
        }
    }
}
