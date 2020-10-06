using InventorySystem;
using UI.Items;
using UnityEngine;

namespace SaveLoadSystem.DTO {

  public class LootUiData : MonoBehaviour {
    public GameObject ammoUi;

    public string[] gunTypes;
    public GameObject[] gunsUiArray;
    
    public string[] outfitsTypes;
    public GameObject[] outfitsUiArray;

    public string[] medKitTypes;
    public GameObject[] medKitsUi;
    
    

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

    public IItemUi GetMedKitUi(string medKitType) {
      int index = 0;
      for (int i = 0; i < medKitTypes.Length; ++i) {
        if (medKitType == medKitTypes[i]) {
          index = i;
        }
      }
      
      var medKitUi_ = Instantiate(medKitsUi[index].GetComponent<ItemUiWithSingleButton>());
      medKitUi_.itemImage = Instantiate(medKitsUi[index].GetComponent<ItemUiWithSingleButton>().itemImage);
      medKitUi_.itemButton = Instantiate(medKitsUi[index].GetComponent<ItemUiWithSingleButton>().itemButton);
      medKitUi_.SetSprite();
      return medKitUi_;
    }
    
  }

}
