using System.Collections.Generic;

namespace SaveLoadSystem.DTO {

  [System.Serializable]
  public class InventoryData {
    public InventoryData() {
      outfits = new List<OutfitData>();
      guns = new List<GunData>();
      medKits = new List<MedKitData>();
      ammoData = new List<AmmoData>();
    }
    
    public List<OutfitData> outfits;
    public List<GunData> guns;
    public List<MedKitData> medKits;
    public List<AmmoData> ammoData;
    public int size;
    public int capacity;
  }

}