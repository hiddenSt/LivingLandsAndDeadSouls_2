using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DownButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    AudioSource Audio;
    GameObject player;
    PlayerController playerController;
    void Start()
    {
        Audio=GameObject.Find("AudioManager").GetComponent<AudioSource>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }
    public virtual void OnPointerDown(PointerEventData ped)
    {
        print("DownPointerDown");
        playerController.Direction = 0;
        Audio.Play();
    }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        Audio.Stop();
        print("DownPointerUp");
    }
}

