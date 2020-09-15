using InventorySystem.NewInventorySystem;
using UnityEngine;
using Utility;

namespace UI {

  public class InventoryUi : MonoBehaviour, IUiController {
    public GameObject[] slots;
    public GameObject[] buttons;
    
    public void SetItemIcon(string itemType, Identifier identifier) {
      for (int i = 0; i < _slotsSize; ++i) {
        if (_isEmptySlot[i]) {
          _isEmptySlot[i] = true;
          _identifiers[i] = identifier;
          _itemsTypes[i] = itemType;
          //Set item's icon and activates button
          return;
        }
      }
    }

    public void RemoveItem(Identifier itemIdentifier) {
      // Deactivate button and remove item's icon
      _inventory.RemoveItem(itemIdentifier);
    }
    
    public void SetInventory(Inventory inventory) {
      _inventory = inventory;
    }

    public void DropItem(int i) {
      InventorySystem.NewInventorySystem.Item item = _inventory.GetItem(_identifiers[i]);
      _inventory.RemoveItem(_identifiers[i]);
      _isEmptySlot[i] = true;
      //Drops Item
      //Deactivate button and remove icon
    }

    public void UseItem(int i) {
      _inventory.GetItem(_identifiers[i]).Use();
      _inventory.RemoveItem(_identifiers[i]);
    }
    
    private void Start() {
      _slotsSize = slots.Length;
      _isEmptySlot = new bool[_slotsSize];
      _itemsTypes = new string[_slotsSize];
      _identifiers = new Identifier[_slotsSize];
      for (int i = 0; i < _slotsSize; ++i)
        _isEmptySlot[i] = true;
    }

    private bool[] _isEmptySlot;
    private Inventory _inventory;
    private int _slotsSize;
    private Identifier[] _identifiers;
    private string[] _itemsTypes;
    private Transform _playerTransform;
  }
}
