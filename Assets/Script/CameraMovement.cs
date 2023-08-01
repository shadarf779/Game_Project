using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{



    private Transform player;

    private Vector3 temPos;
    
    [SerializeField]
    private float MinX, MaxX; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        temPos = transform.position;
        temPos.y = player.position.y + 3;
        temPos.x = player.position.x;
        if (temPos.x<MinX)
        {
            temPos.x = MinX;
        }
        if (temPos.x>MaxX)
        {
            temPos.x = MaxX;
        }
        transform.position = temPos;

    }
}
