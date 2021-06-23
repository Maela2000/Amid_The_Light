using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool active;
    public AudioClip take;
    public AudioSource audiosource;

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
        if (collision.gameObject.tag == "Player" && active == true)
        {
            audiosource.PlayOneShot(take);
            StartCoroutine(Kept());
            active = false;
        }
    }

    IEnumerator Kept()
    {
        yield return new WaitForSeconds(0.2f);
        sprite.color = new Color(0.25f, 0.25f, 0.25f, 0);
    }
}
