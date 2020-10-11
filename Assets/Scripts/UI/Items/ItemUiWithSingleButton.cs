using InventorySystem;
using UI.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Items {

  public class ItemUiWithSingleButton : MonoBehaviour, IItemUi {
    public GameObject itemButton;
    public GameObject itemImage;
    private Sprite _itemImageSprite;
    private ItemSlotControl _itemSlotControl;
    private int _itemUiSlotIndex = -1;

    public GameObject SetItemButton(Transform position) {
      var newButton = Instantiate(itemButton, position);
      _itemSlotControl = newButton.GetComponent<ItemSlotControl>();
      return newButton;
    }

    public GameObject SetItemImage(Transform position) {
      var newImage = Instantiate(itemImage, position);
      return newImage;
    }

    public void SetSprite() {
      _itemImageSprite = itemImage.GetComponent<Image>().sprite;
    }
    
    public Sprite GetItemImage() {
      return _itemImageSprite;
    }

    public void SetDestroyCanvas(DestroyCanvasControl destroyCanvasControl) {
      _itemSlotControl.SetDestroyCanvas(destroyCanvasControl);
    }

    public void SetItemUiSlotIndex(int index) {
      _itemUiSlotIndex = index;
    }

    public void RemoveItemUiSlotIndex() {
      _itemUiSlotIndex = -1;
    }

    public int GetItemUiSlotIndex() {
      return _itemUiSlotIndex;
    }

    public void SetLongTouchTime(float time) {
      _itemSlotControl.longTouchTime = time;
    }

    public void SetInventoryUi(InventoryUi inventoryUi) {
      _itemSlotControl.slotIndex = _itemUiSlotIndex;
      _itemSlotControl.SetInventoryUi(inventoryUi);
    }

    private void Start() {
      _itemImageSprite = itemImage.GetComponent<Image>().sprite;
    }
  }

}
