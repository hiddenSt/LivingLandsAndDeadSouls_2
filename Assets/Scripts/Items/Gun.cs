using HealthFight;
using Components.Player;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace Items {
  
  public class Gun : InventorySystem.Item {
    private int _fireRate;
    private int _ammoLimit;
    private Damage _damage;
    private int _ammoCount;
    private GunComponent _gunComponent;
    private string _gunType;

    public Gun(string gunType, int fireRate, float damagePoints, int ammoCount, int ammoLimit) {
      _type = "Gun";
      _fireRate = fireRate;
      _ammoCount = ammoCount;
      _ammoLimit = ammoLimit;
      _damage = new Damage(damagePoints);
      _gunType = gunType;
    }

    public override void Use() {
      _gunComponent.SetGun(this);
    }

    public override void Drop() {
      
    }

    public override void PickUp() {
      var player = GameObject.Find("Player");
      if (player == null) {
        return;
      }
      _gunComponent = player.GetComponent<GunComponent>();
    }
    
    public void SetAmmoLimit(int points) {
      _ammoLimit = points;
    }

    public void SetGunComponent(GunComponent gunComponent) {
      _gunComponent = gunComponent;
    }

    public int GetAmmoLimit() {
      return _ammoLimit;
    }

    public void SetAmmoCount(int points) {
      _ammoCount = points;
    }

    public int GetAmmoCount() {
      return _ammoCount;
    }

    public Damage GetDamage() {
      return _damage;
    }

    public float GetDamagePoints() {
      return _damage.GetDamagePoints();
    }

    public int GetFireRate() {
      return _fireRate;
    }

    public string GetGunType() {
      return _gunType;
    }
    
  }
}