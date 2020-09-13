using UI;
using Utility;

namespace InventorySystem.NewInventorySystem {

 public interface Item {
    void Use();
    void PickUp();
    void Drop();
    Identifier GetIdentifier();
    void SetIdentifier(Identifier identifier);
    IUiPresenter GetUiPresenter();
 }
}