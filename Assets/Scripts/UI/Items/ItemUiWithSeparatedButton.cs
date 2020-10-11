using InventorySystem;
using UI.Controls;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Items {

  public class ItemUiWithSeparatedButton : MonoBehaviour, IItemUi {
    public GameObject itemImage;
    public GameObject button;
    public Vector3 relatedPosition;
    private Sprite _itemImageSprite;
    private ItemSlotControl _itemSlotControl;
    private int _itemUiSlotIndex = -1;

    public GameObject SetItemButton(Transform position) {
      var instantiatedButton = Instantiate(button, position);
      instantiatedButton.transform.position += relatedPosition;
      return instantiatedButton;
    }

    public void SetDestroyCanvas(DestroyCanvasControl destroyCanvasControl) {
      _itemSlotControl.SetDestroyCanvas(destroyCanvasControl);
    }

    public void SetSprite() {
      _itemImageSprite = itemImage.GetComponent<Image>().sprite;
    }

    public GameObject SetItemImage(Transform position) {
      var newImage = Instantiate(itemImage, position);
      _itemSlotControl = newImage.GetComponent<ItemSlotControl>();
      return newImage;
    }

    public Sprite GetItemImage() {
      return _itemImageSprite;
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
