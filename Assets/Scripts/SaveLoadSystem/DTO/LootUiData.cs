using System;
using System.Collections.Generic;
using InventorySystem;
using UI.Items;
using UnityEngine;

namespace SaveLoadSystem.DTO {

  public class LootUiData : MonoBehaviour {
    public GameObject ammoUi;
    public GameObject medKitUi;
    public GameObject meatUi;
    public string[] gunTypes;
    public GameObject[] gunsUiArray;
    public string[] outfitsTypes;
    public GameObject[] outfitsUiArray;
    
    

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
      int index = 0;
      for (int i = 0; i < outfitsTypes.Length; ++i) {
        if (outfitsTypes[i] == outfitType) {
          index = i;
        }
      }

      var newOutfitUi = Instantiate(outfitsUiArray[index].GetComponent<ItemUiWithSeparatedButton>());
      newOutfitUi.itemImage = Instantiate(outfitsUiArray[index].GetComponent<ItemUiWithSeparatedButton>().itemImage);
      newOutfitUi.button = Instantiate(outfitsUiArray[index].GetComponent<ItemUiWithSeparatedButton>().button);
      newOutfitUi.SetSprite();
      return newOutfitUi;
    }

    public IItemUi GetAmmoUi() {
      var ammoUi_ = Instantiate(ammoUi.GetComponent<ItemUiWithSingleButton>());
      ammoUi_.itemImage = Instantiate(ammoUi.GetComponent<ItemUiWithSingleButton>().itemImage);
      ammoUi_.itemButton = Instantiate(ammoUi.GetComponent<ItemUiWithSingleButton>().itemButton);
      ammoUi_.SetSprite();
      return ammoUi_;
    }

    public IItemUi MedKitUi() {
      var medKitUi_ = Instantiate(medKitUi.GetComponent<ItemUiWithSingleButton>());
      medKitUi_.itemImage = Instantiate(ammoUi.GetComponent<ItemUiWithSingleButton>().itemImage);
      medKitUi_.itemButton = Instantiate(medKitUi.GetComponent<ItemUiWithSingleButton>().itemButton);
      medKitUi_.SetSprite();
      return medKitUi_;
    }
    
    public IItemUi MeatUi() {
      var meatUi_ = Instantiate(meatUi.GetComponent<ItemUiWithSingleButton>());
      meatUi_.itemImage = Instantiate(meatUi.GetComponent<ItemUiWithSingleButton>().itemImage);
      meatUi_.itemButton = Instantiate(meatUi.GetComponent<ItemUiWithSingleButton>().itemButton);
      meatUi_.SetSprite();
      return meatUi_;
    }
  }

}
