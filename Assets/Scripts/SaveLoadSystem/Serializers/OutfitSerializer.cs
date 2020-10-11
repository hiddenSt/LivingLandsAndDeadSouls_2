using Items;
using SaveLoadSystem.DTO;

namespace SaveLoadSystem.Serializers {

  public class OutfitSerializer {
    public OutfitData Serialize(Outfit outfit) {
      var outfitData = new OutfitData();
      outfitData.outfitType = outfit.GetOutfitType();
      outfitData.slotUiIndex = outfit.GetItemUi().GetItemUiSlotIndex();
      return outfitData;
    }

    public Outfit Deserialize(OutfitData outfitData) {
      var outfit = new Outfit(outfitData.outfitType);
      var itemUiDataTransfer = new ItemUiDataTransfer();
      itemUiDataTransfer.SetItemUiSlotIndex(outfitData.slotUiIndex);
      outfit.SetItemUi(itemUiDataTransfer);
      return outfit;
    }
  }

}
