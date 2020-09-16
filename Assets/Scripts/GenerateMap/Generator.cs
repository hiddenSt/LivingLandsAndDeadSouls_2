using System.Collections.Generic;
using Menu;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GenerateMap
{
  public class Generator : MonoBehaviour
  {



    public void Start(){
      if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad)
        return;
      Generate();
    }

    private void Generate() {
      MapUnityGenerator generator = new MapUnityGenerator();
      int[,] mapData = generator.GenerateMapUnity();
      LoadingMapData loadingMapData = new LoadingMapData(mapData, 200, 200, 0, 0, 0, 0);
      MapLoaderUnity mapLoaderUnity = new MapLoaderUnity(loadingMapData);
      mapLoaderUnity.MapLoad();
    }
  }
}

/*public void GenerateMap(MapData mapData, Vector3Int tmpSize) {
  TMPSize = tmpSize;
  MapWidth = tmpSize.x;
  MapHeight = tmpSize.y;
  TileGenerator.TileGenerator tileGenerator = new TileGenerator.TileGenerator(15,TMPSize.x);
  tileGenerator.GenerateHorizon();
  tileGenerator.GenerateLands();
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
  var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
  timeController.season = mapData.season;
  timeController.ChangeSeason();
}
}*/
 // end of namespace GenerateMap