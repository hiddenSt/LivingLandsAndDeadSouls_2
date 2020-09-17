using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SpawnSystem;

namespace SaveLoadSystem
{
    public class BotDataManager : DataManager
    {
        public override void Save()
        {
            var formatter = new BinaryFormatter();
            var data = new BotData(-100, 100, -100, 100,
                GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>().HostileCharVal,
                GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>().NeutralCharVal);
            var path = Application.persistentDataPath + "/bots.data";
            var stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, data);
            stream.Close();
        }

        public override void Load()
        {
            var path = Application.persistentDataPath + "/bots.data";
            if (!File.Exists(path)) return;
            var formatter = new BinaryFormatter();
            var stream = new FileStream(path, FileMode.Open);
            var data = formatter.Deserialize(stream) as BotData;
            stream.Close();
            var parameterManager = GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>();
            parameterManager.HostileCharVal = data.enemyCount;
            parameterManager.NeutralCharVal = data.animalsCount;
            //var initSpawner = GameObject.Find("InitSpawner").GetComponent<InitSpawner>();
            //initSpawner.xAxisBeginOfRange = data.xAxisBeginOfRange;
            //initSpawner.xAxisEndOfRange = data.xAxisEndOfRange;
            //initSpawner.yAxisBeginOfRange = data.yAxisBeginOfRange;
            //initSpawner.yAxisEndOfRange = data.yAxisEndOfRange;
        }

        public override void DeleteSaves()
        {
            var path = Application.persistentDataPath + "/bots.data";
            if (!File.Exists(path)) return;
            File.Delete(path);
        }
    }
}//end of namespace SaveLoadSystem
