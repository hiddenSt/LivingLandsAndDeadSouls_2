using System;
using GenerateMap.DataTransferObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GenerateMap.Strategies {
  public class GenerateLandscapeStrategy : IGenerator {
    private int _mapCountrySize;
    private ZoneData _data;
    
    public GenerateLandscapeStrategy(ZoneData data) {
      _data = data;
    }

    public int[,] Generate(int [,] mapData) {
      Debug.Log("Value"+_data.Value);
      _mapCountrySize = (int) Math.Sqrt(mapData.Length);
      for (int i = 0; i < _data.Value; i++){
        var parentCoordinates = GenerateZoneCenterCoordinates(_data.DistanceFromAnotherObjects, mapData);
        if (parentCoordinates == null) {
          return mapData;
        }
        int xParent = parentCoordinates[0];
        int yParent = parentCoordinates[1];
        mapData[xParent, yParent] = _data.ObjectCode;
        for (var j = 0; j < _data.PlaceSize; j++) {
          int[] objectCoordinates = {Random.Range(xParent - _data.PlaceDistance, xParent +
              _data.PlaceDistance), Random.Range(yParent - _data.PlaceDistance, yParent + 
            _data.PlaceDistance)
          };
          mapData[objectCoordinates[0], objectCoordinates[1]] = _data.ObjectCode;
        }
      }
      return mapData;
    }

    bool FindContent(int x, int y, int distanceFromAnotherObjects, int[,] mapData) {
      var checker = true;
      for (var i = x - distanceFromAnotherObjects; i < x + distanceFromAnotherObjects; i++) {
        for (var j = y - distanceFromAnotherObjects; j < y + distanceFromAnotherObjects; j++) {
          if (i >= _mapCountrySize || j >= _mapCountrySize || i <= 0 || j <= 0) {
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
    
    int[] GenerateZoneCenterCoordinates(int distanceFromAnotherObject, int [,] mapData) {
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