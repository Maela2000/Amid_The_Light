using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsClign : MonoBehaviour
{
    public bool isAlum;
    public Collider2D collider;
    public SpriteRenderer sprite;
    public float n;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlum)
        {
            collider.enabled = true;
            sprite.enabled = true;
            StartCoroutine(Cligne());
        }
        else
        {
            collider.enabled = false;
            sprite.enabled = false;
            StartCoroutine(Cligne2());
        }

        
        
    }

    IEnumerator Cligne()
    {
            yield return new WaitForSeconds(2f);
            isAlum = false;
    }
    IEnumerator Cligne2()
    {
        yield return new WaitForSeconds(3f);
        isAlum = true;
    }
}
