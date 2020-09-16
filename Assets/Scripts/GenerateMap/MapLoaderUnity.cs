using System.Collections.Generic;
using UnityEngine;

namespace GenerateMap {
  public class MapLoaderUnity : MonoBehaviour {
    private GameObject _smallHouse;
    private GameObject _bigHouse;
    private GameObject _tree;
    private GameObject _bush;
    private GameObject _rock;
    private GameObject _objectInstanceStorage;
    private LoadingMapData _mapData;
    private List<GameObject> treeList;
    private List<GameObject> rockList;
    private List<GameObject> bushList;
    private List<GameObject> houseList;
    private List<int> houseTypeList;

    public MapLoaderUnity(LoadingMapData mapData){
      _mapData = mapData;
      _objectInstanceStorage = GameObject.Find("ObjectInstanceStorage");
    }
    
    public void MapLoad() {
      TileLoad();
      FindObjectInstances();
      CreateMapDataStorage();
      InstantiateObjects();
      LoadMapDataStorage();
      LoadTimeControlParameters();
      Debug.Log("Map"+_mapData.MapData.Length);
    }
    
    private void FindObjectInstances() {
      _bigHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Big_house");
      _smallHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Small_house");
      _tree = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Tree");
      _bush = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Bush");
      _rock = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Rock");
    }
    
    private void ChangeGameObjectParameters(GameObject changingObject, int xPos, int yPos, int extraLayerValue) {
      changingObject.transform.localPosition = new Vector3(_mapData.MapWidth / 2 - xPos, 
        _mapData.MapHeight / 2 - yPos ,1);
      changingObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = _mapData.MapHeight / 2 - 
        (int) changingObject.transform.position.y + extraLayerValue;
    }

    private void LoadTimeControlParameters() {
      var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
      timeController.year = _mapData.Year;
      timeController.day = _mapData.Day;
      timeController.hour = _mapData.Hour;
      timeController.season = _mapData.Season;
      timeController.ChangeSeason();
    }

    private void TileLoad() {
      TileGenerator.TileGenerator tileGenerator = new TileGenerator.TileGenerator(15, _mapData.MapWidth);
      tileGenerator.GenerateHorizon();
      tileGenerator.GenerateLands();
    }


    private void CreateMapDataStorage() {
      treeList = new List<GameObject>();
      rockList = new List<GameObject>();
      bushList = new List<GameObject>();
      houseList = new List<GameObject>();
      houseTypeList = new List<int>();
    }

    private void LoadMapDataStorage() {
      MapDataStorage mapDataStorage = GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>();
      mapDataStorage.BushList = bushList;
      mapDataStorage.TreeList = treeList;
      mapDataStorage.RockList = rockList;
      mapDataStorage.HouseList = houseList;
      mapDataStorage.HouseTypeList = houseTypeList;
      mapDataStorage.MapContent = _mapData.MapData;
      mapDataStorage.MapHeight = _mapData.MapHeight;
      mapDataStorage.MapWidth = _mapData.MapWidth;
      mapDataStorage.Season = _mapData.Season;
    }
    private void InstantiateObjects() {
      for (int i = 0; i < _mapData.MapHeight; i++) {
        for (int j = 0; j < _mapData.MapWidth; j++) {
          GameObject generatedObject;
          switch (_mapData.MapData[i, j]) {
            case 1:
              generatedObject = Instantiate(Instantiate(_bigHouse));
              houseList.Add(generatedObject);
              houseTypeList.Add(1);
              ChangeGameObjectParameters(generatedObject, i ,j, 3);
              break;
            case 2:
              generatedObject = Instantiate(_tree);
              treeList.Add(generatedObject);
              ChangeGameObjectParameters(generatedObject, i ,j, 2);
              break;
            case 3:
              generatedObject = Instantiate(_bush);
              bushList.Add(generatedObject);
              ChangeGameObjectParameters(generatedObject, i ,j, 2);
              break;
            case 4:
              generatedObject = Instantiate(_rock);
              rockList.Add(generatedObject);
              ChangeGameObjectParameters(generatedObject, i ,j, 2);
              break;
            case -1:
              generatedObject = Instantiate(Instantiate(_smallHouse));
              houseList.Add(generatedObject);
              houseTypeList.Add(0);
              ChangeGameObjectParameters(generatedObject, i ,j, 3);
              break;
          }
        }
      }
    }
  }
}
