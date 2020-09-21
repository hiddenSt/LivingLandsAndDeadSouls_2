using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public abstract class Item {
    protected string _type;
    private IItemUi _itemUi;
    private Identifier _identifier;

    public abstract void Use();
    
    public abstract void PickUp();
    
    public abstract void Drop();

    public string GetItemType() {
      return _type;
    }
    
    public Identifier GetIdentifier() {
      return _identifier;
    }
    
    public IItemUi GeItemUi() {
      return _itemUi;
    }

    public void SetItemUi(IItemUi itemUi) {
      _itemUi = itemUi;
    }

    public void SetIdentifier(Identifier identifier) {
      _identifier = identifier;
    }
  }
}