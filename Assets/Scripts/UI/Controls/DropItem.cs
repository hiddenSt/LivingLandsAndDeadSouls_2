using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem {
  public class DropItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {
    public void OnBeginDrag(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData) {

    }

  
  }
}
