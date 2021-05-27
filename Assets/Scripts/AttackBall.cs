using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBall : MonoBehaviour
{
    public GameObject target;
    public float rotationSpeed = 1f;
    public float speed;

    Quaternion rotateToTarget;
    Vector3 dir;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        //StartCoroutine("Homing");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* IEnumerator Homing()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotateToTarget = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);

        rb.velocity = new Vector2(dir.x * 2, dir.y * 2);
        new WaitForSeconds(2f);
        StartCoroutine("droit");
        return;
    }

    IEnumerator droit()
    {

    }*/

}
