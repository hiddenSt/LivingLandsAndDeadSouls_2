using UnityEngine;
using UnityEngine.EventSystems;

namespace ControlButtons {

  public class RightButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {
    private void Start() {
      _audio = GameObject.Find("AudioManager").GetComponent<AudioSource>();
      _player = GameObject.Find("Player");
      _playerController = _player.GetComponent<Player.PlayerController>();
    }

    public virtual void OnPointerDown(PointerEventData ped) {
      _audio.Play();
      print("RightPointerDown");
      _playerController.needToGo = true;
      _playerController.direction = 2;
    }

    public virtual void OnPointerUp(PointerEventData ped) {
      _audio.Stop();
      _playerController.needToGo = false;
      print("RightPointerUp");
    }
    
    private AudioSource _audio;
    private GameObject _player;
    private Player.PlayerController _playerController;
  }
}
