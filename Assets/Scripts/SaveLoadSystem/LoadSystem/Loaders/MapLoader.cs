using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataTransferObjects;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.LoadSystem.Loaders {

  public class MapLoader : ILoader {
    private string _fileName;
    private MapData _mapData;

    public MapLoader(string fileName) {
      _fileName = fileName;
    }

    public void Load() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      var binaryFormatter = new BinaryFormatter();
      var fileStream = new FileStream(path, FileMode.Open);
      _mapData = binaryFormatter.Deserialize(fileStream) as MapData;
      fileStream.Close();
      ParameterManager.instance.MapData = _mapData.map;
      ParameterManager.instance.MapSizeVector = new Vector3Int(_mapData.mapSizeX, _mapData.mapSizeY, 0);
      ParameterManager.instance.NeedToLoad = true;
    }

    public void DeleteSaves() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      File.Delete(path);
    }
  }

}
