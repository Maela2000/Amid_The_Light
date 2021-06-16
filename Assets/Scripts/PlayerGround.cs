using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private bool IsGrounded = false;
    [SerializeField]
    private float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space) && player.GetComponent<PlayerMove>().isOmbre == false)
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            //animator.SetBool("IsGrounded", false);
            IsGrounded = false;
            if(player.GetComponent<PlayerMove>().isJumpR = true)
            {

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "ground"))
        {
            IsGrounded = true;
            //animator.SetBool("IsGrounded", true);
        }
    }
    }
