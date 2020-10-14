using GenerateMap;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace TimeSystem {

  public class SeasonChanger {
    private int _mapWidth;
    private int _mapHeight;
    private MapDataStorage _mapDataStorage;
    private Tile _landTile;
    private Tile _winterTile;
    private Tile _fallTile;
    private Tilemap _landTileMap;

    public SeasonChanger(int mapWidth, int mapHeight, MapDataStorage mapDataStorage, Tile landTile, Tile winterTile, Tile fallTile, Tilemap landTileMap) {
      _mapWidth = mapWidth;
      _mapHeight = mapHeight;
      _mapDataStorage = mapDataStorage;
      _landTile = landTile;
      _winterTile = winterTile;
      _fallTile = fallTile;
      _landTileMap = landTileMap;
    }

    public void ChangeToFall() {
      ChangeTreesSprites("Sprites/environment/Yellow_Tree");
      ChangeBushesSprites("Sprites/environment/Fall_Bush");
      ChangeTile(_fallTile);
    }

    public void ChangeToSummer() {
      ChangeTreesSprites("Sprites/environment/tri");
    }

    public void ChangeToWinter() {
      ChangeRocksSprites("Sprites/environment/Winter_Rock");
      ChangeTreesSprites("Sprites/environment/Winter_Tree");
      ChangeBushesSprites("Sprites/environment/Winter_Bush");
      ChangeHousesSprites("Sprites/environment/Winter_Small_House", "Sprites/environment/Winter_Big_House");
      ChangeTile(_winterTile);
    }

    public void ChangeToSpring() {
      ChangeRocksSprites("Sprites/environment/ROCKKK");
      ChangeTreesSprites("Sprites/environment/Spring_Tree");
      ChangeHousesSprites("Sprites/environment/gray_house1", "Sprites/environment/Big_House");
      ChangeBushesSprites("Sprites/environment/Bush");
      ChangeTile(_landTile);
    }

    private void ChangeRocksSprites(string spritePath) {
      _mapDataStorage.RockList.ForEach(rock => {
        var spriteRenderer = rock.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(
          spritePath);
      });
    }

    private void ChangeTreesSprites(string spritePath) {
      _mapDataStorage.TreeList.ForEach(tree => {
        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(
          spritePath);
      });
    }

    private void ChangeHousesSprites(string smallHouseSpritePath, string bigHouseSpritePath) {
      _mapDataStorage.HouseList.ForEach(house => {
        var spriteRenderer = house.GetComponent<SpriteRenderer>();
        if (spriteRenderer.tag == "Small House")
          spriteRenderer.sprite = Resources.Load<Sprite>(
            smallHouseSpritePath);
        else
          spriteRenderer.sprite = Resources.Load<Sprite>(
            bigHouseSpritePath);
      });
    }

    private void ChangeBushesSprites(string spritePath) {
      _mapDataStorage.BushList.ForEach(bush => {
        var spriteRenderer = bush.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(
          spritePath);
      });
    }

    private void ChangeTile(Tile tile) {
      for (int x = 0; x < _mapWidth; x++) {
        for (int y = 0; y < _mapHeight; y++) {
          _landTileMap.SetTile(
            new Vector3Int(-x + _mapWidth / 2, -y + _mapHeight / 2, 0),
            tile);
        }
      }
    }
  }

}