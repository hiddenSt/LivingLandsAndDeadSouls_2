using System.Collections.Generic;
using Menu;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GenerateMap
{
    public class Generator : MonoBehaviour
    {
        void Start()
        {
            tmpSize = Menu.ParameterManager.instance.tmpSize;
            forestValue = Menu.ParameterManager.instance.forestValue;
            forestSize = Menu.ParameterManager.instance.sizeOfForest;
            buildingValue = Menu.ParameterManager.instance.buildingValue;
            if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad)
                return;
            mapContent = new int[tmpSize.x, tmpSize.y];
            Generate();
        }
        
        public void GenerateMap(MapData mapData, Vector3Int tmpSize)
        {
            this.tmpSize = tmpSize;
            width = tmpSize.x;
            height = tmpSize.y;
            for (int i = 0; i < mapData.bushPosition.Count; ++i)
            {
                var pos = new Vector3(mapData.bushPosition[i].x, mapData.bushPosition[i].y, mapData.bushPosition[i].z);
                var bushObj = Instantiate(bush, pos, Quaternion.identity);
                bushObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.bushSortingOrder[i];
                bushList.Add(bushObj);
            }
            
            for (int i = 0; i < mapData.treePosition.Count; ++i)
            {
                var pos = new Vector3(mapData.treePosition[i].x, mapData.treePosition[i].y, mapData.treePosition[i].z);
                var treeObj = Instantiate(tree, pos, Quaternion.identity);
                treeObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.treeSortingOrder[i];
                treeList.Add(treeObj);
            }
            
            for (int i = 0; i < mapData.rockPosition.Count; ++i)
            {
                var pos = new Vector3(mapData.rockPosition[i].x, mapData.rockPosition[i].y, mapData.rockPosition[i].z);
                var rockObj = Instantiate(rock, pos, Quaternion.identity);
                rockObj.GetComponent<SpriteRenderer>().sortingOrder = mapData.rockSortingOrder[i];
                rockList.Add(rockObj);
            }
            
            for (int i = 0; i < mapData.housePosition.Count; ++i)
            {
                var pos = new Vector3(mapData.housePosition[i].x, mapData.housePosition[i].y, mapData.housePosition[i].z);
                GameObject houseObj;
                if (mapData.houseTypeList[i] == 0)
                    houseObj = Instantiate(house, pos, Quaternion.identity);
                else
                    houseObj = Instantiate(bigHouse, pos, Quaternion.identity);
                
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
            width = tmpSize.x;
            height = tmpSize.y;
            switch (tmpSize.x)
            {
                case 200:
                  CURRENT_MAP_SCALER = MAP_SCALER_SMALL;
                  break;
                case 500:
                  CURRENT_MAP_SCALER = MAP_SCALER_MEDIUM;
                  break;
                case 1000:
                  CURRENT_MAP_SCALER = MAP_SCALER_BIG;
                  break;
            }
            buildingValue *= CURRENT_MAP_SCALER;
            forestValue *= CURRENT_MAP_SCALER;
            bushValue *= CURRENT_MAP_SCALER;
            rockValue *= CURRENT_MAP_SCALER;
            forestSize *= CURRENT_MAP_SCALER;
            mapContent = new int[height, width];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    landMap.SetTile(new Vector3Int
                        (-x + width / 2, -y + height / 2, 0), landTile);
                }
            }
        }

        void GenerateHorizon()
        {
            for (int i = 0; i < HORIZON_SIZE; ++i)
            {
              for (int x = -HORIZON_SIZE; x < width + HORIZON_SIZE; ++x)
              {
                waterTileMap.SetTile(new Vector3Int(-x + width / 2, -height / 2 - i, 0), waterTile);
              }
              for (int x = -HORIZON_SIZE; x < width + HORIZON_SIZE; ++x)
              {
                waterTileMap.SetTile(new Vector3Int(-x + width / 2, height / 2 + 1 + i, 0), waterTile);
              }
              for (int y = 0; y < height; ++y)
              {
                waterTileMap.SetTile(new Vector3Int(-width / 2 - i, -y + height / 2, 0), waterTile);
              }
              for (int y = 0; y < height; ++y)
              {
                waterTileMap.SetTile(new Vector3Int(width / 2 + 1 + i, -y + height / 2, 0), waterTile);
              }
                
            }
        }

        List<GameObject> GenerateObjects(int count, int placeSize, int distance, GameObject gameObject,
          int objectCode, int placeDistance, float minSize, float maxSize){
          List<GameObject> objectList = new List<GameObject>();
          int _errors = 0;
          SpriteRenderer layer = null;
            GameObject locObject = null;
            bool canGenerate = false;
            bool parent = false;
            for (int i = 0; i < count; i++){
                _errors = 0;
                canGenerate = false;
                while (canGenerate != true)
                {
                  _errors++;
                  if (_errors > 1000){
                    return objectList;
                  }
                    var xPar = Random.Range(0, height);
                    var yPar = Random.Range(0, width);

                    canGenerate = FindContent(xPar, yPar, distance);
                    if (placeSize == 0){
                      placeSize = Random.Range(2, 5);
                    }
                    if (canGenerate == true)
                    {
                      locObject = Instantiate(gameObject);
                      locObject.transform.position = new Vector3
                            (width / 2 - xPar, height / 2 - yPar);
                        layer = locObject.GetComponentInChildren<SpriteRenderer>();
                        layer.sortingOrder = height / 2 - (int) locObject.transform.position.y;
                        objectList.Add(locObject);
                        mapContent[xPar, yPar] = objectCode;
                        for (int j = 0; j < placeSize; j++)
                        {
                            float size = Random.Range(minSize, maxSize);
                            int x = Random.Range(xPar - placeDistance, xPar + placeDistance);
                            int y = Random.Range(yPar - placeDistance, yPar + placeDistance);
                            locObject = Instantiate(gameObject);
                            locObject.transform.position =
                                new Vector3(width / 2 - x, height / 2 - y);
                            locObject.transform.localScale = new Vector3(size,size,1);
                            layer = locObject.GetComponentInChildren<SpriteRenderer>();
                            layer.sortingOrder = height / 2 -
                                                 (int) locObject.transform.position.y+2;
                            objectList.Add(locObject);
                            mapContent[x, y] = 3;
                        }
                        break;
                    }
                }
            }
            return objectList;
        }
        public void Generate()
        {
          GenerateTile();
          GenerateBuilding();
          treeList = GenerateObjects(forestValue,forestSize,5*CURRENT_MAP_SCALER, tree,2,5*CURRENT_MAP_SCALER,2, 3.5f);
            bushList = GenerateObjects(forestValue / CURRENT_MAP_SCALER,0,5, bush,1,1,1, 2);
            rockList = GenerateObjects(forestValue / CURRENT_MAP_SCALER,0,5, rock,3,2,1, 2);
            GenerateHorizon();
          Debug.Log("Info"+treeList.Count);
          Debug.Log("Info"+bushList.Count);
          Debug.Log("Info"+rockList.Count);
        }
        
       

        public void GenerateLoot()
        {
            int _errors=0;
            lootList = new List<GameObject>();
            bool generated;
            bool canGenerate;
            int posX, posY;
            for (int i = 0; i < lootList.Count; i++)
            {
                if (_errors > 1000)
                {
                    break;
                }
                for (int j = 0; j < lootCount[i]; j++)
                {
                    if (_errors > 1000)
                    {
                        break;
                    }
                    canGenerate = true;
                    generated = false;
                    while (generated != true)
                    {
                        _errors++;
                        if (_errors > 1000)
                        {
                            break;
                        }
                        posX = Random.Range(0, width);
                        posY = Random.Range(0, height);
                        canGenerate = FindContent(posX, posY, 3);
                        if (canGenerate == false)
                        {
                            continue;
                        }
                        else
                        {
                            Debug.Log("Loot generated");
                            GameObject loot = Instantiate(lootList[i]);
                            loot.transform.position = new Vector3
                                (width / 2 - posX, height / 2 - posY, 0);
                            loot.GetComponent<SpriteRenderer>().sortingOrder =
                                height / 2 - (int) loot.transform.position.y;
                            generated = true;
                            //mapContent[posX, posY] = 5;
                        }
                    }

                }
            }
        }
        
        public bool FindContent(int x, int y, int distanceBetweenObjects)
        {
            bool checker = true;
            for (int i = x - distanceBetweenObjects; i < x + distanceBetweenObjects; i++)
            {
                for (int j = y - distanceBetweenObjects; j < y + distanceBetweenObjects; j++)
                {
                    if (i >= width || j >= height || i <= 0 || j <= 0)
                    {
                        return false;
                    }
                    else
                    {
                        if (mapContent[i, j] != 0)
                        {
                            checker = false;
                            break;
                        }
                    }
                }

                if (checker == false)
                {
                    break;
                }
            }
            return checker;
        }

        public void GenerateBuilding()
        {
            int _errors = 0;
            GameObject house = null;
            bool generated = false;
            bool canGenerate = false;
            SpriteRenderer render;
            houseList = new List<GameObject>();
            houseTypeList = new List<int>();
            for (int i = 0; i < buildingValue; i++)
            {
                generated = false;
                if (_errors > 1000)
                {
                    break;
                }
                while (!generated)
                {
                    _errors++;
                    if (_errors > 1000)
                    {
                        break;
                    }
                    var chance = Random.Range(0, 100);
                    var cordX = Random.Range(0 + horizonLine + HORIZON_HELP_LINE,
                        width - horizonLine - HORIZON_HELP_LINE);
                    var cordY = Random.Range(0 + horizonLine + HORIZON_HELP_LINE,
                        height - horizonLine - HORIZON_HELP_LINE);

                    if (chance % 2 == 0)
                    {
                        canGenerate = FindContent(cordX, cordY, 15);
                    }
                    else
                    {
                        canGenerate = FindContent(cordX, cordY, 30);
                    }

                    if (canGenerate == true)
                    {
                        if (chance % 2 == 0)
                        {
                            house = Instantiate(this.house);
                            houseTypeList.Add(0);
                        }
                        else
                        {
                            house = Instantiate(bigHouse);
                            houseTypeList.Add(1);
                        }

                        render = house.GetComponent<SpriteRenderer>();
                        house.transform.position = new Vector3
                            (-cordX + width / 2, -cordY + height / 2, 0);
                        render.sortingOrder = height / 2 - (int) house.transform.position.y + 1;
                        houseList.Add(house);
                        mapContent[cordX, cordY] = 1;
                        generated = true;
                        canGenerate = false;
                    }
                    else
                    {
                        canGenerate = false;
                        continue;
                    }
                }
            }
        }
      //data members
        private const int HORIZON_HELP_LINE = 5;
        private const int MAP_SCALER_SMALL = 3;
        private const int MAP_SCALER_MEDIUM = 6;
        private const int MAP_SCALER_BIG = 10;
        private const int HORIZON_SIZE = 15;
        private int CURRENT_MAP_SCALER;
        [Range(5, 40)] public int forestSize;
        [Range(3, 10)] public int forestValue;
        [Range(1, 40)] public int buildingValue;
        [Range(5, 40)] public int rockValue;
        public int bushValue;
        
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
        
        public int[,] mapContent;// 1 - building, 2 - rock, 3 - bush, 4 - tree
        public int horizonLine;
        public int width;
        public int height;
        public Vector3Int tmpSize;
        public List<int> lootCount;
        
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
