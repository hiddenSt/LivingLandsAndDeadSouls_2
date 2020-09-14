using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveLoadSystem {
  public class CharacteristicsDataManager : DataManager {
    public override void Save() {
      var formatter = new BinaryFormatter();
      var path = Application.persistentDataPath + "/characteristics.data";
      var characteristics = GameObject.Find("Characteristics").GetComponent<Characteristics.AllParameters>();
      var data = new CharacteristicsData(characteristics);
      var stream = new FileStream(path, FileMode.Create);
      formatter.Serialize(stream, data);
      stream.Close();
    }

    public override void Load() {
      var path = Application.persistentDataPath + "/characteristics.data";
      if (!File.Exists(path)) return;
      var formatter = new BinaryFormatter();
      var stream = new FileStream(path, FileMode.Open);
      var data = formatter.Deserialize(stream) as CharacteristicsData;
      stream.Close();
      var allParams = GameObject.Find("Characteristics").GetComponent<Characteristics.AllParameters>();
      allParams.experience = data.experience;
      allParams.health = data.health;
      allParams.level = data.level;
      allParams.sniper = data.sniper;
      allParams.strength = data.strength;
      allParams.freePoints = data.freePoints;
      allParams.toNextLevelExp = data.toNextLevelExp;
    }

    public override void DeleteSaves() {
      var path = Application.persistentDataPath + "/characteristics.data";
      if (!File.Exists(path)) return;
      File.Delete(path);
    }
  }
}
