using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float health;
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
    private Transform target;

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
        {
            GetComponent<SpriteRenderer>().flipX = xPos < 0;
        }

        if (Input.GetKey(KeyCode.B))
        {
            health = 0;
        }

        if(xPos==0)
        {
            animator.SetBool("RunRight", false);
        }

        animator.SetFloat("Speed", (Mathf.Abs(xPos) * speed));

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //animator.SetBool("RunRight", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            animator.SetBool("RunRight", false);
        }
        if (Input.GetKey(KeyCode.UpArrow) && isShadow==true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            animator.SetBool("RunRight", false);
        }
        if (Input.GetKey(KeyCode.DownArrow) && isShadow==true)
        {
             transform.Translate(Vector2.down * speed * Time.deltaTime);
             animator.SetBool("RunRight", false);
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
            IsGrounded = true;
        }

        FollowTarget();
    }
    private void FollowTarget()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);//The enemy follow the player
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground" || other.gameObject.tag == "platform")
        {
            IsGrounded = true;
            //animator.SetBool("IsGrounded", true);
        }
        if(other.gameObject.tag == "light")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "End")
        {
            GameplayManager.Instance.dashBar.SetActive(false);
            GameplayManager.Instance.ShowWin();
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground"|| other.gameObject.tag == "platform")
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
        if (collision.gameObject.tag == "platform")
        {
            target = collision.transform;
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
        if (collision.gameObject.tag == "platform")
        {
            target = null;
        }
    }
}
