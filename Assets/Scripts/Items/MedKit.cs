using HealthFight;
using UnityEngine;

namespace Items {
  public class MedKit : InventorySystem.NewInventorySystem.Item {
    public MedKit(int healthBoostPoints) {
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
      _playerHealthComponent = null;
    }

    private HealthComponent _playerHealthComponent;
    private int _healthBoostPoints;
  }
}