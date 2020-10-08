using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Controls {

  public class DropItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,
    IDragHandler {
    public int slotIndex;
    public float longTouchTime;
    public DestroyCanvasControl destroyCanvasControl;
    private InventoryUi _inventoryUi;
    private bool _isDestroying;

    public void OnPointerDown(PointerEventData eventData) {
      if (gameObject.transform.childCount <= 0) {
        _isDestroying = false;
        return;
      }
      DetectLongTouch();
    }

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData) {
      Debug.Log("I am drag");
    }

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

    private void DetectLongTouch() {
      float holdTime = 0f;
      while (holdTime < longTouchTime) {
        holdTime += Time.deltaTime;
      }
      _isDestroying = true;
      ActivateDestroyCanvas();
    }
    
    private void ActivateDestroyCanvas() {
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
    }
  }
  
}