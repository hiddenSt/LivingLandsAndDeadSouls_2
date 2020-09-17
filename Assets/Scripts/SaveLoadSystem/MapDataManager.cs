using System.Collections;
using System.Collections.Generic;
using GenerateMap;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveLoadSystem
{
    public class MapDataManager : DataManager
    {
        public override void Save()
        {
            var generator = GameObject.Find("Generate").GetComponent<Generator>();
            var formatter = new BinaryFormatter();
            var path = Application.persistentDataPath + "/map.data";
            var season =  GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>().Season;
            var year = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>().Year;
            var day = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>().Day;
            //var data = new MapData(generator.BushList, generator.TreeList, generator.RockList, generator.HouseList, generator.HouseTypeList, season, year, day, generator.TMPSize);
            var stream = new FileStream(path, FileMode.Create);
            //formatter.Serialize(stream, data);
            stream.Close();
        }

        public override void Load()
        {
            var path = Application.persistentDataPath + "/map.data";
            if (!File.Exists(path)) return;
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var data = formatter.Deserialize(stream) as MapData;
            stream.Close();
            var generator = GameObject.Find("Generate").GetComponent<Generator>();
            var tmpSize = new Vector3Int(data.tmpSizeX, data.tmpSizeY, data.tmpSizeZ);
            //enerator.GenerateMap(data, tmpSize);
            var timeController = GameObject.Find("ClockControl").GetComponent<TimeSystem.TimeController>();
            timeController.Year = data.year;
            timeController.Day = data.day;
        }

        public override void DeleteSaves()
        {
            var path = Application.persistentDataPath + "/map.data";
            if (!File.Exists(path)) return;
            File.Delete(path);
        }
    }
}//end of namespace SaveLoadSystem