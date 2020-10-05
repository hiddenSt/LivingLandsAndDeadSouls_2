using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Items;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.Serializers {

  public class OutfitSerializer {
    public OutfitData Serialize(Outfit outfit) {
      var outfitData = new OutfitData();
      outfitData.outfitType = outfit.GetOutfitType();
      return outfitData;
    }

    public Outfit Deserialize(OutfitData outfitData, SortedDictionary<string, AnimatorOverrideController> animatorOverrideControllers, IItemUi outfitUi) {
      var outfit = new Outfit(outfitData.outfitType, animatorOverrideControllers);
      outfit.SetItemUi(outfitUi);
      return outfit;
    }
  }

}
