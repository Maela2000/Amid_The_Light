using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public float posXMax;
    public float posXMin;
    public float posYMax;
    public float posYMin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   
        if (GameplayManager.Instance.levier == 0)
        {
            if (player.position.x <= posXMax && player.position.x >= posXMin && player.position.y <= posYMax && player.position.y >= posYMin)
            {
                transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
            }
        }

        if(GameplayManager.Instance.levier == 1)
        {
            player.GetComponent<PlayerMove>().speed = 0;
            transform.position = new Vector3(28.57f, 3.02f, -10);
            StartCoroutine(Move());
        }

        if (GameplayManager.Instance.levier == 2)
        {
            player.GetComponent<PlayerMove>().speed = 0;
            transform.position = new Vector3(109.92f, 5.45f, -10);
            StartCoroutine(Move());
        }

        if (GameplayManager.Instance.levier == 3)
        {
            player.GetComponent<PlayerMove>().speed = 0;
            transform.position = new Vector3(36.01f, 0.76f, -10);
            StartCoroutine(Move());
        }

        if (GameplayManager.Instance.levier == 4)
        {
            player.GetComponent<PlayerMove>().speed = 0;
            transform.position = new Vector3(160.4f, 5f, -10);
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(1.5f);
        GameplayManager.Instance.levier = 0;
        player.GetComponent<PlayerMove>().speed = 5;
    }
}
