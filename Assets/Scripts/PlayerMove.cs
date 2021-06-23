using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float health;
    public Animator animator;
    //public float time;
    //public bool isDash;
    public AudioClip shadow;
    public AudioClip stopshadow;
    public AudioSource AudioRun;
    public AudioSource audiosource;

    public Collider2D colliB;
    public GameObject colliBF;
    public Collider2D colliC;


    [SerializeField]
    private Rigidbody2D rigidbody2d;
    public bool isOmbre= false;
    private Transform target;
    private bool isLeft;
    public bool isShadowMode = false;
    public float isJumpR=0;
    public float isJump= 0;
    public float isJumpL;
    public float run;
    public float ts;

    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            health = 0;
        }

        #region movements
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            isJumpR = 1;
            if(colliBF.GetComponent<PlayerGround>().IsGrounded==false)
            {
                animator.SetBool("RunRight", false);
                isJump = 1;
                run = 0;
            }
            if (colliBF.GetComponent<PlayerGround>().IsGrounded == true)
            {
                animator.SetBool("RunRight", true);
                isJump = 2;
                run = 1;
            }
        }

        if(run==0)
        {
            AudioRun.Play();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("RunRight", false);
            isJumpR = 1;
            run = 0;
        }
            
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            isJumpR = -1;

            if (colliBF.GetComponent<PlayerGround>().IsGrounded == false)
            {
                animator.SetBool("RunLeft", false);
                isJump = -1;
                run = 0;
            }
            if (colliBF.GetComponent<PlayerGround>().IsGrounded == true)
            {
                animator.SetBool("RunLeft", true);
                isJump = 2;
                run = 1;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("RunLeft", false);
            isJumpR = -1;
            run = 0;
            isJumpL = 1;
        }
            
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z)) && isOmbre==true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            animator.SetBool("RunRight", false);
            animator.SetBool("RunLeft", false);
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && isOmbre==true)
        {
             transform.Translate(Vector2.down * speed * Time.deltaTime);
             animator.SetBool("RunRight", false);
        }
        #endregion

        #region static left
        if (isJumpL == 1 && isJump == 0 && isJumpR==-1 && run==0)
        {
            animator.SetBool("StaticLeft", true);
        }

        if (isJumpL == 1 && isJump == 0 && isJumpR == -1 && run == 0 && isOmbre==false)
        {
            animator.SetBool("StaticLeft", true);
        }

        if (isJump == 0 && isJumpR != -1)
        {
            animator.SetBool("StaticLeft", false);
        }

        if (isJump != 0 && isJumpR != -1)
        {
            animator.SetBool("StaticLeft", false);
        }

        if (isJump != 0 && isJumpR == -1)
        {
            animator.SetBool("StaticLeft", false);
        }

        if (isJumpL == 1 && colliBF.GetComponent<PlayerGround>().jumping == 1)
        {
            animator.SetBool("StaticLeft", false);
            JumpLeft();
        }

        else if (isJumpL == 1 && colliBF.GetComponent<PlayerGround>().jumping == 1 && isOmbre==true)
        {
            StopJumpLeft();
            animator.SetBool("Shadow", true);
        }

        if (isJumpR == -1 && run==1)
        {
            animator.SetBool("StaticLeft", false);
        }

        if (isJumpL == 1 && isJumpR == -1 && run == 1 && isOmbre == true && colliBF.GetComponent<PlayerGround>().jumping == 0)
        {
            animator.SetBool("StaticLeft", false);
            animator.SetBool("RunLeft", false);
            animator.SetBool("Shadow", true);
            animator.SetBool("JumpL", false);
        }

        if (isJumpL == 1 && isJumpR == -1 && run == 1 && isOmbre == false && colliBF.GetComponent<PlayerGround>().jumping == 0)
        {
            animator.SetBool("StaticLeft", false);
            animator.SetBool("RunLeft", true);
            animator.SetBool("Shadow", false);
        }

        if (isJumpL == 1 && isJumpR == -1 && run == 0 && isOmbre == false && colliBF.GetComponent<PlayerGround>().jumping == 0)
        {
            animator.SetBool("StaticLeft", true);
            animator.SetBool("RunLeft", false);
            animator.SetBool("Shadow", false);
        }

        if (isJumpR != -1 && run == 1)
        {
            animator.SetBool("StaticLeft", false);
        }

        if (isJumpR != -1 && run==0)
        {
            animator.SetBool("StaticLeft", false);
        }
        #endregion

        if (health<=0)
        {
            Destroy(gameObject);
        }
        #region dash com
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
        #endregion
    }
    #region jump
    public void JumpRight()
    {
        animator.SetBool("JumpR", true);
    }
    public void StopJumpRight()
    {
        animator.SetBool("JumpR", false);
    }

    public void JumpLeft()
    {
        animator.SetBool("JumpL", true);
    }
    public void StopJumpLeft()
    {
        animator.SetBool("JumpL", false);
    }
    #endregion


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "light")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "End")
        {
            GameplayManager.Instance.isFinish = true;
            //isDash = false;
            GameplayManager.Instance.ShowWin();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (Input.GetKey("v"))
            {
                 ShadowT();
                if (ts == 0)
                {
                    audiosource.PlayOneShot(shadow);
                    ts = 1;
                }
            }

            else
            {
                ShadowF();
            }
        }
    

        if (collision.gameObject.tag == "Wall2")
        {
            if (Input.GetKey("v"))
            {
                Physics2D.IgnoreLayerCollision(8, 9, true);
                Physics2D.IgnoreLayerCollision(8, 10, true);
                animator.SetBool("Shadow", true);
                rigidbody2d.gravityScale = 1;
                isOmbre = true;
                colliB.enabled = false;
                colliBF.SetActive(false);
                colliC.enabled = true;
                StopJumpLeft();
                StopJumpRight();
                isJump = 0;
                isJumpR = 0;
                if (ts == 0)
                {
                    audiosource.PlayOneShot(shadow);
                    ts = 1;
                }
            }

            else 
            {
                ShadowF();
            }
        }

        if(collision.gameObject.tag == "Shadow")
        {
            isShadowMode = true;
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

            if (ts == 1)
            {
                audiosource.PlayOneShot(stopshadow);
                ts = 0;
            }
        }

        if (collision.gameObject.tag == "Shadow")
        {
            isShadowMode = false;
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
            isShadowMode = false;
            if (ts == 1)
            {
                audiosource.PlayOneShot(stopshadow);
                ts = 0;
            }
        }
    }

    void ShadowT()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
        animator.SetBool("Shadow", true);
        rigidbody2d.gravityScale = 0;
        isOmbre = true;
        colliB.enabled = false;
        colliBF.SetActive(false);
        colliC.enabled = true;
        StopJumpLeft();
        StopJumpRight();
        isJump = 0;
        isJumpR = 0;
    }

    void ShadowF()
    {
        Physics2D.IgnoreLayerCollision(8, 9, false);
        Physics2D.IgnoreLayerCollision(8, 10, false);
        animator.SetBool("Shadow", false);
        rigidbody2d.gravityScale = 1;
        isOmbre = false;
        colliB.enabled = true;
        colliBF.SetActive(true);
        colliC.enabled = false;
        if (ts == 1)
        {
            audiosource.PlayOneShot(stopshadow);
            ts = 0;
        }
    }
}
