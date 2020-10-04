using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Items {

  public class ItemUiWithSingleButton : MonoBehaviour, IItemUi {
    public GameObject itemButton;
    public GameObject itemImage;
    private Sprite _itemImageSprite;

    public GameObject SetItemButton(Transform position) {
      return Instantiate(itemButton, position);
    }

    public GameObject SetItemImage(Transform position) {
      return Instantiate(itemImage, position);
    }

    public Sprite GetItemImage() {
      return _itemImageSprite;
    }

    private void Start() {
      _itemImageSprite = itemImage.GetComponent<Image>().sprite;
    }
  }

}
