using Components;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public interface IUiController {
    void SetItem(Sprite itemImage, Identifier itemIdentifier);
    void RemoveItem(int index);
  }
}
