using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    public bool active;
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
        if (collision.gameObject.tag == "Player" && active == true && Input.GetKeyDown("c"))
        {
            Debug.Log("pushc");
            GameplayManager.Instance.levier++;
            active = false;
        }
    }
}
