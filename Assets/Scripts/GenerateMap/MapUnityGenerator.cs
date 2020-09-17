using GenerateMap.DataTransferObjects;
using GenerateMap.Strategies;
using Menu;
using UnityEngine;

namespace GenerateMap {
  public class MapUnityGenerator : MonoBehaviour {
    private int _mapSize;
    private MapGenerator _generator;
    private ParameterManager _parametersManager;
    private const int _mapScalerSmall = 3;
    private const int _mapScalerMedium = 5;
    private const int _mapScalerBig = 20;
    private int _currentScaler;
    private int[,] _mapData;

    public MapUnityGenerator() {
      _parametersManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      _mapSize = _parametersManager.MapSizeVector.x;
      switch (_mapSize) {
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
      var buildingGenerateStrategy = new BuildingGenerateStrategy(new BuildingData(
        _parametersManager.BuildingValue * _currentScaler / 2, 7 * _currentScaler, 1));
      var forestGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parametersManager.ForestValue * _currentScaler, 7 * _currentScaler, 2, 
        _parametersManager.SizeOfForest * _currentScaler, 5 * _currentScaler));
      var bushGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parametersManager.ForestValue * _currentScaler, 7 * _currentScaler, 3, 4, 2));
      var rockGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parametersManager.ForestValue * _currentScaler, 7 * _currentScaler, 4, 4, 2));
      _generator = new MapGenerator(buildingGenerateStrategy, forestGenerateStrategy, 
        bushGenerateStrategy, rockGenerateStrategy);
    }

    public int[,] GenerateMapUnity() {
      _mapData = _generator.GenerateMap(_mapSize);
      return _mapData;
    }
  }
}
