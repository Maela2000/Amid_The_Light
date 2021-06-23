using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    public bool active;
    public GameObject indic;
    public GameObject lum;
    public GameObject sha;
    public GameObject actionne;
    public GameObject actionner;
    public AudioClip act;
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
            indic.SetActive(true);

            if ((Input.GetKeyDown("c")))
            {
                audiosource.PlayOneShot(act);
                active = false;
                StartCoroutine(Action());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && active == true)
        {
            indic.SetActive(false);
        }
    }
    IEnumerator Action()
    {
        yield return new WaitForSeconds(0.3f);
        actionne.SetActive(false);
        actionner.SetActive(true);
        indic.SetActive(false);
        StartCoroutine(Cam());
    }

    IEnumerator Cam()
    {
        yield return new WaitForSeconds(0.3f);
        GameplayManager.Instance.levier = number;
        StartCoroutine(Action2());
    }

    IEnumerator Action2()
    {
        yield return new WaitForSeconds(0.3f);
        lum.SetActive(false);
        sha.SetActive(true);
    }
}
