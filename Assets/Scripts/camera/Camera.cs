using UnityEngine;

namespace Camera {
  public class Camera : MonoBehaviour {
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(2f, 1f);
    public int country;

    private Transform _player;
    private int _lastX;

    private void Start() {
      offset = new Vector2(Mathf.Abs(offset.x), offset.y);
    }

    private void FixedUpdate() {
      GetCoordinates();
    }

    private void GetCoordinates() {
      _player = GameObject.FindGameObjectWithTag("Player").transform;
      transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);
    }
  }
}