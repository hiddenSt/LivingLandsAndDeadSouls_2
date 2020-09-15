using System.Collections.Generic;
using GenerateMap.TileGenerator;
using Menu;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GenerateMap {
  public class Generator : MonoBehaviour {
    public int ForestValue;
    public int ForestPlaceSize;
    public int BuildingValue;
    public int MapWidth;
    public int MapHeight;

    public Vector3Int TMPSize;

    public GameObject BushInstance;
    public GameObject RockInstance;
    public GameObject HouseInstance;
    public GameObject BigHouseInstance;
    public GameObject TreeInstance;

    public Tilemap LandTileMap;
    public Tilemap WaterTileMap;

    public Tile WaterTile;
    public Tile WinterTile;
    public Tile LandTile;
    public Tile AutumnTile;

    public List<GameObject> BushList;
    public List<GameObject> RockList;
    public List<GameObject> HouseList;
    public List<GameObject> TreeList;
    public List<int> HouseTypeList;

    private const int _mapScalerSmall = 3;
    private const int _mapScalerMedium = 6;
    private const int _mapScalerBig = 10;
    private const int _horizonSize = 15;
    private int _currentMapScaler;

    private int[,] _mapContent; // 1 - building, 2 - rock, 3 - bush, 4 - tree
    public void Start() {
      TMPSize = ParameterManager.instance.tmpSize;
      ForestPlaceSize = ParameterManager.instance.forestValue;
      ForestValue = ParameterManager.instance.sizeOfForest;
      BuildingValue = ParameterManager.instance.buildingValue;
      if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad)
        return;
      _mapContent = new int[TMPSize.x, TMPSize.y];
      Generate();
    }
    
    private void Generate() {
      LandTileMap = GameObject.Find("LandTileMap").GetComponent<Tilemap>();
      WaterTileMap = GameObject.Find("HorizonTileMap").GetComponent<Tilemap>();
      MapUnityGenerator generator = new MapUnityGenerator();
      generator.GenerateMapUnity();
      TileGenerator.TileGenerator tileGenerator = new TileGenerator.TileGenerator(15,TMPSize.x);
      tileGenerator.GenerateHorizon();
      tileGenerator.GenerateLands();
    }
    
    public void GenerateMap(MapData mapData, Vector3Int tmpSize) {
      TMPSize = tmpSize;
      MapWidth = tmpSize.x;
      MapHeight = tmpSize.y;
      for (int i = 0; i < mapData.bushPosition.Count; ++i) {
        var pos = new Vector3(mapData.bushPosition[i].x, mapData.bushPosition[i].y, mapData.bushPosition[i].z);
        var bushObj = Instantiate(BushInstance, pos, Quaternion.identity);
        bushObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.bushSortingOrder[i];
        BushList.Add(bushObj);
      }
      for (int i = 0; i < mapData.treePosition.Count; ++i) {
        var pos = new Vector3(mapData.treePosition[i].x, mapData.treePosition[i].y, mapData.treePosition[i].z);
        var treeObj = Instantiate(TreeInstance, pos, Quaternion.identity);
        treeObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.treeSortingOrder[i];
        TreeList.Add(treeObj);
      }
      for (int i = 0; i < mapData.rockPosition.Count; ++i) {
        var pos = new Vector3(mapData.rockPosition[i].x, mapData.rockPosition[i].y, mapData.rockPosition[i].z);
        var rockObj = Instantiate(RockInstance, pos, Quaternion.identity);
        rockObj.GetComponent<SpriteRenderer>().sortingOrder = mapData.rockSortingOrder[i];
        RockList.Add(rockObj);
      }
      for (int i = 0; i < mapData.housePosition.Count; ++i) {
        var pos = new Vector3(mapData.housePosition[i].x, mapData.housePosition[i].y,
          mapData.housePosition[i].z);
        var houseObj = Instantiate(mapData.houseTypeList[i] == 0 ? HouseInstance : BigHouseInstance,
          pos, Quaternion.identity);
        houseObj.GetComponent<SpriteRenderer>().sortingOrder = mapData.houseSortingOrder[i];
        HouseTypeList.Add(mapData.houseTypeList[i]);
        HouseList.Add(houseObj);
      }
      //GenerateTile();
      var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
      timeController.season = mapData.season;
      timeController.ChangeSeason();
     // GenerateHorizon();
    }
  }
} // end of namespace GenerateMap