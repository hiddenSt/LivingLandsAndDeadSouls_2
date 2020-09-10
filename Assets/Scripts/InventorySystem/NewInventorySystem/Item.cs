using Utility;

namespace InventorySystem.NewInventorySystem {

 public abstract class Item {
    public abstract void Use();
    public abstract void PickUp();
    public abstract void Drop();

    public Identifier GetIdentifier() {
      return _identifier;
    }

    public void SetIdentifier(Identifier identifier) {
      _identifier = identifier;
    }

    private Identifier _identifier;
  }
}