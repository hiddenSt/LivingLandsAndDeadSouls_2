using System.Collections;
using System.Collections.Generic;
using SaveLoadSystem;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Characteristics;

namespace SaveLoadSystem
{
    public class CharacteristicsDataManager : DataManager
    {
        public override void Save()
        {
            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/characteristics.data";
            var characteristics = GameObject.Find("Characteristics").GetComponent<AllParameters>();
            var data = new CharacteristicsData(characteristics);
            var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public override void Load()
        {
            var path = Application.persistentDataPath + "/characteristics.data";
            if (!File.Exists(path)) return;
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var data = formatter.Deserialize(stream) as CharacteristicsData;
            stream.Close();
            var allParams = GameObject.Find("Characteristics").GetComponent<AllParameters>();
            allParams.Experience = data.experience;
            allParams.Health = data.health;
            allParams.Level = data.level;
            allParams.Skill = data.sniper;
            allParams.Strength = data.strength;
            allParams.FreePoints = data.freePoints;
            allParams.ToNextLevelExp = data.toNextLevelExp;
        }

        public override void DeleteSaves()
        {
            var path = Application.persistentDataPath + "/characteristics.data";
            if (!File.Exists(path)) return;
            File.Delete(path);
        }
    }
}//end of namespace SaveLoadSystem
