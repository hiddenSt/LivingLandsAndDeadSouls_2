using System.Collections;
using System.Collections.Generic;
using Menu;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

namespace GenerateMap {
  public class Generator : MonoBehaviour {
    private void Start() {
      tmpSize = ParameterManager.instance.tmpSize;
      forestValue = ParameterManager.instance.forestValue;
      forestSize = ParameterManager.instance.sizeOfForest;
      buildingValue = ParameterManager.instance.buildingValue;
      if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad)
        return;
      Generate();
    }

    public void GenerateMap(SaveLoadSystem.DTO.MapData mapData, Vector3Int tmpSize) {
      this.tmpSize = tmpSize;
      width = tmpSize.x;
      height = tmpSize.y;
      for (var i = 0; i < mapData.bushPosition.Count; ++i) {
        var pos = new Vector3(mapData.bushPosition[i].x, mapData.bushPosition[i].y, mapData.bushPosition[i].z);
        var bushObj = Instantiate(bush, pos, Quaternion.identity);
        bushObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.bushSortingOrder[i];
        bushList.Add(bushObj);
      }

      for (var i = 0; i < mapData.treePosition.Count; ++i) {
        var pos = new Vector3(mapData.treePosition[i].x, mapData.treePosition[i].y, mapData.treePosition[i].z);
        var treeObj = Instantiate(tree, pos, Quaternion.identity);
        treeObj.GetComponentInChildren<SpriteRenderer>().sortingOrder = mapData.treeSortingOrder[i];
        treeList.Add(treeObj);
      }

      for (var i = 0; i < mapData.rockPosition.Count; ++i) {
        var pos = new Vector3(mapData.rockPosition[i].x, mapData.rockPosition[i].y, mapData.rockPosition[i].z);
        var rockObj = Instantiate(rock, pos, Quaternion.identity);
        rockObj.GetComponent<SpriteRenderer>().sortingOrder = mapData.rockSortingOrder[i];
        rockList.Add(rockObj);
      }

      for (var i = 0; i < mapData.housePosition.Count; ++i) {
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

    private void GenerateTile() {
      width = tmpSize.x;
      height = tmpSize.y;
      switch (tmpSize.x) {
        case 200:
          buildingValue *= MAP_SCALER_SMALL;
          forestValue *= MAP_SCALER_SMALL;
          bushValue *= MAP_SCALER_SMALL;
          rockValue *= MAP_SCALER_SMALL;
          break;
        case 500:
          buildingValue *= MAP_SCALER_MEDIUM;
          forestValue *= MAP_SCALER_MEDIUM;
          bushValue *= MAP_SCALER_MEDIUM;
          rockValue *= MAP_SCALER_MEDIUM;
          break;
        case 1000:
          buildingValue *= MAP_SCALER_BIG;
          forestValue *= MAP_SCALER_BIG;
          bushValue *= MAP_SCALER_BIG;
          rockValue *= MAP_SCALER_BIG;
          break;
      }

      mapContent = new int[height, width];
      for (var x = 0; x < width; x++)
      for (var y = 0; y < height; y++)
        //Land(трава или песок и т.д.)
        landMap.SetTile(new Vector3Int
          (-x + width / 2, -y + height / 2, 0), landTile);
    }

    private void GenerateHorizon() {
      for (var i = 0; i < 10; ++i) {
        for (var x = 0; x < width + 10; ++x)
          waterTileMap.SetTile(new Vector3Int(-x + width / 2, -height / 2 - i, 0), waterTile);

        for (var x = 0; x < width + 10; ++x)
          waterTileMap.SetTile(new Vector3Int(-x + width / 2, height / 2 + 1 + i, 0), waterTile);

        for (var y = 0; y < height + 10; ++y)
          waterTileMap.SetTile(new Vector3Int(-width / 2 - i, -y + height / 2, 0), waterTile);

        for (var y = 0; y < height + 10; ++y)
          waterTileMap.SetTile(new Vector3Int(width / 2 + 1 + i, -y + height / 2, 0), waterTile);
      }
    }

    public void Generate() {
      GenerateTile();
      //CreateHorizon();
      GenerateBuilding();
      GenerateTree();
      GenerateRock();
      GenerateBush();
      GenerateLoot();
      GenerateHorizon();
    }

    private void CreateHorizon() {
      GameObject locTree;
      for (var x = 0; x < horizonLine; x++)
      for (var y = 0; y < height; y++)
        waterTileMap.SetTile(new Vector3Int
          (-x + width / 2, -y + height / 2, 0), horizonTile);

      for (var x = width; x > width - horizonLine; x--)
      for (var y = 0; y < height; y++)
        waterTileMap.SetTile(new Vector3Int
          (-x + width / 2, -y + height / 2, 0), horizonTile);

      for (var y = 0; y < horizonLine; y++)
      for (var x = 0; x < width; x++)
        waterTileMap.SetTile(new Vector3Int
          (-x + width / 2, -y + height / 2, 0), horizonTile);

      for (var y = height; y > height - horizonLine; y--)
      for (var x = 0; x < width; x++)
        waterTileMap.SetTile(new Vector3Int
          (-x + width / 2, -y + height / 2, 0), horizonTile);
    }

    public void GenerateBush() {
      var _errors = 0;
      SpriteRenderer layer = null;
      GameObject locBush = null;
      var canGenerate = false;
      var parent = false;
      bushList = new List<GameObject>();
      for (var i = 0; i < bushValue; i++) {
        canGenerate = false;
        if (_errors > 1000) break;
        while (canGenerate != true) {
          _errors++;
          if (_errors > 1000) break;
          var xPar = Random.Range(0, height);
          var yPar = Random.Range(0, width);

          canGenerate = FindContent(xPar, yPar, 10);

          if (canGenerate == true) {
            locBush = Instantiate(bush);
            locBush.transform.position = new Vector3
              (width / 2 - xPar, height / 2 - yPar);
            layer = locBush.GetComponentInChildren<SpriteRenderer>();
            layer.sortingOrder = height / 2 - (int) locBush.transform.position.y;
            bushList.Add(locBush);
            mapContent[xPar, yPar] = 2;
            var sizeOfrockPlace = Random.Range(1, 10);
            for (var j = 0; j < sizeOfrockPlace; j++) {
              var size = Random.Range(2f, 3.5f);
              var x = Random.Range(xPar - 1, xPar + 1);
              var y = Random.Range(yPar - 1, yPar + 1);
              locBush = Instantiate(bush);
              locBush.transform.position =
                new Vector3(width / 2 - x, height / 2 - y);
              layer = locBush.GetComponentInChildren<SpriteRenderer>();
              layer.sortingOrder = height / 2 -
                                   (int) locBush.transform.position.y;
              bushList.Add(locBush);
              mapContent[x, y] = 3;
            }
          }
        }
      }
    }

    public void GenerateLoot() {
      var _errors = 0;
      lootList = new List<GameObject>();
      bool generated;
      bool canGenerate;
      int posX, posY;
      for (var i = 0; i < lootList.Count; i++) {
        if (_errors > 1000) break;
        for (var j = 0; j < lootCount[i]; j++) {
          if (_errors > 1000) break;
          canGenerate = true;
          generated = false;
          while (generated != true) {
            _errors++;
            if (_errors > 1000) break;
            posX = Random.Range(0, width);
            posY = Random.Range(0, height);
            canGenerate = FindContent(posX, posY, 3);
            if (canGenerate == false) {
              continue;
            }
            else {
              Debug.Log("Loot generated");
              var loot = Instantiate(lootList[i]);
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

    //Можно ли генерировать в радиусе данной клетке
    public bool FindContent(int x, int y, int distanceBetweenObjects) {
      var checker = true;
      for (var i = x - distanceBetweenObjects; i < x + distanceBetweenObjects; i++) {
        for (var j = y - distanceBetweenObjects; j < y + distanceBetweenObjects; j++)
          if (i >= width || j >= height || i <= 0 || j <= 0) {
            return false;
          }
          else {
            if (mapContent[i, j] != 0) {
              checker = false;
              break;
            }
          }

        if (checker == false) break;
      }

      return checker;
    }

    public void GenerateBuilding() {
      var _errors = 0;
      GameObject house = null;
      var generated = false;
      var canGenerate = false;
      SpriteRenderer render;
      houseList = new List<GameObject>();
      houseTypeList = new List<int>();
      for (var i = 0; i < buildingValue; i++) {
        generated = false;
        if (_errors > 1000) break;
        while (!generated) {
          _errors++;
          if (_errors > 1000) break;
          var chance = Random.Range(0, 100);
          var cordX = Random.Range(0 + horizonLine + HORIZON_HELP_LINE,
            width - horizonLine - HORIZON_HELP_LINE);
          var cordY = Random.Range(0 + horizonLine + HORIZON_HELP_LINE,
            height - horizonLine - HORIZON_HELP_LINE);

          if (chance % 2 == 0)
            canGenerate = FindContent(cordX, cordY, 15);
          else
            canGenerate = FindContent(cordX, cordY, 30);

          if (canGenerate == true) {
            if (chance % 2 == 0) {
              house = Instantiate(this.house);
              houseTypeList.Add(0);
            }
            else {
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
          else {
            canGenerate = false;
            continue;
          }
        }
      }
    }


    public void GenerateTree() {
      var _errors = 0;
      float size;
      SpriteRenderer layer = null;
      GameObject tree = null;
      var canGenerate = false;
      var parent = false;
      treeList = new List<GameObject>();
      for (var i = 0; i < forestValue; i++) {
        canGenerate = false;
        if (_errors > 1000) break;
        while (canGenerate != true) {
          _errors++;
          if (_errors > 1000) break;
          var xPar = Random.Range(0, height);
          var yPar = Random.Range(0, width);

          canGenerate = FindContent(xPar, yPar, 15);

          if (canGenerate == true) {
            mapContent[xPar, yPar] = 4;

            for (var j = 0; j < forestSize; j++) {
              var x = Random.Range(xPar - 5, xPar + 5);
              var y = Random.Range(yPar - 5, yPar + 5);


              tree = Instantiate(this.tree);
              size = Random.Range(2.5f, 3);
              tree.transform.localScale = new Vector3(size, size, 1);
              tree.transform.position = new Vector3(width / 2 - x, height / 2 - y);
              layer = tree.GetComponentInChildren<SpriteRenderer>();
              layer.sortingOrder = height / 2 - (int) tree.transform.position.y + 2;
              treeList.Add(tree);
              mapContent[x, y] = 4;
            }
          }
        }
      }
    }

    public void GenerateRock() {
      var _errors = 0;
      SpriteRenderer layer = null;
      GameObject rock = null;
      var canGenerate = false;
      var parent = false;
      for (var i = 0; i < rockValue; i++) {
        canGenerate = false;
        //Чтобы не зациклилось. Если на одном кусте долго работает код, то программа выходит (errors)
        if (_errors > 1000) break;
        while (canGenerate != true) {
          _errors++;
          if (_errors > 1000) break;
          var xPar = Random.Range(0, height);
          var yPar = Random.Range(0, width);

          canGenerate = FindContent(xPar, yPar, 10);

          if (canGenerate == true) {
            rock = Instantiate(this.rock);
            rock.transform.position = new Vector3(width / 2 - xPar, height / 2 - yPar);
            layer = rock.GetComponentInChildren<SpriteRenderer>();
            layer.sortingOrder = height / 2 - (int) rock.transform.position.y;
            rockList.Add(rock);
            mapContent[xPar, yPar] = 2;

            var sizeOfRockPlace = Random.Range(1, 4);
            for (var j = 0; j < sizeOfRockPlace; j++) {
              var size = Random.Range(0.5f, 2);

              var x = Random.Range(xPar - 1, xPar + 1);
              var y = Random.Range(yPar - 1, yPar + 1);
              rock = Instantiate(this.rock);

              rock.transform.localScale = new Vector3(size, size, 0);

              rock.transform.position = new Vector3(width / 2 - x, height / 2 - y);
              layer = rock.GetComponentInChildren<SpriteRenderer>();
              layer.sortingOrder = height / 2 - (int) rock.transform.position.y;
              rockList.Add(rock);
              mapContent[x, y] = 3;
            }
          }
        }
      }
    }


    //data members
    private const int HORIZON_HELP_LINE = 5;
    private const int MAP_SCALER_SMALL = 3;
    private const int MAP_SCALER_MEDIUM = 5;
    private const int MAP_SCALER_BIG = 10;

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

    public int[,] mapContent; // 1 - building, 2 - rock, 3 - bush, 4 - tree
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
} // end of namespace GenerateMap