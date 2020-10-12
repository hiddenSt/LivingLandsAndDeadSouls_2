using UnityEngine;

namespace TimeSystem.Rain {
  public class SnowPos : MonoBehaviour {
    private Transform _player;
    
    private void Start() {
      _player = GameObject.Find("Player").transform;
    }

    private void Update() {
      transform.position = new Vector3(_player.position.x, _player.position.y + 10, transform.position.z);
    }
  }
}