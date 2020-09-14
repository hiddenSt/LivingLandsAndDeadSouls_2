using GenerateMap.Strategies;
using UnityEngine;

namespace GenerateMap {
  public class MapGenerator : MonoBehaviour  {
    public MapGenerator(BuildingGenerateStrategy buildingGenerateStrategy, 
      GenerateLandscapeStrategy forestGenerateStrategy, 
      GenerateLandscapeStrategy bushGenerateStrategy, 
      GenerateLandscapeStrategy rockGenerateStrategy) {
      _buildingGenerateStrategy = buildingGenerateStrategy;
      _forestGenerateStrategy = forestGenerateStrategy;
      _bushGenerateStrategy = bushGenerateStrategy;
      _rockGenerateStrategy = rockGenerateStrategy;
    }
  
    public void GenerateMap(int[,] mapData) {
      _buildingGenerateStrategy.Generate(mapData);
      _forestGenerateStrategy.Generate(mapData);
      _rockGenerateStrategy.Generate(mapData);
      _bushGenerateStrategy.Generate(mapData);
    }
  
    private BuildingGenerateStrategy _buildingGenerateStrategy;
    private GenerateLandscapeStrategy _forestGenerateStrategy;
    private GenerateLandscapeStrategy _bushGenerateStrategy;
    private GenerateLandscapeStrategy _rockGenerateStrategy;
  }
}
