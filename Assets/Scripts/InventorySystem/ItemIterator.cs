namespace InventorySystem {
  public interface IItemIterator {
    void First();
    void Next();
    bool IsDone();
    Item CurrentItem();
  }
}