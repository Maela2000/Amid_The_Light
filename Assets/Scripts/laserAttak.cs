using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserAttak : MonoBehaviour
{
    public float c;
    public float v;
    private float y;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        if (y <= c - 1 && y >= v)
        {
            transform.Rotate(0, 0, 1f);
            y = y + 1;
            if (y >= c)
            {
                Destroy(gameObject);
            }
        }
    }
}
