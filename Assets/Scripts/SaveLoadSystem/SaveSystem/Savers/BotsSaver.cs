using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataTransferObjects;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.SaveSystem.Savers {

  public class BotsSaver : ISaver {
    private string _fileName;

    public BotsSaver(string fileName) {
      _fileName = fileName;
    }
    
    public void Save() {
      var botsData = new BotsData();

      botsData.animalsCount = ParameterManager.Instance.NeutralCharVal;
      botsData.enemyCount = ParameterManager.Instance.HostileCharVal;
      
      var binaryFormatter = new BinaryFormatter();
      var path = Application.persistentDataPath + _fileName;
      var fileStream = new FileStream(path, FileMode.Create);
      binaryFormatter.Serialize(fileStream, botsData);
      fileStream.Close();
    }
  }

}
