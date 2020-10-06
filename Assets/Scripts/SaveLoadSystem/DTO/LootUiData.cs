using System.Collections.Generic;
using InventorySystem;
using UI.Items;
using UnityEngine;

namespace SaveLoadSystem.DTO {

  public class LootUiData : MonoBehaviour {
    public GameObject ammoImage;
    public GameObject medKitImage;
    public GameObject meatImage;
    public string[] gunTypes;
    public GameObject[] gunsUiArray;
    public string[] outfitsTypes;
    public GameObject[] outfitImages;
    public GameObject[] outfitsUiArray;

    public GameObject separatedButton;
    public GameObject singleButton;
    

    public IItemUi GetGunUi(string gunType) {
      int index = 0;
      for (int i = 0; i < gunTypes.Length; ++i) {
        if (gunTypes[i] == gunType) {
          index = i;
        }
      }

      var newGunUi = Instantiate(gunsUiArray[index].GetComponent<ItemUiWithSeparatedButton>());
      newGunUi.button =
        Instantiate(gunsUiArray[index].GetComponent<ItemUiWithSeparatedButton>().button);
      newGunUi.itemImage =
        Instantiate(gunsUiArray[index].GetComponent<ItemUiWithSeparatedButton>().itemImage);
      newGunUi.SetSprite();
      return newGunUi;
    }
    
    public IItemUi GetOutfitUi(string outfitType) {
      return null;
    }

    public IItemUi GetAmmoUi() {
      var ammoUi = Instantiate(ammoImage);
      return ammoUi.GetComponent<ItemUiWithSingleButton>();
    }

    public IItemUi MedKitUi() {
      var medKitUi = Instantiate(medKitImage);
      return medKitUi.GetComponent<ItemUiWithSingleButton>();
    }
    
    public IItemUi MeatUi() {
      var meatUi = Instantiate(meatImage);
      return meatUi.GetComponent<ItemUiWithSingleButton>();
    }
  }

}
