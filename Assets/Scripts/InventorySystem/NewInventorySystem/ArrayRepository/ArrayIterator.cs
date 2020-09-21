namespace InventorySystem.NewInventorySystem.ArrayRepository {

  public class ArrayRepositoryIterator : IItemIterator {
    private ArrayRepository _itemsRepository;
    private Item _currentItem;

    public ArrayRepositoryIterator(ArrayRepository itemsRepository) {
      _itemsRepository = itemsRepository;
    }

    public void First() {
      
    }

    public void Next() {
      
    }

    public bool IsDone() {
      return true;
    }

    public Item CurrentItem() {
      return _currentItem;
    }
  }
}
