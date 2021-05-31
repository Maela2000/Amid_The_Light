using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    public bool active;

    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
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
            sprite.color = new Color(0.25f, 0.25f, 0.25f, 1);
        }
    }
}
