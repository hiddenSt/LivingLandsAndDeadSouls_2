/*namespace InventorySystem.NewInventorySystem.ArrayRepository {
  class ArrayIterator : IItemIterator {
    public ArrayIterator(ArrayRepository arrayRepository) {
      _arrayRepository = arrayRepository;
      _currentItemIndex = 0;
    }
     public Item First() {
      return _arrayRepository.GetItem();
    }

    public void Next() {
      if (IsDone())
        return;
      ++_currentItemIndex;
    }

    public Item CurrentItem() {
      return _arrayRepository.GetItem(_currentItemIndex);
    } 
    
    public bool IsDone() {
      return _currentItemIndex < _arrayRepository.GetSize();
    }

    private ArrayRepository _arrayRepository;
    private int _currentItemIndex;
  }
}*/
