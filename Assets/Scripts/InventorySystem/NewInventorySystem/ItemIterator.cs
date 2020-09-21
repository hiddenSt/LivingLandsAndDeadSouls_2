namespace InventorySystem.NewInventorySystem {
  public interface IItemIterator {
    void First();
    void Next();
    bool IsDone();
    Item CurrentItem();
  }
}