using System.Collections;
using System.Collections.Generic;
using System.IO;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        void Start()
        {
            SaveLoadSystem.SaveSystem.dataManagers = new List<DataManager>();
            SaveLoadSystem.SaveSystem.dataManagers.Add(new SaveLoadSystem.PlayerDataManager());
            SaveLoadSystem.SaveSystem.dataManagers.Add(new SaveLoadSystem.BotDataManager());
            SaveLoadSystem.SaveSystem.dataManagers.Add(new SaveLoadSystem.MapDataManager());
            SaveLoadSystem.SaveSystem.dataManagers.Add(new CharacteristicsDataManager());
            var audioDataManager = new SaveLoadSystem.AudioDataManager();
            audioDataManager.Load();
            SaveLoadSystem.SaveSystem.dataManagers.Add(audioDataManager);
        }
        public void PlayPressed()
        {
            GameObject.Find("ParametersManager").GetComponent<ParameterManager>().NeedToLoad = false;
            DontDestroyOnLoad(GameObject.Find("AudioManager"));
            DontDestroyOnLoad(GameObject.Find("Sounds"));
            SaveLoadSystem.SaveSystem.DeleteSaves();
            SceneManager.LoadScene("save");
        }

        public void ContinuePressed()
        {
            Debug.Log("Used continue button");
            var path = Application.persistentDataPath + "/player.data";
            /*if (!File.Exists(path))
                return;*/
            DontDestroyOnLoad(GameObject.Find("AudioManager"));
            DontDestroyOnLoad(GameObject.Find("Sounds"));
            GameObject.Find("ParametersManager").GetComponent<ParameterManager>().NeedToLoad = true;
            SceneManager.LoadScene("save");
        }

        public void ExitPressed()
        {
            var audioManager = new SaveLoadSystem.AudioDataManager();
            audioManager.Save();
            Application.Quit();
        }
    }
}//end of namespace Menu
