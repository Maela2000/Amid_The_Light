using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{ 
    bool death = false; 
    public GameObject coreBroken;
    public GameObject indic;
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
        if (collision.gameObject.tag == "Player" && death == false) 
        {
            indic.SetActive(true);

            if (Input.GetKeyDown("c"))
            {
                death = true;
                GameplayManager.Instance.coreDie = GameplayManager.Instance.coreDie + 1;
                Debug.Log("c");
                Instantiate(coreBroken, transform.position, transform.rotation);
                Destroy(gameObject);
                indic.SetActive(false);
            }
        }  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && death == false)
        {
            indic.SetActive(false);
        }
    }
}
