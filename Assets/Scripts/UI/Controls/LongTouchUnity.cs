using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using InventorySystem;

namespace UI.Controls {
 public class LongTouchUnity : UIBehaviour, IPointerDownHandler {
    private void Update() {
      
    }

    public void OnPointerDown(PointerEventData eventData) {
      _mousePosition = Input.mousePosition;
      _timePressStarted = Time.time;
      _isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) { }

    public void OnPointerExit(PointerEventData eventData) {
      
      _isPointerDown = false;
    }

    //data members
    public float durationThreshold = 2.0f;


    private Vector3 _mousePosition;
    private bool _isPointerDown = false;
    private bool _longPressTrigger = false;
    private float _timePressStarted;
  }
} //end of namespace InventorySystem