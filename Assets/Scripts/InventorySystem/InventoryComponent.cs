using InventorySystem.NewInventorySystem.ArrayRepository;
using UnityEngine;
using Utility;


namespace InventorySystem {

  public class InventoryComponent : MonoBehaviour {
    public int inventorySize;
    private void Start() {
      _inventory = new NewInventorySystem.Inventory(new ArrayRepository(inventorySize), inventorySize);
      //ConcretUiPresenter = 
    }

    private void OnCollisionEnter2D(Collision2D other) {
      var loot = other.gameObject.GetComponent<LootComponent>();
      if (loot == null || !CanAddItem())
        return;
      AddToInventory(loot.item, loot.button);
      Destroy(other.gameObject);
    }

    public void AddToInventory(NewInventorySystem.Item item, GameObject button) {
      Identifier newItemIdentifier = _inventory.AddItem(item);
      
      
    }
    

    private bool CanAddItem() {
      return _inventory.GetInventorySize() <= _inventory.GetInventoryCapacity();
    }
    
    private NewInventorySystem.Inventory _inventory;
    //
  }
}
