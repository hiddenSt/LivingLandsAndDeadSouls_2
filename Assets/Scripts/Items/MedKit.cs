using HealthFight;
using UnityEngine;

namespace Items {
  public class MedKit : InventorySystem.Item {
    public MedKit(string medKitType, float healthBoostPoints) {
      _type = "MedKit";
      _medKitType = medKitType;
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

    public float GetHealthPointsBoost() {
      return _healthBoostPoints;
    }

    public string GetMedKitType() {
      return _medKitType;
    }

    private HealthComponent _playerHealthComponent;
    private float _healthBoostPoints;
    private string _medKitType;
  }
}