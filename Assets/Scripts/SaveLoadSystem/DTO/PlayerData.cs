
namespace SaveLoadSystem.DTO {
  [System.Serializable]
  public class PlayerData {
    public float healthPoints;
    public float healthPointsLimit;
    public ObjectPosition position;
    public InventoryData inventory;
    public GunData suitedGun;
    public OutfitData suitedOutfit;
    public string characterName;
    public int experience;
    public int freePoints;
    public float damageBuff;
  }
}