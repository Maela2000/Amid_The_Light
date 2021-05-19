using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public SpriteRenderer sprite;

    [SerializeField]
    private Rigidbody2D rigidbody2d;
    [SerializeField]
    private bool IsGrounded = false;
    [SerializeField]
    private float jumpVelocity;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (IsGrounded == true && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)))
        {

            rigidbody2d.velocity = Vector2.up * jumpVelocity;
            Debug.Log("Jump");
            //animator.SetBool("IsGrounded", false);
            IsGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            IsGrounded = true;
            Debug.Log("IsGrounded");
            //animator.SetBool("IsGrounded", true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" && Input.GetKey("x"))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            Physics2D.IgnoreLayerCollision(8, 10, true);
            sprite.color = new Color(0, 0, 0, 1);
        }
        if (collision.gameObject.tag == "Levier")
        {
            if(Input.GetKey(KeyCode.C))
            {
                Debug.Log("pushc");
                GameplayManager.Instance.levier++;
                Physics2D.IgnoreLayerCollision(8, 11, true);
                Debug.Log("levier");
            }
        }
    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            Physics2D.IgnoreLayerCollision(8, 10, false);
            sprite.color = new Color(1, 1, 1, 1);
        }
    }
}
