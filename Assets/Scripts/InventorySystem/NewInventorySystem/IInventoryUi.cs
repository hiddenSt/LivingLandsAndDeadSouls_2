using Utility;

namespace InventorySystem.NewInventorySystem {
  public interface IInventoryUi {
    void SetItem(IItemUi itemUi, Identifier itemIdentifier);
    void RemoveItem(Identifier identifier);
  }
}