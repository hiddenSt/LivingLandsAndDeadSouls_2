using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using InventorySystem;

namespace InventorySystem
{
    public class LongTouchUnity : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        private void Update()
        {
            if (!_isPointerDown) return;
            if (!(Time.time - _timePressStarted > durationThreshold)) return;
            _longPressTrigger = true;
            GameObject canvas = GameObject.Find("DestroyCanvas");
            GameObject fakePanel = canvas.transform.GetChild(0).gameObject;
            fakePanel.SetActive(true);
            GameObject destroyItem = canvas.transform.GetChild(1).GetComponent<Item>().destroyingItem = gameObject;
            canvas.transform.GetChild(1).GetComponent<Item>().dropItemComp = this.gameObject.GetComponent<DropItem>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _mousePosition = Input.mousePosition;
            _timePressStarted = Time.time;
            _isPointerDown = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            //gameObject.GetComponent<DropItem>().isActive = true;
            _isPointerDown = false;
        }

        //data members
        public float durationThreshold = 2.0f;
      

        private Vector3 _mousePosition;
        private bool _isPointerDown = false;
        private bool _longPressTrigger = false;
        private float _timePressStarted;
    }
}//end of namespace InventorySystem