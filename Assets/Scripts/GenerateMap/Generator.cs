using Menu;
using UnityEngine;

namespace GenerateMap {
  public class Generator : MonoBehaviour {
    private ParameterManager _parameterManager;

    public void Start() {
      int[,] mapData;
      _parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      if (_parameterManager.NeedToLoad) {
        mapData = _parameterManager.MapData;
      } else {
        MapUnityGenerator generator = new MapUnityGenerator();
        mapData = generator.GenerateMapUnity();
      }

      Load(mapData);
    }

    private void Load(int[,] mapData) {
      MapLoaderUnity mapLoaderUnity = new MapLoaderUnity(mapData);
      mapLoaderUnity.MapLoad();
    }
  }
}