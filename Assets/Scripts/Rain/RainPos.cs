using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainPos : MonoBehaviour
{
    private Transform player;
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(player.position.x, player.position.y+10, transform.position.z);
    }
}
