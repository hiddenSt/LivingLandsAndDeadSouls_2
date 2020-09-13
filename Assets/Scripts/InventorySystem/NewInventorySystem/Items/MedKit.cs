
using UnityEngine;

namespace InventorySystem.NewInventorySystem.Items {

  public class MedKit : Item {
    public override void PickUp() {
      Debug.Log("Picked Up");
    }

    public override void Use() {
      Debug.Log("Used");
    }

    public override void Drop() {
     Debug.Log("Dropped"); 
    }

    private int _healthBoostPoints;
  }
}
