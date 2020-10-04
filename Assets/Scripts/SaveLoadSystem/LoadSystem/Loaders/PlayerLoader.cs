using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.LoadSystem.Loaders {

  public class PlayerLoader : ILoader {
    public PlayerLoader(string fileName) {
      _fileName = fileName;
    }
    
    public void Load() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      var binaryFormatter = new BinaryFormatter();
      var fileStream = new FileStream(path, FileMode.Open);
      var playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;
      fileStream.Close();
    }

    public void DeleteSaves() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      File.Delete(path);
    }

    private string _fileName;
  }

}