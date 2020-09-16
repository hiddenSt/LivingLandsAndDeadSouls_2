using GenerateMap;
using GenerateMap.TileGenerator;
using Menu;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace TimeSystem
{
    public class TimeController : MonoBehaviour
    {
        void RainControl(double chance)
        {
            if (_weatherIsActive == false)
            {
                ch = Random.Range(0, 7000);
                if (ch <= chance)
                {
                    weatherTTL = Random.Range(300, 3000);
                    if (season == 2)
                        snowGenerator.SetActive(true);
                    else
                        rainGenerator.SetActive(true);
                    _weatherIsActive = true;
                }
            }

            if (weatherTTL > 0)
            {
                weatherTTL -= 1;
            }
            else
            { 
                rainGenerator.SetActive(false);
                snowGenerator.SetActive(false);
                _weatherIsActive = false;
            }
        }

        void Start(){
            _mapWidth = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().tmpSize.x;
            _mapHeight = GameObject.Find("ParametersManager").GetComponent<ParameterManager>().tmpSize.y;
            LandTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Grass");
            WinterTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("Winter_grass");
            AutumnTile = GameObject.Find("TileStorage").GetComponent<TileInstancesStorage>().FindTile("OrangeGrass");
            LandTileMap = GameObject.Find("LandTileMap").GetComponent<Tilemap>();
            playerLight = GameObject.Find("Player").GetComponent<Light2D>();
            playerLight.intensity = 0;
            //light.color = new Vector4(0.83f, 0.81f, 0.42f, 1);
            _precipitation = Menu.ParameterManager.instance.precipitation;
            season = GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>().startSeason;
            ChangeSeason();
        }

        void FixedUpdate()
        {
            hour += timeS;
            if (hour >= 24)
            {
                hour = 0f;
                day += 1;
                if (day % 10 == 0)
                {
                    if (season == 3)
                    {
                        season = 0;
                        year += 1;
                    }
                    else season += 1;
                    ChangeSeason();
                }
            }
            RainControl(_weatherChance);

            if (hour >= 3.5 && hour < 17 && light.intensity <= 1)
            {
                light.intensity += 0.0015f;
            }
            else if (light.intensity >= 0)
                light.intensity -= 0.0015f;

            if (light.intensity == 1)
            {
                playerLight.intensity = 0;
            }
            if (hour > 18 && hour < 22 && playerLight.intensity < 1)
            {
                playerLight.intensity += 0.0025f;
            }

            if (hour > 4 && hour < 8 && playerLight.intensity > 0)
            {
                playerLight.intensity -= 0.0025f;
            }
            dayYear.text = "Day " + day.ToString() + "\n Year " + year.ToString();
        }

        public void ChangeSeason()
        {
          _mapDataStorage = GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>();
          Debug.Log("Tree"+GameObject.Find("MapDataStorage").GetComponent<MapDataStorage>().TreeList.Count);
            switch (season)
            {
                case 0:
                    _weatherChance = 2 * _precipitation;
                    //light.color = new Vector4(0.95f, 0.76f, 0.35f, 1);
                    _mapDataStorage.TreeList.ForEach(tree =>
                    {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/tri");
                    });
                    break;
                case 1:
                    //light.color = new Vector4(1f, 1f, 1f, 1);
                    _weatherChance = 10 * _precipitation;
                    _mapDataStorage.TreeList.ForEach(tree =>
                    {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Yellow_Tree");
                    });
                    _mapDataStorage.BushList.ForEach(bush =>
                    {
                        var spriteRenderer = bush.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Fall_Bush");
                    });
                    for (int x = 0; x < _mapWidth; x++)
                    {
                        for (int y = 0; y < _mapHeight; y++)
                        {
                            LandTileMap.SetTile(
                                new Vector3Int(-x + _mapWidth / 2, -y + _mapHeight / 2, 0),
                                AutumnTile);
                        }
                    }

                    //light.color=new Vector4(0.96f, 0.59f, 0.03f, 1);
                    break;

                case 2:
                    _weatherChance = 10;
                    _mapDataStorage.RockList.ForEach(rock =>
                    {
                        var spriteRenderer = rock.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Rock");
                    });
                    _mapDataStorage.TreeList.ForEach(tree =>
                    {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Tree");
                    });
                    _mapDataStorage.BushList.ForEach(bush =>
                    {
                        var spriteRenderer = bush.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Bush");

                    });
                    _mapDataStorage.HouseList.ForEach(house =>
                    {
                        var spriteRenderer = house.GetComponent<SpriteRenderer>();
                        if (spriteRenderer.tag == "Small House")
                            spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Small_House");
                        else spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Winter_Big_House");
                    });
                    for (int x = 0; x < _mapWidth; x++)
                    {
                        for (int y = 0; y < _mapHeight; y++)
                        {
                            LandTileMap.SetTile(
                                new Vector3Int(-x + _mapWidth / 2, -y + _mapHeight / 2, 0),
                                WinterTile);
                        }
                    }

                    //light.color = new Vector4(0.07f, 0.94f, 0.94f, 1);
                    break;

                case 3:
                    _weatherChance = 5 * _precipitation;
                    _mapDataStorage.RockList.ForEach(rock =>
                    {
                        var spriteRenderer = rock.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/ROCKKK");

                    });
                    _mapDataStorage.TreeList.ForEach(tree =>
                    {
                        var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Spring_Tree");

                    });
                    _mapDataStorage.HouseList.ForEach(house =>
                    {
                        var spriteRenderer = house.GetComponent<SpriteRenderer>();
                        if (spriteRenderer.tag == "Small House")
                            spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/gray_house1");
                        else spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Big_House");
                    });
                    _mapDataStorage.BushList.ForEach(bush =>
                    {
                        var spriteRenderer = bush.GetComponent<SpriteRenderer>();
                        spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/Bush");
                    });
                    
                    for (int x = 0; x < _mapWidth; x++)
                    {
                        for (int y = 0; y < _mapHeight; y++)
                        {
                            LandTileMap.SetTile(
                                new Vector3Int(-x + _mapWidth / 2, -y + _mapHeight / 2, 0),
                                LandTile);
                        }
                    }
                    break;
            }
        }

        private void ChangeTreeSprite(string path)
        {
          _mapDataStorage.TreeList.ForEach(tree =>
            {
                var spriteRenderer = tree.GetComponentInChildren<SpriteRenderer>();
                spriteRenderer.sprite = UnityEngine.Resources.Load<Sprite>("Sprites/environment/" + path);
            });
        }
        
        //data members
        private MapDataStorage _mapDataStorage;
        private Tile LandTile;
        private Tile WinterTile;
        private Tile AutumnTile;
        private Tilemap LandTileMap;
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
        private int _mapWidth;
        private int _mapHeight;
        private double _weatherChance = 2;
        private int _precipitation;
        private bool _weatherIsActive = false;

    }
}//end of namespace Time
