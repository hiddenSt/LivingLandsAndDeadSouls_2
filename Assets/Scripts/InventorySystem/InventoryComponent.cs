using System;
using InventorySystem.NewInventorySystem.ArrayRepository;
using UnityEngine;
using Utility;


namespace InventorySystem {

  public class InventoryComponent : MonoBehaviour {
    public GameObject[] slots;
    public GameObject[] buttons;
    
    private void Start() {
      _slotsSize = slots.Length;
      buttons = new GameObject[_slotsSize];
      _inventory = new NewInventorySystem.Inventory(new ArrayRepository(_slotsSize), _slotsSize);
    }

    private void OnCollisionEnter2D(Collision2D other) {
      loot = other.gameObject.GetComponent<LootComonent>();
      if (loot == null || !CanAddItem()) 
        return;
      AddToInventory(loot.item, loot.button);
      Destroy(other.gameObject);
    }

    public void AddToInventory(InventorySystem.NewInventorySystem.Item item, GameObject button) {
      Identifier newItemIdentifier = _inventory.AddItem(item);
      
      for (int i = 0; i < slots.Length; ++i) {
        if (_slotsStatus[i] == false) {
          _slotsStatus[i] = true;
          AddItemToSlot(i, button, newItemIdentifier);
          return;
        }
      }
    }

    public void RemoveFromInventory(int position) {
      _slotsStatus[position] = false;
      Destroy(buttons[position]);
      _inventory.RemoveItem(_inventory.GetItem(_itemsIdentifiers[position]));
    }

    private void AddItemToSlot(int position, GameObject button, Identifier itemIdentifier) {
      _itemsIdentifiers[position] = itemIdentifier;
      buttons[position] = button;
      buttons[position].transform.SetParent(slots[position].transform); 
    }
    
    public void UseItem(int position) {
      
    }

    private bool CanAddItem() {
      return _inventory.GetInventorySize() <= _inventory.GetInventoryCapacity();
    }
    
    private NewInventorySystem.Inventory _inventory;
    private int _slotsSize;
    private Identifier[] _itemsIdentifiers;
    private bool[] _slotsStatus;
  }
}
