using Items;
using SaveLoadSystem.DTO;

namespace SaveLoadSystem.Serializers {

  public class OutfitSerializer {
    public OutfitData Serialize(Outfit outfit) {
      var outfitData = new OutfitData();
      outfitData.outfitType = outfit.GetOutfitType();
      return outfitData;
    }

    public Outfit Deserialize(OutfitData outfitData) {
      var outfit = new Outfit(outfitData.outfitType);
      return outfit;
    }
  }

}
