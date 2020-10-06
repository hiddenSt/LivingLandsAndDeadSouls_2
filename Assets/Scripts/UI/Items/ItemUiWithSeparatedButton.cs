using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Items {

  public class ItemUiWithSeparatedButton : MonoBehaviour, IItemUi {
    public GameObject itemImage;
    public GameObject button;
    public Vector3 relatedPosition;
    private Sprite _itemImageSprite;

    public GameObject SetItemButton(Transform position) {
      var instantiatedButton = Instantiate(button, position);
      instantiatedButton.transform.position += relatedPosition;
      return instantiatedButton;
    }

    public void SetSprite() {
      _itemImageSprite = itemImage.GetComponent<Image>().sprite;
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
