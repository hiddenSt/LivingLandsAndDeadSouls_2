using Items;
using SaveLoadSystem.DTO;

namespace SaveLoadSystem.Serializers {

  public class AmmoSerializer {
    public AmmoData Serialize(Ammo ammo) {
      var ammoData = new AmmoData();
      ammoData.ammoCount = ammo.GetAmmoCount();
      ammoData.slotUiIndex = ammo.GetItemUi().GetItemUiSlotIndex();
      return ammoData;
    }

    public Ammo Deserialize(AmmoData ammoData) {
      var ammo = new Ammo(ammoData.ammoCount);
      var itemUiDataTransfer = new ItemUiDataTransfer();
      itemUiDataTransfer.SetItemUiSlotIndex(ammoData.slotUiIndex);
      ammo.SetItemUi(itemUiDataTransfer);
      return ammo;
    }
  }

}
