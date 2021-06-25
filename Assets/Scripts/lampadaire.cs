using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampadaire : MonoBehaviour
{
    public GameObject player;

    private float x;
    public float c;
    public float v;
    public float b;
    private bool up = true;
    private bool down = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (x <= c - 1 && x >= v && (up == true))
        {
            transform.Rotate(0, 0, b);
            x = x + 1;
            if (x >= c)
            {
                up = false;
                down = true;
            }
        }

        else if (x <= c && x >= v + 1 && (down == true))
        {
            transform.Rotate(0, 0, -b);
            x = x - 1;
            if (x <= v)
            {
                up = true;
                down = false;
            }
        }
        if (player.GetComponent<PlayerMove>().isDeath == true)
        {
            x = 0;
            c = 0;
            v = 0;
        }
    }
}