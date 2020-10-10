using System.Collections.Generic;
using DataTransferObjects;
using TimeSystem;
using UnityEngine;

namespace GenerateMap {
  public class MapLoaderUnity : MonoBehaviour {
    private GameObject _smallHouse;
    private GameObject _bigHouse;
    private GameObject _tree;
    private GameObject _bush;
    private GameObject _rock;
    private GameObject _objectInstanceStorage;
    private List<GameObject> _treeList;
    private List<GameObject> _rockList;
    private List<GameObject> _bushList;
    private List<GameObject> _houseList;
    private List<int> _houseTypeList;
    private int[,] _mapData;
    private ParameterManager _parameterManager;
    
    public MapLoaderUnity(int[,] mapData) {
      _parameterManager = ParameterManager.instance;
      _mapData = mapData;
      _objectInstanceStorage = GameObject.Find("Objects Instances Storage");
    }

    public void MapLoad() {
      TileLoad();
      FindObjectInstances();
      CreateMapDataStorage();
      InstantiateObjects();
      LoadMapDataStorage();
    }

    private void FindObjectInstances() {
      _bigHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance(
        "Big_house");
      _smallHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance(
        "Small_house");
      _tree = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Tree");
      _bush = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Bush");
      _rock = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Rock");
    }

    private void ChangeGameObjectParameters(GameObject changingObject, int xPos, int yPos,
      int extraLayerValue) {
      changingObject.transform.localPosition = new Vector3(_parameterManager.MapSizeVector.x / 2 - xPos,
        _parameterManager.MapSizeVector.y / 2 - yPos, 1);
      changingObject.GetComponentInChildren<SpriteRenderer>().sortingOrder =
        _parameterManager.MapSizeVector.y / 2 - (int) changingObject.transform.position.y +
        extraLayerValue;
    }

    private void TileLoad() {
      TileGenerator.TileGenerator tileGenerator = new TileGenerator.TileGenerator(15,
        _parameterManager.MapSizeVector.x);
      tileGenerator.GenerateHorizon();
      tileGenerator.GenerateLands();
    }


    private void CreateMapDataStorage() {
      _treeList = new List<GameObject>();
      _rockList = new List<GameObject>();
      _bushList = new List<GameObject>();
      _houseList = new List<GameObject>();
      _houseTypeList = new List<int>();
    }


    private void LoadMapDataStorage() {
      MapDataStorage mapDataStorage = GameObject.Find("Map Data Storage").GetComponent<MapDataStorage>();
      mapDataStorage.BushList = _bushList;
      mapDataStorage.TreeList = _treeList;
      mapDataStorage.RockList = _rockList;
      mapDataStorage.HouseList = _houseList;
      mapDataStorage.HouseTypeList = _houseTypeList;
    }

    private void InstantiateObjects() {
      for (int i = 0; i < _parameterManager.MapSizeVector.y; i++) {
        for (int j = 0; j < _parameterManager.MapSizeVector.y; j++) {
          GameObject generatedObject;
          switch (_mapData[i, j]) {
            case 1:
              generatedObject = Instantiate(_bigHouse);
              _houseList.Add(generatedObject);
              _houseTypeList.Add(1);
              ChangeGameObjectParameters(generatedObject, i, j, 3);
              break;
            case 2:
              generatedObject = Instantiate(_tree);
              _treeList.Add(generatedObject);
              ChangeGameObjectParameters(generatedObject, i, j, 2);
              break;
            case 3:
              generatedObject = Instantiate(_bush);
              _bushList.Add(generatedObject);
              ChangeGameObjectParameters(generatedObject, i, j, 2);
              break;
            case 4:
              generatedObject = Instantiate(_rock);
              _rockList.Add(generatedObject);
              ChangeGameObjectParameters(generatedObject, i, j, 2);
              break;
            case -1:
              generatedObject = Instantiate(_smallHouse);
              _houseList.Add(generatedObject);
              _houseTypeList.Add(0);
              ChangeGameObjectParameters(generatedObject, i, j, 3);
              break;
          }
        }
      }
    }
  }
}