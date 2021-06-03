using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampadaire : MonoBehaviour
{
    private float x;
    private bool up = true;
    private bool down= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(x);
        if (x <= 89 && x >= 0 && (up == true))
        {
            transform.Rotate(0, 0, 1f);
            x = x + 1;
            if (x >= 90)
            {
                up = false;
                down = true;
            }
        }

        else if (x <= 90 && x >= 1 && (down == true))
            {
                transform.Rotate(0, 0, -1f);
                x = x - 1;
            if (x <= 0)
            {
                up = true;
                down = false;
            }
        }

    }
}
