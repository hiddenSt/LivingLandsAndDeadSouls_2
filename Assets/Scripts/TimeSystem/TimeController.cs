using DataTransferObjects;
using GenerateMap;
using GenerateMap.TileGenerator;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace TimeSystem {

  public class TimeController : MonoBehaviour {
    private void RainControl(double chance) {
      if (_weatherIsActive == false) {
        ch = Random.Range(0, 7000);
        if (ch <= chance) {
          weatherTTL = Random.Range(300, 3000);
          if (season == 2)
            snowGenerator.SetActive(true);
          else
            rainGenerator.SetActive(true);
          _weatherIsActive = true;
        }
      }

      if (weatherTTL > 0) {
        weatherTTL -= 1;
      } else {
        rainGenerator.SetActive(false);
        snowGenerator.SetActive(false);
        _weatherIsActive = false;
      }
    }

    private void Start() {
      _mapWidth = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().MapSizeVector.x;
      _mapHeight = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().MapSizeVector.y;
      _landTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Grass");
      _winterTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Winter_grass");
      _fallTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("OrangeGrass");
      _landTileMap = GameObject.Find("LandTileMap").GetComponent<Tilemap>();
      playerLight = GameObject.Find("Player").GetComponent<Light2D>();
      playerLight.intensity = 0;
      _precipitation = ParameterManager.instance.Precipitation;
      season = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().StartSeason;
      ChangeSeason();
    }

    private void FixedUpdate() {
      hour += timeS;
      if (hour >= 24) {
        hour = 0f;
        day += 1;
        if (day % 10 == 0) {
          if (season == 3) {
            season = 0;
            year += 1;
          } else {
            season += 1;
          }

          ChangeSeason();
        }
      }

      RainControl(_weatherChance);
      if (hour >= 3.5 && hour < 17 && light.intensity <= 1) {
        light.intensity += 0.0015f;
      }
      else if (light.intensity >= 0) {
        light.intensity -= 0.0015f;
      }

      if (light.intensity == 1) {
        playerLight.intensity = 0;
      }

      if (hour > 18 && hour < 22 && playerLight.intensity < 1) {
        playerLight.intensity += 0.0025f;
      }

      if (hour > 4 && hour < 8 && playerLight.intensity > 0) {
        playerLight.intensity -= 0.0025f;
      }

      dayYear.text = "Day " + day + "\n Year " + year;
    }

    public void ChangeSeason() {
      _mapDataStorage = GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>();
      switch (season) {
        case 0:
          ChangeToSummer();
          break;
        case 1:
          ChangeToFall();
          break;
        case 2:
          ChangeToWinter();
          break;
        case 3:
          ChangeToSpring();
          break;
      }
    }

    public void ChangeToFall() {
      _weatherChance = 10 * _precipitation;
      ChangeTreesSprites("Sprites/environment/Yellow_Tree");
      ChangeBushesSprites("Sprites/environment/Fall_Bush");
      ChangeTile(_fallTile);
    }
    
    public void ChangeToSummer() {
      _weatherChance = 2 * _precipitation;
      ChangeTreesSprites("Sprites/environment/tri");
    }
    
    public void ChangeToWinter() {
      _weatherChance = 10;
      ChangeRocksSprites("Sprites/environment/Winter_Rock");
      ChangeTreesSprites("Sprites/environment/Winter_Tree");
      ChangeBushesSprites("Sprites/environment/Winter_Bush");
      ChangeHousesSprites("Sprites/environment/Winter_Small_House", "Sprites/environment/Winter_Big_House");
      ChangeTile(_winterTile);
    }

    public void ChangeToSpring() {
      _weatherChance = 5 * _precipitation;
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
    
    
    //data members
    public Light2D light;
    public Light2D playerLight;
    public Text dayYear;
    public GameObject rainGenerator;
    public GameObject snowGenerator;
    public float hour = 12;
    public float timeS = 0.01f;
    public int year = 0;
    public int season = 0;
    public int day = 0;
    public int weatherTTL;
    public double ch;

    private int _mapWidth;
    private int _mapHeight;
    private MapDataStorage _mapDataStorage;
    private Tile _landTile;
    private Tile _winterTile;
    private Tile _fallTile;
    private Tilemap _landTileMap;
    private double _weatherChance = 2;
    private int _precipitation;
    private bool _weatherIsActive = false;
  }

}