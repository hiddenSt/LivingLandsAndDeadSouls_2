using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public interface IUiController {
    void SetItemIcon(string itemType, Identifier itemIdentifier);
    void RemoveItem(Identifier itemIdentifier);
    void SetInventory(Inventory inventory);
  }
}
