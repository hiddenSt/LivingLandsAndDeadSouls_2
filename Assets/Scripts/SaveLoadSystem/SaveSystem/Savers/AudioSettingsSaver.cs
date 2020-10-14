using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Menu;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.SaveSystem.Savers {

  public class AudioSettingsSaver : ISaver {
    private string _fileName;

    public AudioSettingsSaver(string fileName) {
      _fileName = fileName;
    }
    
    public void Save() {
      var audioData = new AudioData();
      audioData.masterVolume = AudioManager.Instance.masterVolume;
      audioData.musicVolume = AudioManager.Instance.musicVolume;
      
      var binaryFormatter = new BinaryFormatter();
      var path = Application.persistentDataPath + _fileName;
      var fileStream = new FileStream(path, FileMode.Create);
      binaryFormatter.Serialize(fileStream, audioData);
      fileStream.Close();
    }
  }

}
