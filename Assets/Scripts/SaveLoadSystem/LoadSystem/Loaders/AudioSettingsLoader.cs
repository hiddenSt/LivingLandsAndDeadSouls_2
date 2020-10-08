using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Menu;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.LoadSystem.Loaders {
  
  public class AudioSettingsLoader : ILoader {
    private string _fileName;

    public AudioSettingsLoader(string fileName) {
      _fileName = fileName;
    }
    
    public void Load() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      
      var binaryFormatter = new BinaryFormatter();
      var fileStream = new FileStream(path, FileMode.Open);
      var audioData = binaryFormatter.Deserialize(fileStream) as AudioData;
      fileStream.Close();
      AudioManager.instance.masterVolume = audioData.masterVolume;
      AudioManager.instance.musicVolume = audioData.musicVolume;
      AudioManager.instance.ChangeSlider();
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