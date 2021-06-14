using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private bool open=true;
    public GameObject active;
    public GameObject deactive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && open == true /*&& */)
        {
            if (Input.GetKeyDown("c"))
            {
                open = false;
                active.SetActive(false);
                deactive.SetActive(true);
            }
        }
    }
}
