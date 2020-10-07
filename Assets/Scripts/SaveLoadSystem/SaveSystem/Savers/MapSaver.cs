using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataTransferObjects;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.SaveSystem.Savers {

  public class MapSaver : ISaver {
    private string _fileName;
    

    public MapSaver(string fileName) {
      _fileName = fileName;
    }
    
    public void Save() {
      var mapData = new MapData();
      mapData.map = ParameterManager.instance.MapData;
      mapData.season = ParameterManager.instance.StartSeason;
      mapData.mapSizeX = ParameterManager.instance.MapSizeVector.x;
      mapData.mapSizeY = ParameterManager.instance.MapSizeVector.y;
      var binaryFormatter = new BinaryFormatter();
      var path = Application.persistentDataPath + _fileName;
      var fileStream = new FileStream(path, FileMode.Create);
      binaryFormatter.Serialize(fileStream, mapData);
      fileStream.Close();
    }
  }

}
