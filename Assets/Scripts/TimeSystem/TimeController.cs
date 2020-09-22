using DTOBetweenScenes;
using GenerateMap;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
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
      }
      else {
        rainGenerator.SetActive(false);
        snowGenerator.SetActive(false);
        _weatherIsActive = false;
      }
    }

    private void Start() {
      playerLight = GameObject.Find("Player").GetComponent<Light2D>();
      playerLight.intensity = 0;
      //light.color = new Vector4(0.83f, 0.81f, 0.42f, 1);
      _precipitation = ParameterManager.instance.precipitation;
      season = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().startSeason;
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
          }
          else {
            season += 1;
          }

          ChangeSeason();
        }
      }

      RainControl(_weatherChance);

      if (hour >= 3.5 && hour < 17 && light.intensity <= 1)
        light.intensity += 0.0015f;
      else if (light.intensity >= 0)
        light.intensity -= 0.0015f;

      if (light.intensity == 1) playerLight.intensity = 0;

      if (hour > 18 && hour < 22 && playerLight.intensity < 1) playerLight.intensity += 0.0025f;

      if (hour > 4 && hour < 8 && playerLight.intensity > 0) playerLight.intensity -= 0.0025f;

      dayYear.text = "Day " + day.ToString() + "\n Year " + year.ToString();
    }

    public void ChangeSeason() {
      switch (season) {
        case 0:
          _weatherChance = 2 * _precipitation;
          //light.color = new Vector4(0.95f, 0.76f, 0.35f, 1);
          generator.treeList.ForEach(tree => {
            var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/tri");
          });
          break;
        case 1:
          //light.color = new Vector4(1f, 1f, 1f, 1);
          _weatherChance = 10 * _precipitation;
          generator.treeList.ForEach(tree => {
            var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Yellow_Tree");
          });
          generator.bushList.ForEach(bush => {
            var spriteRenderer = bush.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Fall_Bush");
          });
          for (var x = 0; x < generator.width; x++)
          for (var y = 0; y < generator.height; y++)
            generator.landMap.SetTile(
              new Vector3Int(-x + generator.width / 2, -y + generator.height / 2, 0),
              generator.autumnTile);

          //light.color=new Vector4(0.96f, 0.59f, 0.03f, 1);
          break;

        case 2:
          _weatherChance = 10;
          generator.rockList.ForEach(rock => {
            var spriteRenderer = rock.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Winter_Rock");
          });
          generator.treeList.ForEach(tree => {
            var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Winter_Tree");
          });
          generator.bushList.ForEach(bush => {
            var spriteRenderer = bush.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Winter_Bush");
          });
          generator.houseList.ForEach(house => {
            var spriteRenderer = house.GetComponent<SpriteRenderer>();
            if (spriteRenderer.tag == "Small House")
              spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Winter_Small_House");
            else spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Winter_Big_House");
          });
          for (var x = 0; x < generator.width; x++)
          for (var y = 0; y < generator.height; y++)
            generator.landMap.SetTile(
              new Vector3Int(-x + generator.width / 2, -y + generator.height / 2, 0),
              generator.winterTile);

          //light.color = new Vector4(0.07f, 0.94f, 0.94f, 1);
          break;

        case 3:
          _weatherChance = 5 * _precipitation;
          generator.rockList.ForEach(rock => {
            var spriteRenderer = rock.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/ROCKKK");
          });
          generator.treeList.ForEach(tree => {
            var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Spring_Tree");
          });
          generator.houseList.ForEach(house => {
            var spriteRenderer = house.GetComponent<SpriteRenderer>();
            if (spriteRenderer.tag == "Small House")
              spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/gray_house1");
            else spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Big_House");
          });
          generator.bushList.ForEach(bush => {
            var spriteRenderer = bush.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/Bush");
          });

          for (var x = 0; x < generator.width; x++)
          for (var y = 0; y < generator.height; y++)
            generator.landMap.SetTile(
              new Vector3Int(-x + generator.width / 2, -y + generator.height / 2, 0),
              generator.landTile);
          break;
      }
    }

    private void ChangeTreeSprite(string path) {
      generator.treeList.ForEach(tree => {
        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/environment/" + path);
      });
    }

    //data members
    public Light2D light;
    public Light2D playerLight;
    public Text dayYear;
    public Generator generator;
    public GameObject rainGenerator;
    public GameObject snowGenerator;
    public float hour = 12;
    public float timeS = 0.01f;
    public int year = 0;
    public int season = 0;
    public int day = 0;
    public int weatherTTL;
    public double ch;

    private double _weatherChance = 2;
    private int _precipitation;
    private bool _weatherIsActive = false;
  }
}