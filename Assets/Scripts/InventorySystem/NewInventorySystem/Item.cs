using Utility;

namespace InventorySystem.NewInventorySystem {
  
  public abstract class Item {
    protected string _type;
    protected IItemUi _itemUi;
    private Identifier _identifier;

    public abstract void Use();
    public abstract void PickUp();
    public abstract void Drop();

    public void SetItemUi(IItemUi itemUi) {
      _itemUi = itemUi;
    }
    public string GetItemType() {
      return _type;
    }
    
    public IItemUi GeItemUi() {
      return _itemUi;
    }

    public Identifier GetIdentifier() {
      return _identifier;
    }

    public void SetIdentifier(Identifier identifier) {
      _identifier = identifier;
    }
  }
}