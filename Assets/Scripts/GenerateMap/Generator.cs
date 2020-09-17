using Menu;
using UnityEngine;

namespace GenerateMap {
  public class Generator : MonoBehaviour {
    private ParameterManager _parameterManager;
    public void Start() {
      _parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      if (_parameterManager.NeedToLoad) {
        int[,] mapData = _parameterManager.MapData;
        Load(mapData);
      }
      else {
        MapUnityGenerator generator = new MapUnityGenerator();
        int[,] mapData = generator.GenerateMapUnity();
        Load(mapData);
      }
    }

    private void Load(int [,] mapData) {
      MapLoaderUnity mapLoaderUnity = new MapLoaderUnity(mapData);
      mapLoaderUnity.MapLoad();
    }
  }
}