using InventorySystem.NewInventorySystem.ArrayRepository;
using UI;
using UnityEngine;
using Utility;


namespace InventorySystem {
  public class InventoryComponent : MonoBehaviour {
    public int inventorySize;
    public InventoryUi inventoryUi;
    
    private void Start() {
      _inventory = new NewInventorySystem.Inventory(new ArrayRepository(inventorySize), inventorySize, inventoryUi);
      inventoryUi.SetInventory(_inventory);
    }

    private void OnCollisionEnter2D(Collision2D other) {
      var loot = other.gameObject.GetComponent<LootComponent>();
      if (loot == null || !CanAddItem())
        return;
      AddToInventory(loot.item);
      Destroy(other.gameObject);
    }

    private bool CanAddItem() {
      return _inventory.GetInventorySize() <= _inventory.GetInventoryCapacity();
    }
    
    public void AddToInventory(NewInventorySystem.Item item) {
      Identifier newItemIdentifier = _inventory.AddItem(item);
      _inventory.AddItem(item);
    }
    
    private NewInventorySystem.Inventory _inventory;
  }
}
