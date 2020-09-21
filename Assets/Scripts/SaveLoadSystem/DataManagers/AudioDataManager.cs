using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace SaveLoadSystem.DataManagers {
  public class AudioDataManager : IDataManager {
    public AudioDataManager(string filepath) {
      _filePath = filepath;
    }

    public void Save() {
      var formatter = new BinaryFormatter();
      var audioController = GameObject.Find("AudioManager").GetComponent<Menu.AudioManager>();
      var data = new DTO.AudioData(audioController.masterVolume, audioController.musicVolume);
      var stream = new FileStream(_filePath, FileMode.Create);
      formatter.Serialize(stream, data);
      stream.Close();
    }

    public void Load() {
      if (!File.Exists(_filePath)) return;
      var formatter = new BinaryFormatter();
      var stream = new FileStream(_filePath, FileMode.Open);
      var data = formatter.Deserialize(stream) as DTO.AudioData;
      stream.Close();
      var audioController = GameObject.Find("AudioManager").GetComponent<Menu.AudioManager>();
      audioController.masterVolume = data.masterVolume;
      audioController.musicVolume = data.musicVolume;
    }

    public void DeleteSaves() {
      if (!File.Exists(_filePath)) return;
      File.Delete(_filePath);
    }

    private string _filePath;
  }
}