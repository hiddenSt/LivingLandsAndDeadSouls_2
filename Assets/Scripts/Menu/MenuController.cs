using System.Collections.Generic;
using System.IO;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {

  public class MenuController : MonoBehaviour {
    private void Start() {
      SaveLoadSystem.SaveSystem.DataManagers = new List<IDataManager>();
      SaveLoadSystem.SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.PlayerDataManager());
      SaveLoadSystem.SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.BotDataManager());
      SaveLoadSystem.SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.MapDataManager());
      SaveLoadSystem.SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.CharacteristicsDataManager());
      var audioDataManager = new SaveLoadSystem.DataManagers.AudioDataManager();
      audioDataManager.Load();
      SaveLoadSystem.SaveSystem.DataManagers.Add(audioDataManager);
    }

    public void PlayPressed() {
      GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad = false;
      SaveLoadSystem.SaveSystem.DeleteSaves();
      
      MoveToTheGameScene();
      SceneManager.LoadScene("save");
    }

    public void ContinuePressed() {
      var path = Application.persistentDataPath + "/player.data";
      if (!File.Exists(path))
        return;
      GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad = true;
      
      MoveToTheGameScene();
      SceneManager.LoadScene("save");
    }

    public void ExitPressed() {
      var audioManager = new SaveLoadSystem.DataManagers.AudioDataManager();
      audioManager.Save();
      Application.Quit();
    }

    private void MoveToTheGameScene() {
      DontDestroyOnLoad(GameObject.Find("AudioManager"));
      DontDestroyOnLoad(GameObject.Find("Sounds"));
    }
  }
}
