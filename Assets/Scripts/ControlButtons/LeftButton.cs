using UnityEngine;
using UnityEngine.EventSystems;

namespace ControlButtons {

  public class LeftButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    AudioSource Audio;
    GameObject player;
    PlayerController playerController;

    void Start() {
      Audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
      player = GameObject.Find("Player");
      playerController = player.GetComponent<PlayerController>();
    }

    public virtual void OnPointerDown(PointerEventData ped) {
      print("LeftPointerDown");
      playerController.needToGo = true;
      playerController.direction = 3;
      Audio.Play();
    }

    public virtual void OnPointerUp(PointerEventData ped) {
      Audio.Stop();
      playerController.needToGo = false;
      print("LeftPointerUp");
    }
  }
}
