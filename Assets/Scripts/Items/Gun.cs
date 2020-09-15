
using HealthFight;
using UnityEngine;

namespace Items {

  public class Gun : InventorySystem.NewInventorySystem.Item {
    public Gun() {
      _type = "Gun";
      _inUse = false;
    }

    public override void Use() {
      _gunComponent.damage = _damage.GetDamagePoints();
      _gunComponent.ammoCount = _ammoCount;
      _gunComponent.fireRate = _fireRate;
    }

    public override void Drop() {
      _gunComponent = null;
    }

    public override void PickUp() {
      _gunComponent = GameObject.Find("FireButton").GetComponent<HealthFight.Gun>();
    }

    
    private int _fireRate;
    private int _ammoLimit;
    private Damage _damage;
    private int _ammoCount;
    private HealthFight.Gun _gunComponent;
    private bool _inUse;
  }
}
