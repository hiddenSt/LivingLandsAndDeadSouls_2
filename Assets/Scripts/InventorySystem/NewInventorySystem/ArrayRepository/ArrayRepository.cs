using Utility;

namespace InventorySystem.NewInventorySystem.ArrayRepository {
  class ArrayRepository : IItemsRepositoryStrategy {
    public ArrayRepository(int size) {
      _itemsArray = new Item[size];
      _isEmptySlot = new bool[size];
      for (int  i = 0; i < size; ++i) {
        _isEmptySlot[i] = true;
      }
    }
    
    public void AddItem(Item item) {
      for (int i = 0; i < _itemsArray.Length; ++i) {
        if (_isEmptySlot[i]) {
          _isEmptySlot[i] = false;
          _itemsArray[i] = item;
          return;
        }
      } 
    }

    public void RemoveItem(Identifier identifier) {
      for (int i = 0; i < _itemsArray.Length; ++i) {
        if (_isEmptySlot[i])
          continue;
        if (_itemsArray[i].GetIdentifier() == identifier) {
          _itemsArray[i] = null;
          _isEmptySlot[i] = true;
          return;
        }
      }
    }

    public Item GetItem(Identifier identifier) {
      for (int i = 0; i < _itemsArray.Length; ++i) {
        if (_isEmptySlot[i])
          continue;
        if (_itemsArray[i].GetIdentifier() == identifier)
          return _itemsArray[i];
      }
      return null;
    }

    public int GetSize() {
      return _itemsArray.Length;
    }
    
    public IItemIterator GetIterator() {
      return null; //new ArrayIterator(this);
    }

    private Item[] _itemsArray;
    private bool[] _isEmptySlot;
  }
}
