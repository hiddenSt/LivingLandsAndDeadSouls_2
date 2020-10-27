using Components.Player;
using InventorySystem;
using UI.Controls;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI {
  
  public class InventoryUi : MonoBehaviour, IInventoryUi {
    public InventoryComponent inventoryComponent;
    public GameObject[] slots;
    public DestroyCanvasControl destroyCanvasControl;
    public float longTouchTime;
    private Inventory _inventory;
    private int _slotsSize;
    private Identifier[] _identifiers;
    private IItemUi[] _itemsUi;
    private GameObject[] _buttons;
    private GameObject[] _images;
    private bool[] _isEmpty;
    
    public void SetItem(IItemUi itemUi, Identifier itemIdentifier) {
      int itemSlotIndex = itemUi.GetItemUiSlotIndex();
      if (itemSlotIndex != -1) {
        _identifiers[itemSlotIndex] = itemIdentifier;
        _itemsUi[itemSlotIndex] = itemUi;
        SetItemUi(itemSlotIndex);
        return;
      } 
      
      for (int i = 0; i < _slotsSize; ++i)
        if (IsEmptySlot(i)) {
          _identifiers[i] = itemIdentifier;
          _itemsUi[i] = itemUi;
          SetItemUi(i);
          return;
        }
    }

    public void RemoveItem(Identifier itemIdentifier) {
      for (int i = 0; i < _slotsSize; ++i) {
        if (_identifiers[i] != null && _identifiers[i].EqualsTo(itemIdentifier)) {
          RemoveItemUi(i);
          return;
        }
      }
    }

    public void SetInventory(Inventory inventory) {
      _inventory = inventory;
    }

    private void SetItemUi(int index) {
      _isEmpty[index] = false;
      _itemsUi[index].SetItemUiSlotIndex(index);
      _images[index] = _itemsUi[index].SetItemImage(slots[index].transform);
      _buttons[index] = _itemsUi[index].SetItemButton(slots[index].transform);
      _itemsUi[index].SetDestroyCanvas(destroyCanvasControl);
      _itemsUi[index].SetLongTouchTime(longTouchTime);
      _itemsUi[index].SetInventoryUi(this);
      _buttons[index].GetComponent<Button>().onClick.AddListener(() => UseItem(index));
    }

    public void UseItem(int index) {
      var item = _inventory.GetItem(_identifiers[index]);
      _inventory.RemoveItem(item.GetIdentifier());
      item.Use();
    }

    public void DropItem(int index) {
      var item = _inventory.GetItem(_identifiers[index]);
      _inventory.RemoveItem(_identifiers[index]);
      inventoryComponent.DropItem(item);
    }

    public void RemoveItem(int index) {
      _inventory.RemoveItem(_identifiers[index]);
    }
    
    public void DeactivateButton(int index) {
      _buttons[index].SetActive(false);
    }

    public void ActivateButton(int index) {
      _buttons[index].SetActive(true);
    }
    
    private void RemoveItemUi(int index) {
      _itemsUi[index].RemoveItemUiSlotIndex();
      _isEmpty[index] = true;
      _buttons[index].GetComponent<Button>().onClick.RemoveListener(() => UseItem(index));
      Destroy(_buttons[index]);
      Destroy(_images[index]);
    }

    private bool IsEmptySlot(int index) {
      return _isEmpty[index];
    }

    private void Awake() {
      _slotsSize = gameObject.transform.childCount;
      slots = new GameObject[_slotsSize];
      _isEmpty = new bool[_slotsSize];
      for (int i = 0; i < _slotsSize; ++i) {
        slots[i] = gameObject.transform.GetChild(i).gameObject;
        _isEmpty[i] = true;
      }
    }
    
    public void Setup() {
      inventoryComponent.SetInventoryUi(this);
      _identifiers = new Identifier[_slotsSize];
      _itemsUi = new IItemUi[_slotsSize];
      _buttons = new GameObject[_slotsSize];
      _images = new GameObject[_slotsSize];
    }
  }
  
}