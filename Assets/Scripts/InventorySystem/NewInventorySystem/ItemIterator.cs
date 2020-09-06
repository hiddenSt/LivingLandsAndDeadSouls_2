namespace InventorySystem.NewInventorySystem {
  
  public interface IItemIterator {
    Item First();
    Item Next();
    bool IsDone();
    Item CurrentItem();
  }
}
