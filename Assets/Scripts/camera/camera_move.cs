using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public int country;
    private Transform player;
    private int lastx;
    // Start is called before the first frame update
    void Start()
    {
        offset=new Vector2(Mathf.Abs(offset.x), offset.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getCoord();
    }

    void getCoord()
    {
        player=GameObject.FindGameObjectWithTag("Player").transform;
        transform.position=new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
