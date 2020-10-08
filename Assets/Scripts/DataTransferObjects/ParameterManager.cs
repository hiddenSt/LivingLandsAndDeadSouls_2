using System.Collections.Generic;
using InventorySystem;
using Items;
using SaveLoadSystem;
using UnityEngine;

namespace DataTransferObjects {
  
  public class ParameterManager : MonoBehaviour {
    private void Start() {
      SetDefaults();
      if (instance == null)
        instance = this;
      else if (instance == this)
        Destroy(gameObject);
      DontDestroyOnLoad(gameObject);    
    }

    public void SetDefaults() {
      _mapScalerSmall = 3;
      _mapScalerMedium = 5;
      _mapScalerBig = 10;
      MapSizeVector.x = 200;
      MapSizeVector.y = 200;
      BuildingValue = 8;
      RockValue = 4;
      ForestValue = 3;
      SizeOfForest = 10;
      suitedGun = null;
      suitedOutfit = null;
      characterName = "Dick Clark";
      inventoryItems = null;
      lootSize = 30;
    }
    
    //GeneratorInfo
    public static ParameterManager instance = null;
    public int RockValue = 4;
    public int BuildingValue = 8;
    public int ForestValue = 3;
    public int SizeOfForest = 10;
    public int HostileCharVal;
    public int NeutralCharVal;
    public int Precipitation;
    public int StartSeason = 0;
    public bool NeedToLoad = false;
    public Vector3Int MapSizeVector;
    
    
    //LootSize
    public int lootSize;
    
    //playerData
    public SortedDictionary<string, AnimatorOverrideController> defaultAnimatorController;
    public string characterName;
    public List<Item> inventoryItems;
    public Gun suitedGun;
    public Outfit suitedOutfit;
    public ObjectPosition playerPosition;
    public float health;
    public float healthLimit;
    public int experience;
    public int freePoints;
    public float damageBuff;
    
    //mapData
    public int[,] MapData;
    private int _mapScalerSmall;
    private int _mapScalerMedium;
    private int _mapScalerBig;
  }
}