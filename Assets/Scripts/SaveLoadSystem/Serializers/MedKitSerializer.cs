using Items;
using SaveLoadSystem.DTO;

namespace SaveLoadSystem.Serializers {

  public class MedKitSerializer {
    public MedKitData Serialize(MedKit medKit) {
      var medKitData = new MedKitData();
      medKitData.medKitType = medKit.GetMedKitType();
      medKitData.healthBoost = medKit.GetHealthPointsBoost();
      medKitData.slotUiIndex = medKit.GetItemUi().GetItemUiSlotIndex();
      return medKitData;
    }

    public MedKit Deserialize(MedKitData medKitData) {
      var medKit = new MedKit(medKitData.medKitType, medKitData.healthBoost);
      var itemUiDataTransfer = new ItemUiDataTransfer();
      itemUiDataTransfer.SetItemUiSlotIndex(medKitData.slotUiIndex);
      medKit.SetItemUi(itemUiDataTransfer);
      return medKit;
    }
  }

}
