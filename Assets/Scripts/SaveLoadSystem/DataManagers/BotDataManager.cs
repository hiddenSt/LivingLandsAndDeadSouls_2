using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SaveLoadSystem.DataManagers {
  public class BotDataManager : IDataManager {
    public BotDataManager(string filePath) {
      _filePath = filePath;
    }

    public void Save() {
      var formatter = new BinaryFormatter();
      var data = new DTO.BotData(-100, 100, -100, 100,
        GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>().hostileCharVal,
        GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>().neutralCharVal);

      var stream = new FileStream(_filePath, FileMode.Create);
      formatter.Serialize(stream, data);
      stream.Close();
    }

    public void Load() {
      if (!File.Exists(_filePath)) return;
      var formatter = new BinaryFormatter();
      var stream = new FileStream(_filePath, FileMode.Open);
      var data = formatter.Deserialize(stream) as DTO.BotData;
      stream.Close();
      var parameterManager = GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>();
      parameterManager.hostileCharVal = data.enemyCount;
      parameterManager.neutralCharVal = data.animalsCount;
    }

    public void DeleteSaves() {
      if (!File.Exists(_filePath)) return;
      File.Delete(_filePath);
    }

    private string _filePath;
  }
}