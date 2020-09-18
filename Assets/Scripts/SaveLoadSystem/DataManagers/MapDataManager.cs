using GenerateMap;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveLoadSystem.DataManagers {
  public class MapDataManager : IDataManager {
    public MapDataManager(string filePath) {
      _filePath = filePath;
    }
    
    public void Save() {
      var generator = GameObject.Find("Generate").GetComponent<Generator>();
      var formatter = new BinaryFormatter();
    
      var season = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>().season;
      var year = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>().year;
      var day = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>().day;
      var data = new DTO.MapData(generator.bushList, generator.treeList, generator.rockList, generator.houseList,
        generator.houseTypeList, season, year, day, generator.tmpSize);
      var stream = new FileStream(_filePath, FileMode.Create);
      formatter.Serialize(stream, data);
      stream.Close();
    }

    public void Load() {
      if (!File.Exists(_filePath)) return;
      var formatter = new BinaryFormatter();
      var stream = new FileStream(_filePath, FileMode.Open);
      var data = formatter.Deserialize(stream) as DTO.MapData;
      stream.Close();
      var generator = GameObject.Find("Generate").GetComponent<Generator>();
      var tmpSize = new Vector3Int(data.tmpSizeX, data.tmpSizeY, data.tmpSizeZ);
      generator.GenerateMap(data, tmpSize);
      var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
      timeController.year = data.year;
      timeController.day = data.day;
    }

    public void DeleteSaves() {
      if (!File.Exists(_filePath)) return;
      File.Delete(_filePath);
    }

    private string _filePath;
  }
}