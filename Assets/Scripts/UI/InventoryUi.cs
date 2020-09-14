using InventorySystem.NewInventorySystem;
using UnityEngine;
using Utility;

namespace UI {

  public class InventoryUi : MonoBehaviour, IUiController {
    public GameObject[] slots;
    public GameObject[] buttons;
    public void SetItemIcon(IUiPresenter itemUiPresenter) {
      
    }

    public void RemoveItemIcon(Identifier itemIdentifier) {
      
    }
    
    public void SetInventory(Inventory inventory) {
      _inventory = inventory;
    }

    private void Start() {
      _slotsSize = slots.Length;
      _isEmptySlot = new bool[_slotsSize];
      for (int i = 0; i < _slotsSize; ++i)
        _isEmptySlot[i] = true;
    }

    private bool[] _isEmptySlot;
    private Inventory _inventory;
    private int _slotsSize;
    private Identifier[] _identifiers;
  }
}
