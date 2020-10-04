using HealthFight;
using UnityEngine;

namespace Items {
  public class MedKit : InventorySystem.Item {
    public MedKit(float healthBoostPoints) {
      _type = "MedKit";
      _healthBoostPoints = healthBoostPoints;
    }

    public override void Use() {
      _playerHealthComponent.IncreaseHealth(_healthBoostPoints);
    }

    public override void PickUp() {
      _playerHealthComponent = GameObject.Find("Player").GetComponent<HealthComponent>();
    }

    public override void Drop() {
    }

    private HealthComponent _playerHealthComponent;
    private float _healthBoostPoints;
  }
}