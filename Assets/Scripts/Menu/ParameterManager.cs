using UnityEngine;

namespace Menu {
    public class ParameterManager : MonoBehaviour {
      
      public static ParameterManager Instance = null;
      public int RockValue = 4;
      public int BuildingValue = 8;
      public int ForestValue = 3;
      public int SizeOfForest = 10;
      public int CharacterI = 0;
      public int HostileCharVal;
      public int NeutralCharVal;
      public int Precipitation;
      public int StartSeason = 0;
      public Vector3Int MapSizeVector;
      public bool NeedToLoad = false;

      public GameObject MedkitButton;
      public GameObject MeatButton;
      public GameObject Outfit1Button;
      public GameObject Outfit2Button;
      public GameObject Gun1Button;
      public GameObject Gun2Button;
      public GameObject AmmoButton;
      public GameObject Outfit1Image;
      public GameObject Outfit2Image;
      public GameObject Gun1Image;
      public GameObject Gun2Image;

      public int[,] MapData;
      private int _mapScalerSmall;
      private int _mapScalerMedium;
      private int _mapScalerBig;
      
        void Start() {
            _mapScalerSmall = 3;
            _mapScalerMedium = 5;
            _mapScalerBig = 10;
            MapSizeVector.x = 200;
            MapSizeVector.y = 200;
            BuildingValue = 8;
            RockValue = 4;
            ForestValue = 3;
            SizeOfForest = 10;
            if (Instance == null) {
              Instance = this;
            } else if (Instance == this) {
              Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}