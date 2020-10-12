using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Controls {

  public class ItemSlotControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler,
    IDragHandler {
    public int slotIndex;
    public float longTouchTime;
    private DestroyCanvasControl _destroyCanvasControl;
    private InventoryUi _inventoryUi;
    private bool _isDestroying;
    private bool _isPointerDown;
    private float _touchStartTime;

    public void OnPointerDown(PointerEventData eventData) {
      _touchStartTime = Time.time;
      _isPointerDown = true;
    }

    public void SetDestroyCanvas(DestroyCanvasControl destroyCanvasControl) {
      _destroyCanvasControl = destroyCanvasControl;
    }

    private void Update() {
      if (!_isPointerDown) {
        return;
      }

      if (Time.time - _touchStartTime >= longTouchTime) {
        _isDestroying = true;
        _isPointerDown = false;
        ActivateDestroyCanvas();
      }
      
    }

    public void OnPointerUp(PointerEventData eventData) {
      _isPointerDown = false;
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData) { }

    public void DestroyItem() {
      _inventoryUi.RemoveItem(slotIndex);
      _isDestroying = false;
      DeactivateDestroyCanvas();
    }

    public void DontDestroyItem() {
      _isDestroying = false;
      _inventoryUi.ActivateButton(slotIndex);
      DeactivateDestroyCanvas();
    }

    public void OnEndDrag(PointerEventData eventData) {
      if (!_isDestroying) {
        _inventoryUi.DropItem(slotIndex);
      }
    }

    public void SetInventoryUi(InventoryUi inventoryUi) {
      _inventoryUi = inventoryUi;
    }

    private void ActivateDestroyCanvas() {
      _isPointerDown = false;
      if (_destroyCanvasControl.gameObject.active == true) {
        return;
      }
      _inventoryUi.DeactivateButton(slotIndex);
      _destroyCanvasControl.gameObject.SetActive(true);
      _destroyCanvasControl.noButton.onClick.AddListener(DontDestroyItem);
      _destroyCanvasControl.yesButton.onClick.AddListener(DestroyItem);
    }

    private void DeactivateDestroyCanvas() {
      _destroyCanvasControl.noButton.onClick.RemoveListener(DontDestroyItem);
      _destroyCanvasControl.yesButton.onClick.RemoveListener(DestroyItem);
      _destroyCanvasControl.gameObject.SetActive(false);
    }
    
    private void Start() {
      _isPointerDown = false;
      _isDestroying = false;
    }
  }
  
}