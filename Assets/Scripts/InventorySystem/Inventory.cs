using Utility;

namespace InventorySystem {
  
  public class Inventory {
    private IItemsRepositoryStrategy _itemsRepository;
    private int _inventorySize;
    private int _inventoryCapacity;
    private IInventoryUi _inventoryUi;

    public Inventory(IItemsRepositoryStrategy itemsRepositoryStrategy, IInventoryUi inventoryUi, int capacity) {
      _itemsRepository = itemsRepositoryStrategy;
      _inventorySize = 0;
      _inventoryCapacity = capacity;
      _inventoryUi = inventoryUi;
      _inventoryUi.SetInventory(this);
    }
    
    public void AddItem(Item item) {
      if (_inventorySize > _inventoryCapacity)
        return;
      ++_inventorySize;
      item.SetIdentifier(new Identifier());
      _itemsRepository.AddItem(item);
      item.PickUp();
      _inventoryUi.SetItem(item.GetItemUi(), item.GetIdentifier());
    }

    public void RemoveItem(Identifier identifier) {
      var item = GetItem(identifier);
      _inventoryUi.RemoveItem(item.GetIdentifier());
      item.Drop();
      _itemsRepository.RemoveItem(item.GetIdentifier());
      --_inventorySize;
    }

    public void SetInventoryUi(IInventoryUi inventoryUi) {
      _inventoryUi = inventoryUi;
      _inventoryUi.SetInventory(this);
      IItemIterator itemIterator = _itemsRepository.GetIterator();
      for (itemIterator.First(); itemIterator.IsDone(); itemIterator.Next()) {
        _inventoryUi.SetItem(itemIterator.CurrentItem().GetItemUi(), itemIterator.CurrentItem().GetIdentifier());
      }
    }
    
    public Item GetItem(Identifier identifier) {
      return _itemsRepository.GetItem(identifier);
    }

    public IItemIterator GetIterator() {
      return _itemsRepository.GetIterator();
    }

    public int GetInventorySize() {
      return _inventorySize;
    }

    public int GetInventoryCapacity() {
      return _inventoryCapacity;
    }
    
    public void SetInventoryCapacity(int capacity) {
      _inventoryCapacity = capacity;
    }
  }
}