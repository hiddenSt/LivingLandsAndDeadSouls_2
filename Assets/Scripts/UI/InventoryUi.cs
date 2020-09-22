using Components;
using InventorySystem;
using UI.Controls;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI {
  
  public class InventoryUi : MonoBehaviour, IInventoryUi {
    public InventoryComponent inventoryComponent;
    public GameObject[] slots;
    private int _slotsSize;
    private Identifier[] _identifiers;
    private IItemUi[] _itemsUi;
    private GameObject[] _buttons;
    private GameObject[] _images;

    public void SetItem(IItemUi itemUi, Identifier itemIdentifier) {
      for (int i = 0; i < _slotsSize; ++i)
        if (IsEmptySlot(i)) {
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
      inventoryComponent.GetItem(_identifiers[index]).Use();
      RemoveItem(_identifiers[index]);
    }
    
    public void RemoveItem(Identifier identifier) {
      for (int i = 0; i < _slotsSize; ++i) {
        if (_identifiers[i] == null || !identifier.EqualsTo(_identifiers[i])) {
          continue;
        }
        inventoryComponent.RemoveItem(_identifiers[i]);
        _identifiers[i] = null;
        _itemsUi[i] = null;
        RemoveItemUi(i);
        return;
      }
    }

    public void DropItem(int index) {
      var item = inventoryComponent.GetItem(_identifiers[index]);
      inventoryComponent.DropItem(item);
      RemoveItemUi(index);
    }

    private void RemoveItemUi(int index) {
      _buttons[index].GetComponent<Button>().onClick.RemoveListener(() => UseItem(index));
      Destroy(_buttons[index]);
      Destroy(_images[index]);
    }

    private bool IsEmptySlot(int index) {
      return slots[index].transform.childCount <= 0;
    }

    private void Awake() {
      _slotsSize = gameObject.transform.childCount;
      slots = new GameObject[_slotsSize];
      for (int i = 0; i < gameObject.transform.childCount; ++i) {
        slots[i] = gameObject.transform.GetChild(i).gameObject;
        var comp = slots[i].AddComponent<DropItem>();
        comp.slotIndex = i;
      }
    }

    private void Start() {
      inventoryComponent.SetInventoryUi(this);
      _identifiers = new Identifier[_slotsSize];
      _itemsUi = new IItemUi[_slotsSize];
      _buttons = new GameObject[_slotsSize];
      _images = new GameObject[_slotsSize];
    }
  }
  
}