using System.Collections.Generic;

namespace SaveLoadSystem.DTO {

  [System.Serializable]
  public class InventoryData {
    public List<OutfitData> outfits;
    public List<GunData> guns;
    public List<MedKitData> medKits;
    public int size;
    public int capacity;
  }

}