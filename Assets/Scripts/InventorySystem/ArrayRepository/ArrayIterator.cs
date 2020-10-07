

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
      if (_index >= _arraySize) {
        return;
      }
      _currentItem = _itemsRepository.GetItemByIndex(_index);
    }

    public void Next() {
      ++_index;
      if (_index < _arraySize) {
        _currentItem = _itemsRepository.GetItemByIndex(_index);
      }
    }

    public bool IsDone() {
      ++_index;
      while (_index < _arraySize && _itemsRepository.GetItemByIndex(_index) == null) {
        ++_index;
      }
      --_index;
      if (_index < _arraySize) {
        return false;
      }
      return true;
    }

    public Item CurrentItem() {
      return _currentItem;
    }
  }
}
