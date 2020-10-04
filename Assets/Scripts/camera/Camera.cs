using UnityEngine;

namespace Camera {
  public class Camera : MonoBehaviour {
    public Vector2 offset = new Vector2(2f, 1f);
    private Transform _player;

    private void Start() {
      offset = new Vector2(Mathf.Abs(offset.x), offset.y);
      _player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate() {
      transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
    }
  }
}