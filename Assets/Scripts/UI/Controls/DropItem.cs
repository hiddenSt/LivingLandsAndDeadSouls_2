using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Controls {
  
  public class DropItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    public int slotIndex;
    private InventoryUi _inventoryUi;
    
    public void OnPointerDown(PointerEventData eventData) { }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData) { }
    
    public void OnEndDrag(PointerEventData eventData) {
      if (gameObject.transform.childCount <= 0)
        return;
      _inventoryUi.DropItem(slotIndex);
    }

    private void Start() {
      _inventoryUi = transform.parent.gameObject.GetComponent<InventoryUi>();
    }
  }
  
}