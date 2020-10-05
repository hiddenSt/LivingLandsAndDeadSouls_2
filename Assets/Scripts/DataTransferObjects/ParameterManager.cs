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
      tmpSize.x = 200;
      tmpSize.y = 200;
      buildingValue = 8;
      rockValue = 4;
      forestValue = 3;
      sizeOfForest = 10;
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
    public int rockValue = 4;
    public int buildingValue = 8;
    public int forestValue = 3;
    public int sizeOfForest = 10;
    public int characterI = 0;
    public int hostileCharVal;
    public int neutralCharVal;
    public int precipitation;
    public int startSeason = 0;
    public Vector3Int tmpSize;
    public bool needToLoad = false;
    
    //playerData
    public SortedDictionary<string, AnimatorOverrideController> defaultAnimatorController;
    public string characterName;
    public Item[] inventoryItems;
    public Gun suitedGun;
    public Outfit suitedOutfit;
    public ObjectPosition playerPosition;
    
    //mapData
    private int _mapScalerSmall;
    private int _mapScalerMedium;
    private int _mapScalerBig;
  }
}