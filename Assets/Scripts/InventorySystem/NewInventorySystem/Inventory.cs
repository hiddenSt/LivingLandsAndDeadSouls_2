
namespace InventorySystem.NewInventorySystem {
  
  public class Inventory {
    public Inventory(IItemsRepositoryStrategy itemsRepositoryStrategy) {
      _itemsRepository = itemsRepositoryStrategy;
    }
    
    public void AddItem(Item item) {
      _itemsRepository.AddItem(item);
    }

    public void RemoveItem(Item item) {
      _itemsRepository.RemoveItem(item);
    }

    public IItemIterator GetIterator() {
      return _itemsRepository.GetIterator();
    }
    
    private IItemsRepositoryStrategy _itemsRepository;
  }
}
