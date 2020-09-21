using InventorySystem;
using UnityEngine;

namespace UI.Items {

  public class ItemUiWithSeparatedButton : MonoBehaviour, IItemUi {
    public GameObject itemImage;
    public GameObject button;
    public Vector3 relatedPosition;
    
    public GameObject SetItemButton(Transform position) {
      var instantiatedButton = Instantiate(button, position);
      instantiatedButton.transform.position += relatedPosition;
      return instantiatedButton;
    }

    public GameObject SetItemImage(Transform position) {
      return Instantiate(itemImage, position);
    }

    public Sprite GetItemImage() {
      return itemImage.GetComponent<Sprite>();
    }
  }

}
