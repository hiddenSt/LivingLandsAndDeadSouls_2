using DataTransferObjects;
using GenerateMap.DataTransferObjects;
using GenerateMap.Strategies;
using UnityEngine;

namespace GenerateMap {
  public class MapController : MonoBehaviour {
    private ParameterManager _parameterManager;
    private const int _mapScalerSmall = 3;
    private const int _mapScalerMedium = 5;
    private const int _mapScalerBig = 12;
    private int _mapSize;
    private int[,] _mapData;

    public void Setup() {
      _parameterManager = ParameterManager.Instance;
      if (_parameterManager.NeedToLoad) {
        _mapData = ParameterManager.Instance.MapData;
      } else {
        MapGenerator generator = CreateGenerator();
        _mapData = generator.GenerateMap(_mapSize);
        ParameterManager.Instance.MapData = _mapData;
      }
    }

    public void LoadMap() {
      Load(_mapData);
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
        _parameterManager.ForestValue * currentScaler / 2, 6 * currentScaler, 2,
        _parameterManager.SizeOfForest * currentScaler, 5 * currentScaler));
      var bushGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parameterManager.ForestValue * currentScaler, 2 * currentScaler, 3, 4, 2));
      var rockGenerateStrategy = new GenerateLandscapeStrategy(new ZoneData(
        _parameterManager.ForestValue * currentScaler, 2 * currentScaler, 4, 4, 2));
      return new MapGenerator(buildingGenerateStrategy, forestGenerateStrategy,
        bushGenerateStrategy, rockGenerateStrategy);
    }
  }
}
