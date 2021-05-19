using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyTest : MonoBehaviour
{
    public float Enemyspeed = 0.3f;
    private Transform target;

    public Transform Target1 { get => target; set => target = value; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
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
        }
    }
    private void OnTriggerExit2D(Collider2D collision)//the enemy stop follow the player when the player exit on the collider's enemy
    {
        if (collision.tag == "Player")
        {
            target = null;
        }
    }
}
