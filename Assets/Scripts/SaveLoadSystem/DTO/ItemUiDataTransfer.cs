using InventorySystem;
using UI;
using UI.Controls;
using UnityEngine;

namespace SaveLoadSystem.DTO {

  public class ItemUiDataTransfer : IItemUi {
    private int _slotUiIndex;
    
    public void SetItemUiSlotIndex(int index) {
      _slotUiIndex = index;
    }
    
    public int GetItemUiSlotIndex() {
      return _slotUiIndex;
    }

    public Sprite GetItemImage() {
      return null;
    }

    public GameObject SetItemButton(Transform position) {
      return null;
    }

    public GameObject SetItemImage(Transform position) {
      return null;
    }

    public void SetInventoryUi(InventoryUi inventoryUi) { }

    public void SetDestroyCanvas(DestroyCanvasControl destroyCanvasControl) { }

    public void SetLongTouchTime(float time) { }
    
    public void RemoveItemUiSlotIndex() { }

    
  }

}
