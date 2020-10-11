using System.Collections.Generic;
using InventorySystem;
using Items;
using SaveLoadSystem;
using UnityEngine;

namespace DataTransferObjects {
  
  public class ParameterManager : MonoBehaviour {
    private void Start() {
      SetDefaults();
      if (Instance == null)
        Instance = this;
      else if (Instance == this)
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
      inventoryItems = null;
      lootSize = 30;
      StartSeason = 0;
      NeedToLoad = false;
      NeutralCharVal = 20;
      HostileCharVal = 15;
      
      //platyer
      suitedGun = null;
      suitedOutfit = null;
      characterName = "Dick Clark";
      accuracy = 0;
      playerPosition.x = 0;
      playerPosition.y = 0;
      playerPosition.z = 0;
      health = 100f;
      healthLimit = 100f;
      damageBuff = 0f;
      Debug.Log("Defaults");
    }
    
    //GeneratorInfo
    public static ParameterManager Instance = null;
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
    public int accuracy;
    
    //mapData
    public int[,] MapData;
    private int _mapScalerSmall;
    private int _mapScalerMedium;
    private int _mapScalerBig;
    
  }
}