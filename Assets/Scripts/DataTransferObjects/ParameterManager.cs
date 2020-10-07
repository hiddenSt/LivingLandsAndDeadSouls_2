using System.Collections.Generic;
using InventorySystem;
using Items;
using SaveLoadSystem;
using UnityEngine;

namespace DataTransferObjects {
  
  public class ParameterManager : MonoBehaviour {
    private void Start() {
      _mapScalerSmall = 3;
      _mapScalerMedium = 5;
      _mapScalerBig = 10;
      MapSizeVector.x = 200;
      MapSizeVector.y = 200;
      BuildingValue = 8;
      RockValue = 4;
      ForestValue = 3;
      SizeOfForest = 10;
      if (instance == null)
        instance = this;
      else if (instance == this)
        Destroy(gameObject);
      DontDestroyOnLoad(gameObject);
      suitedGun = null;
      suitedOutfit = null;
    }

    
    
    //data members
    public static ParameterManager instance = null;
    public int RockValue = 4;
    public int BuildingValue = 8;
    public int ForestValue = 3;
    public int SizeOfForest = 10;
    public int CharacterI = 0;
    public int HostileCharVal;
    public int NeutralCharVal;
    public int Precipitation;
    public int StartSeason = 0;
    public bool NeedToLoad = false;
    public Vector3Int MapSizeVector;
    
    //playerData
    public SortedDictionary<string, AnimatorOverrideController> defaultAnimatorController;
    public string characterName;
    public List<Item> inventoryItems;
    public Gun suitedGun;
    public Outfit suitedOutfit;
    public ObjectPosition playerPosition;
    public float health;
    public float healthLimit;
    
    //mapData
    public int[,] MapData;
    private int _mapScalerSmall;
    private int _mapScalerMedium;
    private int _mapScalerBig;
  }
}