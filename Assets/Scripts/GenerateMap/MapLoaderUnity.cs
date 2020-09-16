using System.Collections.Generic;
using Menu;
using UnityEngine;

namespace GenerateMap {
  public class MapLoaderUnity : MonoBehaviour {
    private GameObject _smallHouse;
    private GameObject _bigHouse;
    private GameObject _tree;
    private GameObject _bush;
    private GameObject _rock;
    private GameObject _objectInstanceStorage;
    private List<GameObject> treeList;
    private List<GameObject> rockList;
    private List<GameObject> bushList;
    private List<GameObject> houseList;
    private List<int> houseTypeList;
    private int[,] _mapData;
    private ParameterManager _parameterManager;
    private int _season;

    public MapLoaderUnity(int [,] mapData) {
      _parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      _mapData = mapData;
      _season = _parameterManager.startSeason;
      _objectInstanceStorage = GameObject.Find("ObjectInstanceStorage");
    }
    
    public void MapLoad() {
      TileLoad();
      FindObjectInstances();
      CreateMapDataStorage();
      InstantiateObjects();
      LoadMapDataStorage();
      LoadTimeControlParameters();
    }
    
    private void FindObjectInstances() {
      _bigHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Big_house");
      _smallHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Small_house");
      _tree = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Tree");
      _bush = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Bush");
      _rock = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Rock");
    }
    
    private void ChangeGameObjectParameters(GameObject changingObject, int xPos, int yPos, int extraLayerValue) {
      changingObject.transform.localPosition = new Vector3(_parameterManager.tmpSize.x / 2 - xPos, 
        _parameterManager.tmpSize.y / 2 - yPos ,1);
      changingObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = _parameterManager.tmpSize.y / 2 - 
        (int) changingObject.transform.position.y + extraLayerValue;
    }

    private void LoadTimeControlParameters() {
      var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
      timeController.season = _season;
      timeController.ChangeSeason();
    }

    private void TileLoad() {
      TileGenerator.TileGenerator tileGenerator = new TileGenerator.TileGenerator(15, _parameterManager.tmpSize.x);
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


    private void LoadMapDataStorage(){
      MapDataStorage mapDataStorage = GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>();
      GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>().BushList = bushList;
      GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>().TreeList = treeList;
      GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>().RockList = rockList;
      GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>().HouseList = houseList;
      GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>().HouseTypeList = houseTypeList;
    }
    
    private void InstantiateObjects() {
      for (int i = 0; i < _parameterManager.tmpSize.y; i++) {
        for (int j = 0; j < _parameterManager.tmpSize.y; j++) {
          GameObject generatedObject;
          switch (_mapData[i, j]) {
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
