using DataTransferObjects;
using GenerateMap.DataTransferObjects;
using GenerateMap.Strategies;
using UnityEngine;

namespace GenerateMap {
  public class MapController : MonoBehaviour {
    private ParameterManager _parameterManager;
    private const int _mapScalerSmall = 3;
    private const int _mapScalerMedium = 5;
    private const int _mapScalerBig = 20;
    private int _mapSize;

    public void Start() {
      int[,] mapData;
      _parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      if (_parameterManager.NeedToLoad) {
        mapData = _parameterManager.MapData;
      } else {
        MapGenerator generator = CreateGenerator();
        mapData = generator.GenerateMap(_mapSize);
      }

      Load(mapData);
    }

    private void Load(int[,] mapData) {
      MapLoaderUnity mapLoaderUnity = new MapLoaderUnity(mapData);
      mapLoaderUnity.MapLoad();
    }

    private MapGenerator CreateGenerator() {
      _mapSize = _parameterManager.MapSizeVector.x;
      int currentScaler = 0;
      switch (_mapSize) {
        case 200:
          currentScaler = _mapScalerSmall;
          break;
        case 500:
          currentScaler = _mapScalerMedium;
          break;
        case 1000:
          currentScaler = _mapScalerBig;
          break;
      }

      var buildingGenerateStrategy = new BuildingGenerateStrategy(new BuildingData(
        _parameterManager.BuildingValue * currentScaler / 2, 7 * currentScaler, 1));
      var forestGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parameterManager.ForestValue * currentScaler, 7 * currentScaler, 2,
        _parameterManager.SizeOfForest * currentScaler, 5 * currentScaler));
      var bushGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parameterManager.ForestValue * currentScaler, 7 * currentScaler, 3, 4, 2));
      var rockGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parameterManager.ForestValue * currentScaler, 7 * currentScaler, 4, 4, 2));
      return new MapGenerator(buildingGenerateStrategy, forestGenerateStrategy,
        bushGenerateStrategy, rockGenerateStrategy);
    }
  }
}
