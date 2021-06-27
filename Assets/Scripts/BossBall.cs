using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBall : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private bool right = true;
    [SerializeField]
    private bool left = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (right == true && left == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (right == false && left == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "mark1")
        {
            right = true;
            left = false;
        }
        if (other.tag == "mark2")
        {

            left = true;
            right = false;
        }
    }
}
