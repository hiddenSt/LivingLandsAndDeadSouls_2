namespace InventorySystem.NewInventorySystem {
  
  public interface IItemIterator {
    Item First();
    void Next();
    bool IsDone();
    Item CurrentItem();
  }
}
