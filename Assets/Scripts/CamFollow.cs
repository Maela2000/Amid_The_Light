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
        if (player.position.x <= posXMax && player.position.x >= posXMin && player.position.y <= posYMax && player.position.y >= posYMin)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
    }        
}
