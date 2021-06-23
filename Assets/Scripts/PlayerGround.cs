using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGround : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    private Rigidbody2D rigidbody2d;
    public bool IsGrounded = false;
    public AudioSource audioRun;
    public float jumpVelocity;
    public AudioClip jumpD;
    public AudioSource audiosource;
    public float jumping =0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space) && player.GetComponent<PlayerMove>().isOmbre == false)
        {
            audiosource.PlayOneShot(jumpD);
            StartCoroutine(Jump());
        }

        if (player.GetComponent<PlayerMove>().isJumpR == 0)
        {
            player.GetComponent<PlayerMove>().JumpRight();
        }

        if (IsGrounded == true)
        {
            player.GetComponent<PlayerMove>().StopJumpRight();
            player.GetComponent<PlayerMove>().StopJumpLeft();
            player.GetComponent<PlayerMove>().isJump = 0;
            jumping = 0;
        }

        if (player.GetComponent<PlayerMove>().isJump == 1)
        {
            player.GetComponent<PlayerMove>().StopJumpLeft();
            player.GetComponent<PlayerMove>().JumpRight();
        }

        else if (player.GetComponent<PlayerMove>().isJump == -1)
        {
            player.GetComponent<PlayerMove>().StopJumpRight();
            player.GetComponent<PlayerMove>().JumpLeft();
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.1f);
        rigidbody2d.velocity = Vector2.up * jumpVelocity;
        IsGrounded = false;
        jumping = 1;

        if (player.GetComponent<PlayerMove>().isJumpR == 1)
        {
            player.GetComponent<PlayerMove>().JumpRight();
        }

        if (player.GetComponent<PlayerMove>().isJumpR == -1)
        {
            player.GetComponent<PlayerMove>().JumpLeft();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.tag == "ground"))
        {
            IsGrounded = true;
            Debug.Log("ground");
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            IsGrounded = false;
        }
    }
}
