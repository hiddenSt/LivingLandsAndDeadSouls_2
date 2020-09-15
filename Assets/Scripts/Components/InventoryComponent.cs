using InventorySystem.NewInventorySystem.ArrayRepository;
using UI;
using UnityEngine;
using Utility;

namespace Components {
  public class InventoryComponent : MonoBehaviour {
    public int inventorySize;
    public InventoryUi inventoryUi;

    private void Start() {
      _inventory =
        new InventorySystem.NewInventorySystem.Inventory(new ArrayRepository(inventorySize), inventorySize,
          inventoryUi);
      inventoryUi.SetInventory(_inventory);
    }

    private void OnCollisionEnter2D(Collision2D other) {
      var loot = other.gameObject.GetComponent<LootComponent>();
      if (loot == null)
        return;
      AddItem(loot.item);
      Destroy(other.gameObject);
    }

    public void AddItem(InventorySystem.NewInventorySystem.Item item) {
      if (!CanAddItem())
        return;
      _inventory.AddItem(item);
    }

    private bool CanAddItem() {
      return _inventory.GetInventorySize() <= _inventory.GetInventoryCapacity();
    }

    private InventorySystem.NewInventorySystem.Inventory _inventory;
  }
}
