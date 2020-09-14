using UnityEngine;
using UnityEngine.EventSystems;

namespace ControlButtons {
  
  public class DownButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    void Start() {
      _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
      _player = GameObject.Find("Player");
      _playerController = _player.GetComponent<PlayerController>();
    }

    public virtual void OnPointerDown(PointerEventData ped) {
      print("DownPointerDown");
      _playerController.needToGo = true;
      _playerController.direction = 0;
      _audio.Play();
    }

    public virtual void OnPointerUp(PointerEventData ped) {
      _audio.Stop();
      _playerController.needToGo = false;
      print("DownPointerUp");
    }
    
    private AudioSource _audio;
    private GameObject _player;
    private PlayerController _playerController;
  }
}

