using DataTransferObjects;
using GenerateMap;
using GenerateMap.TileGenerator;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace TimeSystem {

  public class TimeController : MonoBehaviour {
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

    private SeasonChanger _seasonChanger;
    private double _weatherChance = 2;
    private int _precipitation;
    private bool _weatherIsActive = false;
    
    private void RainControl(double chance) {
      if (_weatherIsActive == false) {
        ch = Random.Range(0, 7000);
        if (ch <= chance) {
          weatherTTL = Random.Range(300, 3000);
          if (season == 2) {
            snowGenerator.SetActive(true);
          } else {
            rainGenerator.SetActive(true);
          }

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

    public void SetUp(TileInstancesStorage tileInstancesStorage, Tilemap landTileMap, MapDataStorage mapDataStorage) {
      var mapWidth = ParameterManager.instance.MapSizeVector.x;
      var mapHeight = ParameterManager.instance.MapSizeVector.y;
      var landTile = tileInstancesStorage.FindTile("Grass");
      var winterTile = tileInstancesStorage.FindTile("Winter_grass");
      var fallTile = tileInstancesStorage.FindTile("OrangeGrass");
      //var landTileMap = GameObject.Find("LandTileMap").GetComponent<Tilemap>();
      playerLight = GameObject.Find("Player").GetComponent<Light2D>();
      playerLight.intensity = 0;
      _precipitation = ParameterManager.instance.Precipitation;
      season = ParameterManager.instance.StartSeason;
      
      _seasonChanger = new SeasonChanger(mapWidth, mapHeight, mapDataStorage, landTile, winterTile, fallTile, landTileMap);
      
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

    private void ChangeDayTime() {
      
    }

    private void ChangeSeason() {
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
      _seasonChanger.ChangeToFall();
    }
    
    public void ChangeToSummer() {
      _weatherChance = 2 * _precipitation;
      _seasonChanger.ChangeToSummer();
    }
    
    public void ChangeToWinter() {
      _weatherChance = 10;
      _seasonChanger.ChangeToWinter();
    }

    public void ChangeToSpring() {
      _weatherChance = 5 * _precipitation;
      _seasonChanger.ChangeToSpring();
    }
  }

}