using System.Collections.Generic;
using Menu;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GenerateMap
{
    public class Generator : MonoBehaviour  {
      public int ForestSize;
      public int ForestValue;
      public int BuildingValue;
      public int HorizonLine;
      public int Width;
      public int Height;
        
      public Vector3Int TMPSize;
        
      public GameObject Bush;
      public GameObject Rock;
      public GameObject House;
      public GameObject BigHouse;
      public GameObject Tree;
        
      public Tilemap LandMap;
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
        
      private const int _horizonHelpLine = 5;
      private const int _mapScalerSmall = 3;
      private const int _mapScalerMedium = 6;
      private const int _mapScalerBig = 10;
      private const int _horizonSize = 15;
      private int _currentMapScaler;
      
      private int[,] _mapContent;// 1 - building, 2 - rock, 3 - bush, 4 - tree
      
      private List<GameObject> _mapLootList;
      public void Start() {
            TMPSize = ParameterManager.instance.tmpSize;
            ForestValue = ParameterManager.instance.forestValue;
            ForestSize = ParameterManager.instance.sizeOfForest;
            BuildingValue = ParameterManager.instance.buildingValue;
            if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad)
                return;
            _mapContent = new int[TMPSize.x, TMPSize.y];
            Generate();
      }
        
        public void GenerateMap(MapData mapData, Vector3Int tmpSize) {
            TMPSize = tmpSize;
            Width = tmpSize.x;
            Height = tmpSize.y;
            for (var i = 0; i < mapData.bushPosition.Count; ++i) {
                var pos = new Vector3(mapData.bushPosition[i].x, mapData.bushPosition[i].y, mapData.bushPosition[i].z);
                var bushObj = Instantiate(Bush, pos, Quaternion.identity);
                bushObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.bushSortingOrder[i];
                BushList.Add(bushObj);
            }
            for (var i = 0; i < mapData.treePosition.Count; ++i) {
                var pos = new Vector3(mapData.treePosition[i].x, mapData.treePosition[i].y, mapData.treePosition[i].z);
                var treeObj = Instantiate(Tree, pos, Quaternion.identity);
                treeObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.treeSortingOrder[i];
                TreeList.Add(treeObj);
            }
            for (var i = 0; i < mapData.rockPosition.Count; ++i) {
                var pos = new Vector3(mapData.rockPosition[i].x, mapData.rockPosition[i].y, mapData.rockPosition[i].z);
                var rockObj = Instantiate(Rock, pos, Quaternion.identity);
                rockObj.GetComponent<SpriteRenderer>().sortingOrder = mapData.rockSortingOrder[i];
                RockList.Add(rockObj);
            }
            for (var i = 0; i < mapData.housePosition.Count; ++i) {
                var pos = new Vector3(mapData.housePosition[i].x, mapData.housePosition[i].y, 
                  mapData.housePosition[i].z);
                var houseObj = Instantiate(mapData.houseTypeList[i] == 0 ? House : BigHouse,
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
        
        private void GenerateTile() {
            Width = TMPSize.x;
            Height = TMPSize.y;
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
            ForestValue *= _currentMapScaler;
            ForestSize *= _currentMapScaler;
            _mapContent = new int[Height, Width];
            for (var x = 0; x < Width; x++) {
                for (var y = 0; y < Height; y++) {
                    LandMap.SetTile(new Vector3Int(-x + Width / 2, -y + Height / 2, 0), LandTile);
                }
            }
        }

        private void GenerateHorizon() {
            for (var i = 0; i < _horizonSize; ++i) {
              for (var x = -_horizonSize; x < Width + _horizonSize; ++x) {
                WaterTileMap.SetTile(new Vector3Int(-x + Width / 2, -Height / 2 - i, 0), WaterTile);
              }
              for (var x = -_horizonSize; x < Width + _horizonSize; ++x) {
                WaterTileMap.SetTile(new Vector3Int(-x + Width / 2, Height / 2 + 1 + i, 0), WaterTile);
              }
              for (var y = 0; y < Height; ++y) {
                WaterTileMap.SetTile(new Vector3Int(-Width / 2 - i, -y + Height / 2, 0), WaterTile);
              }
              for (var y = 0; y < Height; ++y) {
                WaterTileMap.SetTile(new Vector3Int(Width / 2 + 1 + i, -y + Height / 2, 0), WaterTile);
              }
            }
        }

        private List<GameObject> GenerateObjects(int count, int placeSize, int distance, GameObject generatingObject,
          int objectCode, int placeDistance, float minSize, float maxSize) {
          var objectList = new List<GameObject>();
          for (var i = 0; i < count; i++) {
                var errors = 0;
                while (true) {
                  errors++;
                  if (errors > 1000){
                    return objectList;
                  }
                  var xPar = Random.Range(0, Height);
                  var yPar = Random.Range(0, Width);
                  var canGenerate = FindContent(xPar, yPar, distance);
                  if (placeSize == 0) {
                    placeSize = Random.Range(2, 5);
                  }
                  if (!canGenerate) continue;
                  var locObject = Instantiate(generatingObject);
                  locObject.transform.position = new Vector3
                    (Width / 2 - xPar, Height / 2 - yPar);
                  var layer = locObject.GetComponentInChildren<SpriteRenderer>();
                  layer.sortingOrder = Height / 2 - (int) locObject.transform.position.y;
                  objectList.Add(locObject);
                  _mapContent[xPar, yPar] = objectCode;
                  var size = maxSize;
                  for (var j = 0; j < placeSize; j++) {
                    if ((int)minSize != (int)maxSize){ 
                      size = Random.Range(minSize, maxSize);
                    }
                    var x = Random.Range(xPar - placeDistance, xPar + placeDistance);
                    var y = Random.Range(yPar - placeDistance, yPar + placeDistance);
                    locObject = Instantiate(generatingObject);
                    locObject.transform.position = new Vector3(Width / 2 - x, Height / 2 - y);
                    locObject.transform.localScale = new Vector3(size,size,1);
                    layer = locObject.GetComponentInChildren<SpriteRenderer>();
                    layer.sortingOrder = Height / 2 -
                      (int) locObject.transform.position.y+2;
                    objectList.Add(locObject);
                    _mapContent[x, y] = 3;
                  }
                  break;
                }
          }
          return objectList;
        }

        private void Generate() {
          GenerateTile();
          GenerateBuilding();
          TreeList = GenerateObjects(ForestValue,ForestSize,7*_currentMapScaler, Tree,1,6*_currentMapScaler,2, 3.5f);
          BushList = GenerateObjects(ForestValue / _currentMapScaler,0,5, Bush,2,1,1, 2);
          RockList = GenerateObjects(ForestValue / _currentMapScaler,0,5, Rock,3,2,1, 3);
          GenerateHorizon();
        }

        private bool FindContent(int x, int y, int distanceBetweenObjects) {
            var checker = true;
            for (var i = x - distanceBetweenObjects; i < x + distanceBetweenObjects; i++) {
                for (var j = y - distanceBetweenObjects; j < y + distanceBetweenObjects; j++) {
                  if (i >= Width || j >= Height || i <= 0 || j <= 0) {
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

        private void GenerateBuilding() {
            var tryGenerateCounter = 0;
            HouseList = new List<GameObject>();
            HouseTypeList = new List<int>();
            for (var i = 0; i < BuildingValue; i++) {
                var generated = false;
                if (tryGenerateCounter > 1000) {
                    break;
                }
                tryGenerateCounter = 0;
                while (!generated) {
                    tryGenerateCounter++;
                    if (tryGenerateCounter > 1000) {
                        break;
                    }
                    var chance = Random.Range(0, 100);
                    var cordX = Random.Range(0 + HorizonLine + _horizonHelpLine, 
                      Width - HorizonLine - _horizonHelpLine);
                    var cordY = Random.Range(0 + HorizonLine + _horizonHelpLine,
                        Height - HorizonLine - _horizonHelpLine);
                    var canGenerate = FindContent(cordX, cordY, chance % 2 == 0 ? 15 : 30);
                    if (!canGenerate) continue;
                    GameObject locHouse;
                    if (chance % 2 == 0) {
                      locHouse = Instantiate(this.House);
                      HouseTypeList.Add(0);
                    }
                    else {
                      locHouse = Instantiate(BigHouse);
                      HouseTypeList.Add(1);
                    }
                    var render = locHouse.GetComponent<SpriteRenderer>();
                    locHouse.transform.position = new Vector3
                      (-cordX + Width / 2, -cordY + Height / 2, 0);
                    render.sortingOrder = Height / 2 - (int) locHouse.transform.position.y + 1;
                    HouseList.Add(locHouse);
                    _mapContent[cordX, cordY] = 1;
                    generated = true;
                }
            }
        }
    }
}// end of namespace GenerateMap
