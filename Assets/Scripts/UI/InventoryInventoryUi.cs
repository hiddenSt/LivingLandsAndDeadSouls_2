using Components;
using InventorySystem.NewInventorySystem;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI {
  
  public class InventoryInventoryUi : MonoBehaviour, IInventoryUi {
    public GameObject[] slots;
    private bool[] _isEmptySlot;
    private InventoryComponent _inventoryComponent;
    private int _slotsSize;
    private Identifier[] _identifiers;
    private IItemUi[] _itemsUi;
    private GameObject[] _buttons;
    private GameObject[] _images;

    public void SetItem(IItemUi itemUi, Identifier itemIdentifier) {
      for (var i = 0; i < _slotsSize; ++i)
        if (_isEmptySlot[i]) {
          _isEmptySlot[i] = false;
          _identifiers[i] = itemIdentifier;
          _itemsUi[i] = itemUi;
          SetItemUi(i);
          return;
        }
    }

    private void SetItemUi(int index) {
      _buttons[index] = _itemsUi[index].SetItemButton(slots[index].transform);
      _images[index] = _itemsUi[index].SetItemImage(slots[index].transform);
      _buttons[index].GetComponent<Button>().onClick.AddListener(() => UseItem(index));
    }

    public void UseItem(int index) {
      _inventoryComponent.GetItem(_identifiers[index]).Use();
    }
    
    public void RemoveItem(int index) {
      _isEmptySlot[index] = true;
      _inventoryComponent.RemoveItem(_identifiers[index]);
      RemoveItemUi(index);
    }
    
    private void RemoveItemUi(int index) {
      Destroy(_buttons[index]);
      Destroy(_images[index]);
    }

    private void Start() {
      _inventoryComponent.SetInventoryUi(this);
      _slotsSize = slots.Length;
      _identifiers = new Identifier[_slotsSize];
      _itemsUi = new IItemUi[_slotsSize];
      _isEmptySlot = new bool[_slotsSize];
      _buttons = new GameObject[_slotsSize];
      _images = new GameObject[_slotsSize];
      for (var i = 0; i < _slotsSize; ++i)
        _isEmptySlot[i] = true;
    }
  }
}