using System.Collections.Generic;
using System.IO;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {

  public class MenuController : MonoBehaviour {
    void Start() {
      SaveLoadSystem.SaveSystem.DataManagers = new List<DataManager>();
      SaveLoadSystem.SaveSystem.DataManagers.Add(new SaveLoadSystem.PlayerDataManager());
      SaveLoadSystem.SaveSystem.DataManagers.Add(new SaveLoadSystem.BotDataManager());
      SaveLoadSystem.SaveSystem.DataManagers.Add(new SaveLoadSystem.MapDataManager());
      SaveLoadSystem.SaveSystem.DataManagers.Add(new CharacteristicsDataManager());
      var audioDataManager = new SaveLoadSystem.AudioDataManager();
      audioDataManager.Load();
      SaveLoadSystem.SaveSystem.DataManagers.Add(audioDataManager);
    }

    public void PlayPressed() {
      GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad = false;
      DontDestroyOnLoad(GameObject.Find("AudioManager"));
      DontDestroyOnLoad(GameObject.Find("Sounds"));
      SaveLoadSystem.SaveSystem.DeleteSaves();
      SceneManager.LoadScene("save");
    }

    public void ContinuePressed() {
      var path = Application.persistentDataPath + "/player.data";
      if (!File.Exists(path))
        return;
      DontDestroyOnLoad(GameObject.Find("AudioManager"));
      DontDestroyOnLoad(GameObject.Find("Sounds"));
      GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad = true;
      SceneManager.LoadScene("save");
    }

    public void ExitPressed() {
      var audioManager = new SaveLoadSystem.AudioDataManager();
      audioManager.Save();
      Application.Quit();
    }
  }
}
