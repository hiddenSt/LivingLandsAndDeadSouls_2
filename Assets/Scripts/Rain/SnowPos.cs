using UnityEngine;

namespace Rain {
  
  public class SnowPos : MonoBehaviour {
    private void Start() {
      var particle = GetComponent<ParticleSystem>();
      var sh = particle.shape;
      sh.scale = new Vector3(Menu.ParameterManager.instance.tmpSize.x * 18, 1, 1);
    }

    private void Update() {
      transform.position = new Vector3(0, Menu.ParameterManager.instance.tmpSize.y * 18, transform.position.z);
    }
    
    private Transform _player;
  }
}
