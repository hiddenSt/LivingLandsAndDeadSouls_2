using Menu;
using UnityEngine;

namespace GenerateMap
{
  public class Generator : MonoBehaviour
  {
    private ParameterManager _parameterManager;
    public void Start() {
      _parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad){
        int[,] mapData = _parameterManager._mapData;
        Load(mapData);
      }
      else{
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