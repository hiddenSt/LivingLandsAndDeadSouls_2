using UnityEngine;

namespace InventorySystem {
  public class DropToInventory : MonoBehaviour {
    public void Drop() {
      if (isEmpty)
        return;
      for (int i = 0; i < _playerInventory.slots.Length; ++i) {
        if (_playerInventory.items[i] == 0) {
          if (_gunSlot != null) {
            isEmpty = true;
            _gunSlot.SwapGuns(i);
            _gunSlot.isEmpty = 1;
            _gunSlot.ChangeSkin(_gunSlot.skinIndex);
            _playerInventory.items[i] = 1;
            return;
          } else {
            isEmpty = true;
            _outfitSlot.SwapOutfits(i);
            _outfitSlot.skinIndex = 0;
            _outfitSlot.ChangeSkin();
            _playerInventory.items[i] = 1;
            return;
          }
        }
      }
    }
    
    private void Start() {
      _playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
      _gunSlot = gameObject.GetComponent<GunSlot>();
      _outfitSlot = gameObject.GetComponent<OutfitSlot>();
    }

    //data members
    private Inventory _playerInventory;
    private GunSlot _gunSlot;
    private OutfitSlot _outfitSlot;

    public bool isEmpty = true;
  }
}