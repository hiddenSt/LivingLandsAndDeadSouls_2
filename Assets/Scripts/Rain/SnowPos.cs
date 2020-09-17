using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowPos : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var sh = ps.shape;
        sh.scale = new Vector3(Menu.ParameterManager.Instance.MapSizeVector.x*18, 1, 1);

    }

    private Transform player;
    void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(0, Menu.ParameterManager.Instance.MapSizeVector.y * 18, transform.position.z);
    }
}
