using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchBoss : MonoBehaviour
{ public GameObject swit;
    public bool Switch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Switch == false)
        {
            swit.transform.Rotate(0, 180, 0);
            Switch = true;
            GameplayManager.Instance.switchBoss = true;
        }
    }
}
