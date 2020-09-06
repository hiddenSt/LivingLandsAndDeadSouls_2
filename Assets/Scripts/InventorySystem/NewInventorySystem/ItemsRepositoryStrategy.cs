

namespace InventorySystem.NewInventorySystem {

  public interface IItemsRepositoryStrategy {
    void AddItem(Item item);
    void RemoveItem(Item item);
    Item GetItem(int count);
    IItemIterator GetIterator();
  }
}