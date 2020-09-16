using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem {
  public class DropItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {
    public void OnBeginDrag(PointerEventData eventData) { }
    public void OnDrag(PointerEventData eventData) { }

    public void OnEndDrag(PointerEventData eventData) {
      if (!isActive)
        return;
      if (buttonSlot != null) {
        Destroy(buttonSlot);
      }

      this.gameObject.GetComponent<Spawn>().SpawnItem();
      Destroy(this.gameObject);
    }

    public GameObject slot;
    public GameObject buttonSlot;
    public bool isActive = true;
  }
}
