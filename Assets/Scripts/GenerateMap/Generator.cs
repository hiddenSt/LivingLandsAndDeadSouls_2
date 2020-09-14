using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Menu;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

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

    public Tilemap LandTilemMap;
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
      GenerateTile();
      MapUnityGenerator generator = new MapUnityGenerator();
      generator.GenerateMapUnity();
      GenerateHorizon();
    }
    
    private void GenerateTile() {
      MapWidth = TMPSize.x;
      MapHeight = TMPSize.y;
      switch (TMPSize.x) {
        case 200:
          _currentMapScaler = _mapScalerSmall;
          break;
        case 500:
          _currentMapScaler = _mapScalerMedium;
          break;
        case 1000:
          _currentMapScaler = _mapScalerBig;
          break;
      }
      BuildingValue *= _currentMapScaler;
      ForestPlaceSize *= _currentMapScaler;
      ForestValue *= _currentMapScaler;
      _mapContent = new int[MapHeight, MapWidth];
      for (int x = 0; x < MapWidth; x++) {
        for (int y = 0; y < MapHeight; y++) {
          LandTilemMap.SetTile(new Vector3Int(-x + MapWidth / 2, -y + MapHeight / 2, 0), LandTile);
        }
      }
    }
    
    private void GenerateBuilding() {
      HouseList = new List<GameObject>();
      HouseTypeList = new List<int>();
      for (var i = 0; i < BuildingValue; i++) {
        var chance = Random.Range(0, 100);
        var houseCoordinates = GenerateObjectCoordinates(chance % 2 == 0 ? 15 : 30);
        if (houseCoordinates == null) return;
        if (chance % 2 == 0) {
          HouseList.Add(GenerateObject(HouseInstance, houseCoordinates));
          HouseTypeList.Add(0);
        } else {
          HouseList.Add(GenerateObject(BigHouseInstance, houseCoordinates));
          HouseTypeList.Add(1);
        }
        _mapContent[houseCoordinates[0], houseCoordinates[1]] = 1;
      }
    }
    
    private List<GameObject> GenerateZones(int count, int placeSize, int distance, GameObject generatingObject,
      int objectCode, int placeDistance, float minSize, float maxSize) {
      var objectList = new List<GameObject>();
      GameObject generatedObject;
      for (int i = 0; i < count; i++) {
        var parentCoordinates = GenerateObjectCoordinates(distance);
        if (parentCoordinates == null) {
          return objectList;
        }
        int xParent = parentCoordinates[0];
        int yParent = parentCoordinates[1];
        if (placeSize == 0) {
          placeSize = Random.Range(2, 5);
        }
        generatedObject = GenerateObject(generatingObject, parentCoordinates);
        ChangeObjectSize(generatedObject, minSize, maxSize);
        objectList.Add(generatedObject);
        _mapContent[xParent, yParent] = objectCode;
        for (var j = 0; j < placeSize; j++) {
          int[] objectCoordinates = {Random.Range(xParent - placeDistance,
              xParent + placeDistance), 
            Random.Range(yParent - placeDistance, yParent + placeDistance)
          };
          objectList.Add(GenerateObject(
            generatingObject, objectCoordinates));
          _mapContent[objectCoordinates[0], objectCoordinates[1]] = objectCode;
        }
      }
      return objectList;
    }
    
    private void GenerateHorizon() {
      for (int i = 0; i < _horizonSize; ++i) {
        for (int x = -_horizonSize; x < MapWidth + _horizonSize; ++x) 
          WaterTileMap.SetTile(new Vector3Int(-x + MapWidth / 2, -MapHeight / 2 - i, 0), WaterTile);
        for (int x = -_horizonSize; x < MapWidth + _horizonSize; ++x) 
          WaterTileMap.SetTile(new Vector3Int(-x + MapWidth / 2, MapHeight / 2 + 1 + i, 0), WaterTile);
        for (int y = 0; y < MapHeight; ++y) 
          WaterTileMap.SetTile(new Vector3Int(-MapWidth / 2 - i, -y + MapHeight / 2, 0), WaterTile);
        for (int y = 0; y < MapHeight; ++y) 
          WaterTileMap.SetTile(new Vector3Int(MapWidth / 2 + 1 + i, -y + MapHeight / 2, 0), WaterTile);
      }
    }
    
  private int[] GenerateObjectCoordinates(int distanceFromAnotherObject) {
    int errors = 0;
    while (true) {
      errors++;
      if (errors > 1000) {
        return null;
      }
      int xParent = Random.Range(0, MapHeight);
      int yParent = Random.Range(0, MapWidth);
      bool canGenerate = FindContent(xParent, yParent, distanceFromAnotherObject);
      if (!canGenerate) continue;
      return new[]{xParent, yParent};
    }
  }

  private bool FindContent(int x, int y, int distanceBetweenObjects) {
    var checker = true;
    for (var i = x - distanceBetweenObjects; i < x + distanceBetweenObjects; i++) {
      for (var j = y - distanceBetweenObjects; j < y + distanceBetweenObjects; j++) {
        if (i >= MapWidth || j >= MapHeight || i <= 0 || j <= 0) {
          return false;
        }
        if (_mapContent[i, j] == 0) continue;
        checker = false;
          break;
        }
        if (checker == false) {
          break;
        }
      }
      return checker;
    }
    
    private GameObject GenerateObject(GameObject generatingObject, int[] coordinates) {
      var generatedObject = Instantiate(generatingObject);
      generatedObject.transform.position = new Vector3(MapWidth / 2 - coordinates[0],
        MapHeight / 2 - coordinates[1]);
      generatedObject.GetComponentInChildren<SpriteRenderer>().sortingOrder =
        MapHeight / 2 - (int) generatedObject.transform.position.y + 2;
      return generatedObject;
    }
    
    private void ChangeObjectSize(GameObject changingObject, float minSize, float maxSize) {
      float size = Random.Range(minSize, maxSize);
      changingObject.transform.localScale = new Vector3(size, size, 1);
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
      GenerateTile();
      var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
      timeController.season = mapData.season;
      timeController.ChangeSeason();
      GenerateHorizon();
    }
  }
} // end of namespace GenerateMap