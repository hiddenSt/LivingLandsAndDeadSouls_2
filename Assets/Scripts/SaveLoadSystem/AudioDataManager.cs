using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace SaveLoadSystem {
  public class AudioDataManager : DataManager {
    public override void Save() {
      var formatter = new BinaryFormatter();
      var path = Application.persistentDataPath + "/audio.data";
      var audioController = GameObject.Find("AudioManager").GetComponent<Menu.AudioManager>();
      var data = new AudioData(audioController.masterVolume, audioController.musicVolume);
      var stream = new FileStream(path, FileMode.Create);
      formatter.Serialize(stream, data);
      stream.Close();
    }

    public override void Load() {
      var path = Application.persistentDataPath + "/audio.data";
      if (!File.Exists(path)) return;
      var formatter = new BinaryFormatter();
      var stream = new FileStream(path, FileMode.Open);
      var data = formatter.Deserialize(stream) as AudioData;
      stream.Close();
      var audioController = GameObject.Find("AudioManager").GetComponent<Menu.AudioManager>();
      audioController.masterVolume = data.masterVolume;
      audioController.musicVolume = data.musicVolume;
    }

    public override void DeleteSaves() {
      var path = Application.persistentDataPath + "/audio.data";
      if (!File.Exists(path)) return;
      File.Delete(path);
    }
  }
}
