using GenerateMap;
using GenerateMap.TileGenerator;
using Menu;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace TimeSystem {
    public class TimeController : MonoBehaviour {
      
      public Light2D Light;
      public Light2D PlayerLight;
      public Text DayYear;
      public Generator Generator;
      public GameObject RainGenerator;
      public GameObject SnowGenerator;
      public float Hour = 12;
      public float TimeS = 0.01f;
      public int Year = 0;
      public int Season = 0;
      public int Day = 0;
      public int WeatherTTL;
      public double Ch;
        
      private int _mapWidth;
      private int _mapHeight;
      private double _weatherChance = 2;
      private int _precipitation;
      private bool _weatherIsActive = false;
      private MapDataStorage _mapDataStorage;
      private Tile _landTile;
      private Tile _winterTile;
      private Tile _autumnTile;
      private Tilemap _landTileMap;

      
        void RainControl(double chance) {
            if (_weatherIsActive == false) {
                Ch = Random.Range(0, 7000);
                if (Ch <= chance) {
                    WeatherTTL = Random.Range(300, 3000);
                    if (Season == 2)
                        SnowGenerator.SetActive(true);
                    else
                        RainGenerator.SetActive(true);
                    _weatherIsActive = true;
                }
            }
            if (WeatherTTL > 0) {
                WeatherTTL -= 1;
            }
            else { 
                RainGenerator.SetActive(false);
                SnowGenerator.SetActive(false);
                _weatherIsActive = false;
            }
        }

        void Start() {
            _mapWidth = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().MapSizeVector.x;
            _mapHeight = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().MapSizeVector.y;
            _landTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Grass");
            _winterTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Winter_grass");
            _autumnTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("OrangeGrass");
            _landTileMap = GameObject.Find("LandTileMap").GetComponent<Tilemap>();
            PlayerLight = GameObject.Find("Player").GetComponent<Light2D>();
            PlayerLight.intensity = 0;
            _precipitation = ParameterManager.Instance.Precipitation;
            Season = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().StartSeason;
            ChangeSeason();
        }

        void FixedUpdate() {
            Hour += TimeS;
            if (Hour >= 24) {
                Hour = 0f;
                Day += 1;
                if (Day % 10 == 0) {
                    if (Season == 3) {
                        Season = 0;
                        Year += 1;
                    }
                    else Season += 1;
                    ChangeSeason();
                }
            }
            RainControl(_weatherChance);
            if (Hour >= 3.5 && Hour < 17 && Light.intensity <= 1) {
                Light.intensity += 0.0015f;
            } else if (Light.intensity >= 0) {
              Light.intensity -= 0.0015f;
            }
            if (Light.intensity == 1) {
                PlayerLight.intensity = 0;
            }
            if (Hour > 18 && Hour < 22 && PlayerLight.intensity < 1) {
                PlayerLight.intensity += 0.0025f;
            }
            if (Hour > 4 && Hour < 8 && PlayerLight.intensity > 0) {
                PlayerLight.intensity -= 0.0025f;
            }
            DayYear.text = "Day " + Day + "\n Year " + Year;
        }

        public void ChangeSeason() {
          _mapDataStorage = GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>();
          switch (Season) {
                case 0:
                    _weatherChance = 2 * _precipitation;
                    _mapDataStorage.TreeList.ForEach(tree => {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/tri");
                    });
                    break;
                case 1:
                    _weatherChance = 10 * _precipitation;
                    _mapDataStorage.TreeList.ForEach(tree => {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Yellow_Tree");
                    });
                    _mapDataStorage.BushList.ForEach(bush => {
                        var spriteRenderer = bush.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Fall_Bush");
                    });
                    for (int x = 0; x < _mapWidth; x++) {
                        for (int y = 0; y < _mapHeight; y++) {
                            _landTileMap.SetTile(
                                new Vector3Int(-x + _mapWidth / 2, -y + _mapHeight / 2, 0),
                                _autumnTile);
                        }
                    }
                    break;
                case 2:
                    _weatherChance = 10;
                    _mapDataStorage.RockList.ForEach(rock => {
                        var spriteRenderer = rock.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Winter_Rock");
                    });
                    _mapDataStorage.TreeList.ForEach(tree => {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Winter_Tree");
                    });
                    _mapDataStorage.BushList.ForEach(bush => {
                        var spriteRenderer = bush.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Winter_Bush");
                    });
                    _mapDataStorage.HouseList.ForEach(house => {
                        var spriteRenderer = house.GetComponent<SpriteRenderer>();
                        if (spriteRenderer.tag == "Small House")
                            spriteRenderer.sprite = Resources.Load<Sprite>(
                              "Sprites/environment/Winter_Small_House");
                        else spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Winter_Big_House");
                    });
                    for (int x = 0; x < _mapWidth; x++) {
                        for (int y = 0; y < _mapHeight; y++) {
                            _landTileMap.SetTile(
                                new Vector3Int(-x + _mapWidth / 2, -y + _mapHeight / 2, 0),
                                _winterTile);
                        }
                    }
                    break;
                case 3:
                    _weatherChance = 5 * _precipitation;
                    _mapDataStorage.RockList.ForEach(rock => {
                        var spriteRenderer = rock.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/ROCKKK");
                    });
                    _mapDataStorage.TreeList.ForEach(tree => {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Spring_Tree");
                    });
                    _mapDataStorage.HouseList.ForEach(house => {
                        var spriteRenderer = house.GetComponent<SpriteRenderer>();
                        if (spriteRenderer.tag == "Small House")
                            spriteRenderer.sprite = Resources.Load<Sprite>(
                              "Sprites/environment/gray_house1");
                        else spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Big_House");
                    });
                    _mapDataStorage.BushList.ForEach(bush => {
                        var spriteRenderer = bush.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = Resources.Load<Sprite>(
                          "Sprites/environment/Bush");
                    });
                    for (int x = 0; x < _mapWidth; x++) {
                        for (int y = 0; y < _mapHeight; y++) {
                            _landTileMap.SetTile(
                                new Vector3Int(-x + _mapWidth / 2, -y + _mapHeight / 2, 0),
                                _landTile);
                        }
                    }
                    break;
            }
        }
    }
}
