using InventorySystem.NewInventorySystem;
using UnityEngine;
using Utility;

namespace UI {

  public class InventoryUi : MonoBehaviour, IUiController {
    public void SetItemIcon(IUiPresenter itemUiPresenter) {
      
    }

    public void RemoveItemIcon(Identifier itemIdentifier) {
      
    }
    

    public void SetInventory(Inventory inventory) {
      _inventory = inventory;
    }

    private Inventory _inventory;
  }
}
