using InventorySystem.NewInventorySystem;
using UnityEngine;

namespace UI.Items {

  public class ItemUiWithSeparatedButton : MonoBehaviour, IItemUi {
    public GameObject itemImage;
    public GameObject button;
    
    public GameObject SetItemButton(Transform position) {
      return Instantiate(button, position);
    }

    public GameObject SetItemImage(Transform position) {
      return Instantiate(itemImage, position);
    }

    public Sprite GetItemImage() {
      return itemImage.GetComponent<Sprite>();
    }
  }

}
