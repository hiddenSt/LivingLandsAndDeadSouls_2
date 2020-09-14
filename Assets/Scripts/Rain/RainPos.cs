using UnityEngine;

namespace Rain {

  public class RainPos : MonoBehaviour {
    private Transform _player;

    private void Update() {
      _player = GameObject.FindGameObjectWithTag("Player").transform;
      transform.position = new Vector3(_player.position.x, _player.position.y + 10, transform.position.z);
    }
  }
}
