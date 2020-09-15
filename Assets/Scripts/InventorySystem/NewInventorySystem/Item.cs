using UI;
using Utility;

namespace InventorySystem.NewInventorySystem {

 public abstract class Item {
    public abstract void Use();
    public abstract void PickUp();
    public abstract void Drop();

    public string GetItemType() {
      return _type;
    }
    
    public Identifier GetIdentifier() {
      return _identifier;
    }

    public void SetIdentifier(Identifier identifier) {
      _identifier = identifier;
    }

    protected string _type;
    private Identifier _identifier;
 }
}