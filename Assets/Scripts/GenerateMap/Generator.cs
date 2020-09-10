using System.Collections.Generic;
using Menu;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GenerateMap
{
    public class Generator : MonoBehaviour
    {
      public void Start()
        {
            TMPSize = ParameterManager.instance.tmpSize;
            forestValue = ParameterManager.instance.forestValue;
            forestSize = ParameterManager.instance.sizeOfForest;
            buildingValue = ParameterManager.instance.buildingValue;
            if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad)
                return;
            _mapContent = new int[TMPSize.x, TMPSize.y];
            Generate();
        }
        
        public void GenerateMap(MapData mapData, Vector3Int tmpSize)
        {
            TMPSize = tmpSize;
            width = tmpSize.x;
            height = tmpSize.y;
            for (var i = 0; i < mapData.bushPosition.Count; ++i)
            {
                var pos = new Vector3(mapData.bushPosition[i].x, mapData.bushPosition[i].y, mapData.bushPosition[i].z);
                var bushObj = Instantiate(bush, pos, Quaternion.identity);
                bushObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.bushSortingOrder[i];
                bushList.Add(bushObj);
            }
            for (var i = 0; i < mapData.treePosition.Count; ++i)
            {
                var pos = new Vector3(mapData.treePosition[i].x, mapData.treePosition[i].y, mapData.treePosition[i].z);
                var treeObj = Instantiate(tree, pos, Quaternion.identity);
                treeObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.treeSortingOrder[i];
                treeList.Add(treeObj);
            }
            for (var i = 0; i < mapData.rockPosition.Count; ++i)
            {
                var pos = new Vector3(mapData.rockPosition[i].x, mapData.rockPosition[i].y, mapData.rockPosition[i].z);
                var rockObj = Instantiate(rock, pos, Quaternion.identity);
                rockObj.GetComponent<SpriteRenderer>().sortingOrder = mapData.rockSortingOrder[i];
                rockList.Add(rockObj);
            }
            for (var i = 0; i < mapData.housePosition.Count; ++i)
            {
                var pos = new Vector3(mapData.housePosition[i].x, mapData.housePosition[i].y, mapData.housePosition[i].z);
                var houseObj = Instantiate(mapData.houseTypeList[i] == 0 ? house : bigHouse, pos, Quaternion.identity);

                houseObj.GetComponent<SpriteRenderer>().sortingOrder = mapData.houseSortingOrder[i];
                houseTypeList.Add(mapData.houseTypeList[i]);
                houseList.Add(houseObj);
            }
            GenerateTile();
            var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
            timeController.season = mapData.season;
            timeController.ChangeSeason();
            GenerateHorizon();
        }
        
        private void GenerateTile()
        {
            width = TMPSize.x;
            height = TMPSize.y;
            switch (TMPSize.x)
            {
                case 200:
                  _currentMapScaler = MapScalerSmall;
                  break;
                case 500:
                  _currentMapScaler = MapScalerMedium;
                  break;
                case 1000:
                  _currentMapScaler = MapScalerBig;
                  break;
            }
            buildingValue *= _currentMapScaler;
            forestValue *= _currentMapScaler;
            forestSize *= _currentMapScaler;
            _mapContent = new int[height, width];
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    landMap.SetTile(new Vector3Int
                        (-x + width / 2, -y + height / 2, 0), landTile);
                }
            }
        }

        private void GenerateHorizon()
        {
            for (var i = 0; i < HorizonSize; ++i)
            {
              for (var x = -HorizonSize; x < width + HorizonSize; ++x)
              {
                waterTileMap.SetTile(new Vector3Int(-x + width / 2, -height / 2 - i, 0), waterTile);
              }
              for (var x = -HorizonSize; x < width + HorizonSize; ++x)
              {
                waterTileMap.SetTile(new Vector3Int(-x + width / 2, height / 2 + 1 + i, 0), waterTile);
              }
              for (var y = 0; y < height; ++y)
              {
                waterTileMap.SetTile(new Vector3Int(-width / 2 - i, -y + height / 2, 0), waterTile);
              }
              for (var y = 0; y < height; ++y)
              {
                waterTileMap.SetTile(new Vector3Int(width / 2 + 1 + i, -y + height / 2, 0), waterTile);
              }
            }
        }

        private List<GameObject> GenerateObjects(int count, int placeSize, int distance, GameObject generatingObject,
          int objectCode, int placeDistance, float minSize, float maxSize){
          var objectList = new List<GameObject>();
          for (var i = 0; i < count; i++){
                var errors = 0;
                while (true){
                  errors++;
                  if (errors > 1000){
                    return objectList;
                  }
                  var xPar = Random.Range(0, height);
                  var yPar = Random.Range(0, width);
                  var canGenerate = FindContent(xPar, yPar, distance);
                  if (placeSize == 0){
                    placeSize = Random.Range(2, 5);
                  }
                  if (!canGenerate) continue;
                  var locObject = Instantiate(generatingObject);
                  locObject.transform.position = new Vector3
                    (width / 2 - xPar, height / 2 - yPar);
                  var layer = locObject.GetComponentInChildren<SpriteRenderer>();
                  layer.sortingOrder = height / 2 - (int) locObject.transform.position.y;
                  objectList.Add(locObject);
                  _mapContent[xPar, yPar] = objectCode;
                  var size = maxSize;
                  for (var j = 0; j < placeSize; j++)
                  {
                    if ((int)minSize != (int)maxSize){
                      size = Random.Range(minSize, maxSize);
                    }
                    var x = Random.Range(xPar - placeDistance, xPar + placeDistance);
                    var y = Random.Range(yPar - placeDistance, yPar + placeDistance);
                    locObject = Instantiate(generatingObject);
                    locObject.transform.position =
                      new Vector3(width / 2 - x, height / 2 - y);
                    locObject.transform.localScale = new Vector3(size,size,1);
                    layer = locObject.GetComponentInChildren<SpriteRenderer>();
                    layer.sortingOrder = height / 2 -
                      (int) locObject.transform.position.y+2;
                    objectList.Add(locObject);
                    _mapContent[x, y] = 3;
                  }
                  break;
                }
          }
          return objectList;
        }

        private void Generate()
        {
          GenerateTile();
          GenerateBuilding();
          treeList = GenerateObjects(forestValue,forestSize,7*_currentMapScaler, tree,1,6*_currentMapScaler,2, 3.5f);
            bushList = GenerateObjects(forestValue / _currentMapScaler,0,5, bush,2,1,1, 2);
            rockList = GenerateObjects(forestValue / _currentMapScaler,0,5, rock,3,2,1, 3);
            GenerateHorizon();
          Debug.Log("Info"+treeList.Count);
          Debug.Log("Info"+bushList.Count);
          Debug.Log("Info"+rockList.Count);
        }

        private bool FindContent(int x, int y, int distanceBetweenObjects)
        {
            var checker = true;
            for (var i = x - distanceBetweenObjects; i < x + distanceBetweenObjects; i++)
            {
                for (var j = y - distanceBetweenObjects; j < y + distanceBetweenObjects; j++){
                  if (i >= width || j >= height || i <= 0 || j <= 0)
                  {
                    return false;
                  }
                  if (_mapContent[i, j] == 0) continue;
                  checker = false;
                  break;
                }
                if (checker == false)
                {
                    break;
                }
            }
            return checker;
        }

        private void GenerateBuilding()
        {
            var tryGenerateCounter = 0;
            houseList = new List<GameObject>();
            houseTypeList = new List<int>();
            for (var i = 0; i < buildingValue; i++)
            {
                var generated = false;
                if (tryGenerateCounter > 1000)
                {
                    break;
                }
                tryGenerateCounter = 0;
                while (!generated)
                {
                    tryGenerateCounter++;
                    if (tryGenerateCounter > 1000)
                    {
                        break;
                    }
                    var chance = Random.Range(0, 100);
                    var cordX = Random.Range(0 + horizonLine + HorizonHelpLine,
                        width - horizonLine - HorizonHelpLine);
                    var cordY = Random.Range(0 + horizonLine + HorizonHelpLine,
                        height - horizonLine - HorizonHelpLine);
                    var canGenerate = FindContent(cordX, cordY, chance % 2 == 0 ? 15 : 30);
                    if (!canGenerate) continue;
                    GameObject locHouse;
                    if (chance % 2 == 0)
                    {
                      locHouse = Instantiate(this.house);
                      houseTypeList.Add(0);
                    }
                    else
                    {
                      locHouse = Instantiate(bigHouse);
                      houseTypeList.Add(1);
                    }
                    var render = locHouse.GetComponent<SpriteRenderer>();
                    locHouse.transform.position = new Vector3
                      (-cordX + width / 2, -cordY + height / 2, 0);
                    render.sortingOrder = height / 2 - (int) locHouse.transform.position.y + 1;
                    houseList.Add(locHouse);
                    _mapContent[cordX, cordY] = 1;
                    generated = true;
                }
            }
        }
      //data members
        private const int HorizonHelpLine = 5;
        private const int MapScalerSmall = 3;
        private const int MapScalerMedium = 6;
        private const int MapScalerBig = 10;
        private const int HorizonSize = 15;
        private int _currentMapScaler;
        [Range(5, 40)] public int forestSize;
        [Range(3, 10)] public int forestValue;
        [Range(1, 40)] public int buildingValue;

        public GameObject bush;
        public GameObject rock;
        public GameObject house;
        public GameObject bigHouse;
        public GameObject tree;
        
        public Tilemap landMap;
        public Tilemap waterTileMap;
        public Tile waterTile;
        public Tile winterTile;
        public Tile landTile;
        public Tile horizonTile;
        public Tile autumnTile;

        private int[,] _mapContent;// 1 - building, 2 - rock, 3 - bush, 4 - tree
        public int horizonLine;
        public int width;
        public int height;
        public Vector3Int TMPSize;

        //Lists of GameObjects
        [Range(5, 40)] private List<GameObject> _mapLootList;
        public List<GameObject> bushList;
        public List<GameObject> lootList;
        public List<GameObject> rockList;
        public List<GameObject> houseList;
        public List<GameObject> treeList;
        public List<int> houseTypeList;
    }
}// end of namespace GenerateMap
