using Components;
using InventorySystem.NewInventorySystem;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace UI {

  public class InventoryUi : MonoBehaviour, IUiController {
    public GameObject[] slots;
    public GameObject[] buttons;
    
    public void SetItem(Sprite itemImage, Identifier itemIdentifier) {
      for (int i = 0; i < _slotsSize; ++i) {
        if (_isEmptySlot[i]) {
          _isEmptySlot[i] = true;
          _identifiers[i] = itemIdentifier;
          _itemsImages[i].sprite = itemImage;
          SetButton(i);
          return;
        }
      }
    }
    
    public void RemoveItem(int index) {
      _inventoryComponent.RemoveItem(_identifiers[index]);
      RemoveButton(index);
    }
    
    public void DropItem(int index) {
      _inventoryComponent.DropItem(_identifiers[index], _itemsImages[index].sprite);
      
      _isEmptySlot[index] = true;
      RemoveButton(index);
    }
    
    public void UseItem(int index) {
      _inventoryComponent.GetItem(_identifiers[index]).Use();
      _inventoryComponent.RemoveItem(_identifiers[index]);
      RemoveButton(index);
    }

    private void SetButton(int index) {
      var button = buttons[index].GetComponent<Button>();
      button.interactable = true;
      button.onClick.AddListener(() => UseItem(index));
      Instantiate(_itemsImages[index], slots[index].transform);
    }

    private void RemoveButton(int index) {
      var button = buttons[index].GetComponent<Button>();
      button.interactable = false;
      button.onClick.RemoveListener(() => UseItem(index));
      Destroy(slots[index].transform.GetChild(0));
    }
    
    private void Start() {
      _inventoryComponent = gameObject.GetComponent<InventoryComponent>();
      _slotsSize = slots.Length;
      _identifiers = new Identifier[_slotsSize];
      _itemsImages = new Image[_slotsSize];
      
      _isEmptySlot = new bool[_slotsSize];
      for (int i = 0; i < _slotsSize; ++i)
        _isEmptySlot[i] = true;
    }

    private bool[] _isEmptySlot;
    private InventoryComponent _inventoryComponent;
    private int _slotsSize;
    private Identifier[] _identifiers;
    private Transform _playerTransform;
    private Image[] _itemsImages;
  }
}
