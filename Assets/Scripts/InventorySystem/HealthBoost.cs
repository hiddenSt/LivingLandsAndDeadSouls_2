using UnityEngine;
using UnityEngine.Serialization;

namespace InventorySystem {
  
  public class HealthBoost : MonoBehaviour {
    private void Start() {
      _playerHealth = GameObject.Find("Player").GetComponent<HealthFight.HealthComponent>();
    }

    public void Use() {
      _playerHealth.IncreaseHealth(healthBoostPoints);
      Destroy(gameObject);
    }
    
    [FormerlySerializedAs("healthBoost")] public int healthBoostPoints;

    private HealthFight.HealthComponent _playerHealth;
  }
}