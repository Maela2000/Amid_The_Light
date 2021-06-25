using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool active;
    public AudioClip take;
    public AudioSource audiosource;
    public float number;

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
            StartCoroutine(Cam());
            active = false;
        }
    }

    IEnumerator Cam()
    {
        yield return new WaitForSeconds(0.3f);
        GameplayManager.Instance.levier = number;
        StartCoroutine(Kept());
    }

    IEnumerator Kept()
    {
        yield return new WaitForSeconds(0.1f);
        sprite.color = new Color(0.25f, 0.25f, 0.25f, 0);
    }
}
