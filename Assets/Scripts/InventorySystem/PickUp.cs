using UnityEngine;

namespace InventorySystem {
  public class PickUp : MonoBehaviour {
    private void Start() {
      _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        if (canLoot == false)
          return;
        canLoot = false;
        for (int i = 0; i < _playerInventory.items.Length; i++) {
          if (_playerInventory.items[i] == 0) {
            _playerInventory.items[i] = 1;
            var gunSelectComp = itemButton.GetComponent<GunSelect>();
        
            if (gunSelectComp != null) {
              //itemButton.GetComponent<DropItem>().slot = _playerInventory.slots[i];
              var gameObj =  Instantiate(itemButton, _playerInventory.buttonSlots[i].transform, false);
              var imageObj = Instantiate(itemButton.GetComponent<GunSelect>().gunImage, _playerInventory.slots[i].transform,
                false);
              imageObj.GetComponent<DropItem>().buttonSlot = gameObj;
              gameObj.GetComponent<GunSelect>().imageObj = imageObj;
              gameObj.GetComponent<GunSelect>().slotIndex = i;
              Destroy(gameObject);
              return;
            }
        
            var outfitSelectComp = itemButton.GetComponent<OutfitSelect>();
            if (outfitSelectComp != null) {
              //itemButton.GetComponent<DropItem>().slot = _playerInventory.slots[i];
              var gameObj =  Instantiate(itemButton, _playerInventory.buttonSlots[i].transform, false);
              var imageObj = Instantiate(itemButton.GetComponent<OutfitSelect>().outfitImage, _playerInventory.slots[i].transform,
                false);
              imageObj.GetComponent<DropItem>().buttonSlot = gameObj;
              gameObj.GetComponent<OutfitSelect>().imageObj = imageObj;
              gameObj.GetComponent<OutfitSelect>().slotIndex = i;
              Destroy(gameObject);
              return;
            }
        
            itemButton.GetComponent<DropItem>().buttonSlot = null;
            Instantiate(itemButton, _playerInventory.slots[i].transform, false);
            Destroy(gameObject);
            return;
          }
        }
        canLoot = true;
      }
    }

    //data members
    public GameObject itemButton;
    public bool canLoot = true;
    private Inventory _playerInventory;
  }
}// end of namespace InventorySystem

