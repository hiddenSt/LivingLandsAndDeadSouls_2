
using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public class Inventory {
    public Inventory(IItemsRepositoryStrategy itemsRepositoryStrategy, int capacity, IUiController uiController) {
      _itemsRepository = itemsRepositoryStrategy;
      _inventorySize = 0;
      _inventoryCapacity = capacity;
      _uiController = uiController;
    }
    
    public void AddItem(Item item) {
      if (_inventorySize > _inventoryCapacity)
        return;
      
      ++_inventorySize;
      item.SetIdentifier(new Identifier());
      _itemsRepository.AddItem(item);
      item.PickUp();
      
      _uiController.SetItemIcon(item.GetItemType(), item.GetIdentifier());
    }

    public void RemoveItem(Identifier identifier) {
      Item item = GetItem(identifier);
      item.Drop();
      _itemsRepository.RemoveItem(item.GetIdentifier());
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

    private IItemsRepositoryStrategy _itemsRepository;
    private int _inventorySize;
    private int _inventoryCapacity;
    private IUiController _uiController;
  }
}
