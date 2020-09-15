using GenerateMap.DataTransferObjects;
using GenerateMap.Strategies;
using Menu;
using UnityEngine;

namespace GenerateMap {
  public class MapUnityGenerator : MonoBehaviour {
    private GameObject _smallHouse;
    private GameObject _bigHouse;
    private GameObject _tree;
    private GameObject _bush;
    private GameObject _rock;
    private int _mapSize;
    private MapGenerator _generator;
    private GameObject _objectInstanceStorage;
    private ParameterManager _parametersManager;
    private const int _mapScalerSmall = 3;
    private const int _mapScalerMedium = 5;
    private const int _mapScalerBig = 20;
    private int _currentScaler;
    private int [,] _mapData;
  
    public MapUnityGenerator() {
      _parametersManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      switch (_parametersManager.tmpSize.x) {
        case 200:
          _mapSize = 200;
          _currentScaler = _mapScalerSmall;
          break;
        case 500:
          _mapSize = 500;
          _currentScaler = _mapScalerMedium;
          break;
        case 1000:
          _mapSize = 1000;
          _currentScaler = _mapScalerBig;
          break;
      }
      _objectInstanceStorage = GameObject.Find("ObjectInstanceStorage").gameObject;
      var buildingGenerateStrategy = new BuildingGenerateStrategy(new BuildingData(
        _parametersManager.buildingValue * _currentScaler / 2, 7 * _currentScaler, 1));
      var forestGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parametersManager.forestValue * _currentScaler, 7 * _currentScaler, 2, 
        _parametersManager.sizeOfForest * _currentScaler, 6 * _currentScaler));
      var bushGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parametersManager.forestValue * _currentScaler, 3 * _currentScaler, 3, 4, 1));
      var rockGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parametersManager.forestValue * _currentScaler, 3 * _currentScaler, 4, 4, 2));
      _generator = new MapGenerator(buildingGenerateStrategy, forestGenerateStrategy, 
        bushGenerateStrategy, rockGenerateStrategy);
    }

    private void FindObjectInstances() {
      _bigHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Big_house");
      _smallHouse = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Small_house");
      _tree = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Tree");
      _bush = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Bush");
      _rock = _objectInstanceStorage.GetComponent<InstancesStorage>().GetObjectInstance("Rock");
    }
  
    public void GenerateMapUnity() {
      FindObjectInstances();
      _generator.GenerateMap(_mapSize);
      _mapData = _generator.GetMapData();
      for (int i = 0; i < _mapSize; i++) {
        for (int j = 0; j < _mapSize; j++) {
          GameObject generatedObject;
          switch (_mapData[i, j]){
            case 1:
              generatedObject = Instantiate(Random.Range(0, 100) % 2 == 0 ? _smallHouse : _bigHouse);
              ChangeGameObjectParameters(generatedObject, i ,j);
              break;
            case 2:
              generatedObject = Instantiate(_tree);
              ChangeGameObjectParameters(generatedObject, i ,j);
              break;
            case 3:
              generatedObject = Instantiate(_bush);
              ChangeGameObjectParameters(generatedObject, i ,j);
              break;
            case 4:
              generatedObject = Instantiate(_rock);
              ChangeGameObjectParameters(generatedObject, i ,j);
              break;
          }
        }
      }
    }

    private void ChangeGameObjectParameters(GameObject changingObject, int xPos, int yPos) {
      changingObject.transform.localPosition = new Vector3(_mapSize / 2 - xPos, _mapSize / 2 - yPos ,1);
      changingObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = _mapSize / 2 - 
        (int) changingObject.transform.position.y + 4;
    }
  }
}
