using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public static SoundsManager Instance
    {
        get
        {
            if (instance == null) instance = new GameObject ("GameManager").AddComponent<SoundsManager>();
            return instance;
        }
    }
    void Awake()
    {
        if(instance)
            DestroyImmediate(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad (gameObject);
        }
    }
    public static SoundsManager instance = null;
}

