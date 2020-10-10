using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Controls {

  public class DropItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler,
    IDragHandler {
    public int slotIndex;
    public float longTouchTime;
    public DestroyCanvasControl destroyCanvasControl;
    private InventoryUi _inventoryUi;
    private bool _isDestroying;
    private bool _isPointerDown;
    private float _touchStartTime;

    public void OnPointerDown(PointerEventData eventData) {
      if (gameObject.transform.childCount <= 0) {
        return;
      }
      _touchStartTime = Time.time;
      _isPointerDown = true;
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
      DeactivateDestroyCanvas();
    }

    public void OnEndDrag(PointerEventData eventData) {
      if (gameObject.transform.childCount <= 0)
        return;
      if (!_isDestroying) {
        _inventoryUi.DropItem(slotIndex);
      }
    }

    private void ActivateDestroyCanvas() {
      _isPointerDown = false;
      destroyCanvasControl.gameObject.SetActive(true);
      destroyCanvasControl.noButton.onClick.AddListener(DontDestroyItem);
      destroyCanvasControl.yesButton.onClick.AddListener(DestroyItem);
    }

    private void DeactivateDestroyCanvas() {
      destroyCanvasControl.noButton.onClick.RemoveListener(DontDestroyItem);
      destroyCanvasControl.yesButton.onClick.RemoveListener(DestroyItem);
      destroyCanvasControl.gameObject.SetActive(false);
    }
    
    private void Start() {
      _inventoryUi = transform.parent.gameObject.GetComponent<InventoryUi>();
      _isPointerDown = false;
      _isDestroying = false;
    }
  }
  
}