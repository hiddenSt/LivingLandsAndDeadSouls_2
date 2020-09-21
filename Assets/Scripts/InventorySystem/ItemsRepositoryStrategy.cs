using Utility;

namespace InventorySystem {
  public interface IItemsRepositoryStrategy {
    void AddItem(Item item);
    void RemoveItem(Identifier identifier);
    Item GetItem(Identifier identifier);
    IItemIterator GetIterator();
  }
}