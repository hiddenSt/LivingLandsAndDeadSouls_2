

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
      if (_index >= _arraySize) {
        return true;
      }
      
      if (_currentItem != null) {
        return false;
      }
      
      while (_index < _arraySize - 1 && _currentItem == null) {
        ++_index;
        _currentItem = _itemsRepository.GetItemByIndex(_index);
      }
      
      if (_currentItem == null) {
        return true;
      }
      
      return false;
    }

    public Item CurrentItem() {
      return _currentItem;
    }
  }
}
