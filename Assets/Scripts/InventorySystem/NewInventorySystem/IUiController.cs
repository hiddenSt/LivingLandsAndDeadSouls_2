using Components;
using UnityEngine.UI;
using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public interface IUiController {
    void SetItem(Image itemImage, Identifier itemIdentifier);
    void RemoveItem(int index);
    void SetInventoryComponent(InventoryComponent inventoryComponent);
  }
}
