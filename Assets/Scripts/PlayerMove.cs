using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float health;
    public Animator animator;
    public float time;
    public bool isDash;
    public Collider2D colliB;
    public GameObject colliBF;
    public Collider2D colliC;
    public Collider2D colliCB;


    [SerializeField]
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private bool IsGrounded = false;
    [SerializeField]
    private float jumpVelocity;
    private float xPos;
    private bool isShadow=false;
    public bool isOmbre= false;
    private Transform target;
    private bool isLeft;
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
            animator.SetBool("RunLeft", false);
        }

        animator.SetFloat("Speed", (Mathf.Abs(xPos) * speed));

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("RunRight", true);
            animator.SetBool("RunLeft", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            animator.SetBool("RunRight", true);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", true);
        }
            if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) && isOmbre==true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            animator.SetBool("RunRight", false);
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && isOmbre==true)
        {
             transform.Translate(Vector2.down * speed * Time.deltaTime);
             animator.SetBool("RunRight", false);
        }
        
        /*if (IsGrounded == true &&  Input.GetKeyDown(KeyCode.Space) && isOmbre==false)
        {

            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            Debug.Log("Jump");
            //animator.SetBool("IsGrounded", false);
            IsGrounded = false;
        }*/
        if(health<=0)
        {
            Destroy(gameObject);
        }
        /*if(Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 10;
        }*/

        /*if(isDash==false)
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
                speed = speed * 3;
                animator.SetBool("Dash", true);
            }
        }

        IEnumerator Dash()
        {
            yield return new WaitForSeconds(0.5f);
            speed = speed / 3;
            animator.SetBool("Dash", false);
            isDash = false;
            time = 0;
            IsGrounded = true;
        }*/

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
        if(other.gameObject.tag == "light")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "End")
        {
            GameplayManager.Instance.isFinish = true;
            isDash = false;
            GameplayManager.Instance.ShowWin();
        }
    }
    /*private void OnCollisionExit2D(Collision2D other)
    {
        if ((other.gameObject.tag == "ground"))
        {
            IsGrounded = false;
        }
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Shad();
            /*if (Input.GetKeyDown(KeyCode.X))
            {
                isShadow = !isShadow;
                ShadowMode();
            }*/
           if (Input.GetKeyDown("x"))
            {
                Physics2D.IgnoreLayerCollision(8, 9, true);
                Physics2D.IgnoreLayerCollision(8, 10, true);
                animator.SetBool("Shadow", true);
                rigidbody2d.gravityScale = 0;
                isOmbre = true;
                colliB.enabled = false;
                colliBF.SetActive(false);
                colliC.enabled = true;
            }

            if (Input.GetKeyDown("v"))
            {
                Physics2D.IgnoreLayerCollision(8, 9, false);
                Physics2D.IgnoreLayerCollision(8, 10, false);
                animator.SetBool("Shadow", false);
                rigidbody2d.gravityScale = 1;
                isOmbre = false;
                colliB.enabled = true;
                colliBF.SetActive(true);
                colliC.enabled = false;
            }
        }
        if (collision.gameObject.tag == "Wall2")
        {
            if (Input.GetKeyDown("x"))
            {
                Physics2D.IgnoreLayerCollision(8, 9, true);
                Physics2D.IgnoreLayerCollision(8, 10, true);
                animator.SetBool("Shadow", true);
                isOmbre = true;
                colliB.enabled = false;
                colliBF.SetActive(false);
                colliC.enabled = true;
            }

            if (Input.GetKeyDown("v"))
            {
                Physics2D.IgnoreLayerCollision(8, 9, false);
                Physics2D.IgnoreLayerCollision(8, 10, false);
                animator.SetBool("Shadow", false);
                isOmbre = false;
                colliB.enabled = true;
                colliBF.SetActive(true);
                colliC.enabled = false;
            }
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
            isOmbre = false;
            colliB.enabled = true;
            colliBF.SetActive(true);
            colliC.enabled = false;
            /*if (isShadow == true)
            {
                isShadow = !isShadow;
            }*/
            isShadow = false;
        }

        if (collision.gameObject.tag == "Wall2")
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(8, 10, false);
            animator.SetBool("Shadow", false);
            isOmbre = false;
            colliB.enabled = true;
            colliBF.SetActive(true);
            colliC.enabled = false;
            isShadow = false;
        }
    }

    void Shad()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isShadow = !isShadow;
            ShadowMode();
        }
    }
    void ShadowMode()
    {
        if (isShadow==true)
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Physics2D.IgnoreLayerCollision(8, 10, true);
            animator.SetBool("Shadow", true);
            rigidbody2d.gravityScale = 0;
            isOmbre = true;
            colliB.enabled = false;
            colliC.enabled = true;
        }

        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(8, 10, false);
            animator.SetBool("Shadow", false);
            rigidbody2d.gravityScale = 1;
            isOmbre = false;
            colliB.enabled = true;
            colliC.enabled = false;
        }
    }
}
