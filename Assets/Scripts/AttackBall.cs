using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed;
    public float speed;

    Quaternion rotateToTarget;
    Vector3 dir;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        if (target == GameObject.FindGameObjectWithTag("Player"))
        {
            StartCoroutine("Homing");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * speed * Time.deltaTime);
        Physics2D.IgnoreLayerCollision(11, 10, true);
        Physics2D.IgnoreLayerCollision(10, 10, true);
    }

     IEnumerator Homing()
     {
        Debug.Log("homming");
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        dir = (target.transform.position - transform.position).normalized;
         float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
         rotateToTarget = Quaternion.AngleAxis(angle, Vector3.forward);
         transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);

         rb.velocity = new Vector2(dir.x * 2, dir.y * 2);
         yield return new WaitForSeconds(2f);
         StartCoroutine("droit");
         //yield return null;
     }

     IEnumerator droit()
     {
        Debug.Log("droit");
        transform.Translate(Vector3.left * speed * Time.deltaTime);
       yield return new WaitForSeconds(8f);
        Destroy(gameObject);
         //yield return null;
     }

}
