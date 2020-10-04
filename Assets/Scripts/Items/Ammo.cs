using System.Collections;
using System.Collections.Generic;
using Components.Player;
using UnityEngine;

namespace Items {

  public class Ammo : InventorySystem.Item {
    private int _ammoCount;
    private GunComponent _gunComponent;

    public Ammo(int ammoCount) {
      _ammoCount = ammoCount;
    }
    
    public override void Use() {
      _gunComponent.AddAmmo(_ammoCount);
    }

    public override void Drop() {
      
    }

    public override void PickUp() {
      _gunComponent = GameObject.Find("Player").GetComponent<GunComponent>();
    }
  }

}
