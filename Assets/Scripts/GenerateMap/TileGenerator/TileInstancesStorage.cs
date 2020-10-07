using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GenerateMap.TileGenerator {
  public class TileInstancesStorage : MonoBehaviour {
    public List<Tile> TileList;

    public Tile FindTile(string tileName) {
      for (int i = 0; i < TileList.Count; i++) {
        if (TileList[i].name == tileName) {
          return TileList[i];
        }
      }

      return null;
    }
  }
}