using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public interface IUiController {
    void SetItemIcon(UI.IUiPresenter itemUiPresenter);
    void RemoveItemIcon(Identifier itemIdentifier);
    void SetInventory(Inventory inventory);
  }
}
