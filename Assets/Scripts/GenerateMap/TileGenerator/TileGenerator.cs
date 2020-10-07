using UnityEngine;
using UnityEngine.Tilemaps;

namespace GenerateMap.TileGenerator {
  public class TileGenerator : MonoBehaviour {
    private int _horizonWidth;
    private int _mapSize;
    private Tilemap _horizonTileMap;
    private Tilemap _landTileMap;
    private Tile _horizonTile;
    public Tile _landTile;

    public TileGenerator(int horizonWidth, int mapSize) {
      _mapSize = mapSize;
      _horizonWidth = horizonWidth;
      _landTileMap = GameObject.Find("LandTileMap").GetComponent<Tilemap>();
      _horizonTileMap = GameObject.Find("HorizonTileMap").GetComponent<Tilemap>();
      _horizonTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Water");
      _landTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Grass");
    }

    public void GenerateHorizon() {
      for (int i = 0; i < _horizonWidth; ++i) {
        for (int x = -_horizonWidth; x < _mapSize + _horizonWidth; ++x)
          _horizonTileMap.SetTile(new Vector3Int(-x + _mapSize / 2, -_mapSize / 2 - i, 0),
            _horizonTile);
        for (int x = -_horizonWidth; x < _mapSize + _horizonWidth; ++x)
          _horizonTileMap.SetTile(new Vector3Int(-x + _mapSize / 2, _mapSize / 2 + 1 + i, 0),
            _horizonTile);
        for (int y = 0; y < _mapSize; ++y)
          _horizonTileMap.SetTile(new Vector3Int(-_mapSize / 2 - i, -y + _mapSize / 2, 0),
            _horizonTile);
        for (int y = 0; y < _mapSize; ++y)
          _horizonTileMap.SetTile(new Vector3Int(_mapSize / 2 + 1 + i, -y + _mapSize / 2, 0),
            _horizonTile);
      }
    }

    public void GenerateLands() {
      for (int x = 0; x < _mapSize; x++) {
        for (int y = 0; y < _mapSize; y++) {
          _landTileMap.SetTile(new Vector3Int(-x + _mapSize / 2, -y + _mapSize / 2, 0), _landTile);
        }
      }
    }
  }
}
