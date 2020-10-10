
namespace SaveLoadSystem.DTO {

  [System.Serializable]
  public class InventoryData {

    public void SetUp() {
      guns = new GunData[gunsSize];
      outfits = new OutfitData[outfitsSize];
      medKits = new MedKitData[medKitsSize];
      ammoData = new AmmoData[ammoSize];
    }
    
    public int outfitsSize;
    public int gunsSize;
    public int medKitsSize;
    public int ammoSize;
    public OutfitData[] outfits;
    public GunData[] guns;
    public MedKitData[] medKits;
    public AmmoData[] ammoData;
    public int size;
    public int capacity;
  }

}