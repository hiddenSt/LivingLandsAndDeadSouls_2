using UI;
using UI.Controls;
using UnityEngine;

namespace InventorySystem {

  public interface IItemUi {
     GameObject SetItemButton(Transform position);
     GameObject SetItemImage(Transform position);
     Sprite GetItemImage();
     void SetDestroyCanvas(DestroyCanvasControl destroyCanvasControl);
     void SetItemUiSlotIndex(int index);
     void RemoveItemUiSlotIndex();
     int GetItemUiSlotIndex();
     void SetLongTouchTime(float time);
     void SetInventoryUi(IInventoryUi inventoryUi);
  }

}
