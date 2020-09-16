using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace SaveLoadSystem.DataManagers {
  public class AudioDataManager : IDataManager {
    public void Save() {
      var formatter = new BinaryFormatter();
      var path = Application.persistentDataPath + "/audio.data";
      var audioController = GameObject.Find("AudioManager").GetComponent<Menu.AudioManager>();
      var data = new DTO.AudioData(audioController.masterVolume, audioController.musicVolume);
      var stream = new FileStream(path, FileMode.Create);
      formatter.Serialize(stream, data);
      stream.Close();
    }

    public void Load() {
      var path = Application.persistentDataPath + "/audio.data";
      if (!File.Exists(path)) return;
      var formatter = new BinaryFormatter();
      var stream = new FileStream(path, FileMode.Open);
      var data = formatter.Deserialize(stream) as DTO.AudioData;
      stream.Close();
      var audioController = GameObject.Find("AudioManager").GetComponent<Menu.AudioManager>();
      audioController.masterVolume = data.masterVolume;
      audioController.musicVolume = data.musicVolume;
    }

    public void DeleteSaves() {
      var path = Application.persistentDataPath + "/audio.data";
      if (!File.Exists(path)) return;
      File.Delete(path);
    }
  }
}
