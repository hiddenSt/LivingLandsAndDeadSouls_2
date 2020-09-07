using System.Collections;
using System.Collections.Generic;
using InventorySystem.NewInventorySystem.ArrayRepository;
using UnityEngine;


namespace InventorySystem {

  public class InventoryComponent : MonoBehaviour {
    public GameObject images;
    public GameObject[] slots;
    public GameObject[] buttons;
    
    private void Start() {
      _slotsSize = slots.Length;
      buttons = new GameObject[_slotsSize];
      _inventory = new NewInventorySystem.Inventory(new ArrayRepository(_slotsSize));
    }

    public void AddToInventory(InventorySystem.NewInventorySystem.Item item, GameObject image, GameObject button) {
      _inventory.AddItem(item);
    }

    public void RemoveFromInventory(int count) {
      var itemIterator = _inventory.GetIterator();
      int i = 0;
      for (itemIterator.First(); itemIterator.IsDone(); itemIterator.Next()) {
        ++i;
        if (i == count)
          break;
      }
      _inventory.RemoveItem(itemIterator.CurrentItem());
    }

    public void UseItem() {
      
    }
    
    private NewInventorySystem.Inventory _inventory;
    private int _slotsSize;
  }
}
