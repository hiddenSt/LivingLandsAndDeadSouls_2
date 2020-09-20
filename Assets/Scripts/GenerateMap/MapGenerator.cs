using GenerateMap.Strategies;

namespace GenerateMap {
  public class MapGenerator {
    private int[,] _mapData;

    public MapGenerator(BuildingGenerateStrategy buildingGenerateStrategy,
      GenerateLandscapeStrategy forestGenerateStrategy,
      GenerateLandscapeStrategy bushGenerateStrategy,
      GenerateLandscapeStrategy rockGenerateStrategy) {
      _buildingGenerateStrategy = buildingGenerateStrategy;
      _forestGenerateStrategy = forestGenerateStrategy;
      _bushGenerateStrategy = bushGenerateStrategy;
      _rockGenerateStrategy = rockGenerateStrategy;
    }

    public int[,] GenerateMap(int mapSize) {
      _mapData = new int[mapSize, mapSize];
      _mapData = _buildingGenerateStrategy.Generate(_mapData);
      _mapData = _forestGenerateStrategy.Generate(_mapData);
      _mapData = _rockGenerateStrategy.Generate(_mapData);
      _mapData = _bushGenerateStrategy.Generate(_mapData);
      return _mapData;
    }

    private BuildingGenerateStrategy _buildingGenerateStrategy;
    private GenerateLandscapeStrategy _forestGenerateStrategy;
    private GenerateLandscapeStrategy _bushGenerateStrategy;
    private GenerateLandscapeStrategy _rockGenerateStrategy;
  }
}