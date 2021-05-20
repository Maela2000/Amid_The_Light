using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    private bool follow = true;
    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (follow == true)
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
