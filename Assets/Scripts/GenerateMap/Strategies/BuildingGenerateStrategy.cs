using System;
using GenerateMap.DataTransferObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GenerateMap.Strategies {
  public class BuildingGenerateStrategy : IGenerator {
    private BuildingData _data;
    private int _mapCountrySize;

    public BuildingGenerateStrategy(BuildingData data) {
      _data = data;
    }

    public int[,] Generate(int[,] mapData) {
      Debug.Log("Value" + _data.Value);
      _mapCountrySize = (int) Math.Sqrt(mapData.Length);
      for (int i = 0; i < _data.Value; i++){
        var coordinates = GenerateBuildingCoordinates(_data.DistanceFromAnotherObjects, mapData);
        if (coordinates == null) continue;
        if (Random.Range(0, 100) % 2 == 0)
          mapData[coordinates[0], coordinates[1]] = _data.ObjectCode;
        else 
          mapData[coordinates[0], coordinates[1]] = -_data.ObjectCode;
      }
      return mapData;
    }

    bool FindContent(int x, int y, int distanceFromAnotherObjects, int[,] mapData) {
      var checker = true;
      for (var i = x - distanceFromAnotherObjects; i < x + distanceFromAnotherObjects; i++) {
        for (var j = y - distanceFromAnotherObjects; j < y + distanceFromAnotherObjects; j++) {
          if (i >= _mapCountrySize || j >= _mapCountrySize || i <= 0 || j <= 0){
            return false;
          }
          if (mapData[i, j] == 0) continue;
          checker = false;
          break;
        }
        if (checker == false) {
          break;
        }
      }
      return checker;
    }

    int[] GenerateBuildingCoordinates(int distanceFromAnotherObject, int[,] mapData) {
      int errors = 0;
      while (true) {
        errors++;
        if (errors > 1000) {
          return null;
        }
        int xParent = Random.Range(0, _mapCountrySize);
        int yParent = Random.Range(0, _mapCountrySize);
        bool canGenerate = FindContent(xParent, yParent, distanceFromAnotherObject, mapData);
        if (!canGenerate) continue;
        return new[]{xParent, yParent};
      }
    }
  }
}
