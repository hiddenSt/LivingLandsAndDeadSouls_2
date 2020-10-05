namespace InventorySystem.ArrayRepository {

  public class ArrayRepositoryIterator : IItemIterator {
    private ArrayRepository _itemsRepository;
    private Item _currentItem;
    private int _index;
    private int _arraySize;

    public ArrayRepositoryIterator(ArrayRepository itemsRepository) {
      _itemsRepository = itemsRepository;
      _arraySize = _itemsRepository.GetSize();
    }

    public void First() {
      _index = 0;
      _currentItem = _itemsRepository.GetItemByIndex(_index);
    }

    public void Next() {
      ++_index;
      _currentItem = _itemsRepository.GetItemByIndex(_index);
      while (!IsDone() && _itemsRepository.GetItemByIndex(_index) == null) {
        ++_index;
      }
    }

    public bool IsDone() {
      return _index >=  _arraySize;
    }

    public Item CurrentItem() {
      return _currentItem;
    }
  }
}
