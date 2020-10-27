using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataTransferObjects;
using SaveLoadSystem.DTO;
using UnityEngine;


namespace SaveLoadSystem.LoadSystem.Loaders {

  public class BotsLoader : ILoader {
    private string _fileName;
    private BotsData _botsData;

    public BotsLoader(string fileName) {
      _fileName = fileName;
    }

    public void Load() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      var binaryFormatter = new BinaryFormatter();
      var fileStream = new FileStream(path, FileMode.Open);
      _botsData = binaryFormatter.Deserialize(fileStream) as BotsData;
      fileStream.Close();

      ParameterManager.Instance.NeutralCharVal = _botsData.animalsCount;
      ParameterManager.Instance.HostileCharVal = _botsData.enemyCount;
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
