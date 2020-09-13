
using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public class Inventory {
    public Inventory(IItemsRepositoryStrategy itemsRepositoryStrategy, int capacity, IUiController uiController) {
      _itemsRepository = itemsRepositoryStrategy;
      _inventorySize = 0;
      _inventoryCapacity = capacity;
      _uiController = uiController;
    }
    
    public Identifier AddItem(Item item) {
      if (_inventorySize > _inventoryCapacity)
        return null;
      
      ++_inventorySize;
      item.SetIdentifier(_identifierFactory.CreateIdentifier());
      _itemsRepository.AddItem(item);
      item.PickUp();
      
      _uiController.SetItemIcon(item.GetUiPresenter());
      return item.GetIdentifier();
    }

    public void RemoveItem(Item item) {
      item.Drop();
      _uiController.RemoveItemIcon(item.GetIdentifier());
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
    private IdentifierFactory _identifierFactory;
    private int _inventoryCapacity;
    private IUiController _uiController;
  }
}
