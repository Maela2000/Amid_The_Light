using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float health;
    //public GameObject spriteNormal;
    //public GameObject spriteX;
    public float dashforce;
    public float startDashTimer;
    public Animator animator;
    public float time;
    public bool isDash;

    [SerializeField]
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private bool IsGrounded = false;
    [SerializeField]
    private float jumpVelocity;
    private float xPos;
    private bool isShadow=false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xPos = Input.GetAxis("Horizontal");
        if (xPos != 0) //Rotate player sprite to the left
        { GetComponent<SpriteRenderer>().flipX = xPos < 0;
        }

        if (Input.GetKey(KeyCode.B))
        {
            health = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isShadow==true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) && isShadow==true)
        {
             transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (IsGrounded == true &&  Input.GetKeyDown(KeyCode.Space))
        {

            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            Debug.Log("Jump");
            //animator.SetBool("IsGrounded", false);
            IsGrounded = false;
        }
        if(health<=0)
        {
            Destroy(gameObject);
        }
        /*if(Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 10;
        }*/

        if(isDash==false)
        {
            time += Time.deltaTime;
        }
        if(time >= 10)
        {
            isDash = true;
        }

        if (Input.GetKeyDown(KeyCode.D) && xPos != 0)
        {
            if (isDash && isShadow == false)
            {
                StartCoroutine(Dash());
                speed = speed * 10;
                animator.SetBool("Dash", true);
            }
        }

        IEnumerator Dash()
        {
            yield return new WaitForSeconds(0.5f);
            speed = speed / 10;
            animator.SetBool("Dash", false);
            isDash = false;
            time = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            IsGrounded = true;
            //animator.SetBool("IsGrounded", true);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            IsGrounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" && Input.GetKey("x"))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Physics2D.IgnoreLayerCollision(8, 10, true);
            animator.SetBool("Shadow", true);
            rigidbody2d.gravityScale = 0;
            isShadow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(8, 10, false);
            animator.SetBool("Shadow", false);
            rigidbody2d.gravityScale = 1;
            isShadow = false;
        }
    }
}
