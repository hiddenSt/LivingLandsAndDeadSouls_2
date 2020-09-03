using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem
{
    public class DropItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!isActive)
                return;
            if (buttonSlot != null)
            {
                Destroy(buttonSlot);
            }
            this.gameObject.GetComponent<Spawn>().SpawnItem();
            Destroy(this.gameObject);
        }

        public GameObject slot;
        public GameObject buttonSlot;
        public bool isActive = true;
    }
}// end of namespace InventorySystem
