using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    public GameObject key;
    public AudioClip op;
    public AudioSource audiosource;

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
        if (collision.gameObject.tag == "Player" && key.GetComponent<Key>().active == false)
        {
            audiosource.PlayOneShot(op);
            StartCoroutine(Open());
        }
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
