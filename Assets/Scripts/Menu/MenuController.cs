using System.Collections.Generic;
using System.IO;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class MenuController : MonoBehaviour {
    private void Start() {
      var audioDataPath = Application.persistentDataPath + "/audio.data";
      var mapDataPath = Application.persistentDataPath + "/map.data";
      var playerDataPath = Application.persistentDataPath + "/player.data";
      var botsDataPath = Application.persistentDataPath + "/bots.data";
      var characteristicsDataPath = Application.persistentDataPath + "/characteristics.data";

      SaveSystem.DataManagers = new List<IDataManager>();

      SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.PlayerDataManager(playerDataPath));
      SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.BotDataManager(botsDataPath));
      SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.MapDataManager(mapDataPath));
      SaveSystem.DataManagers.Add(new SaveLoadSystem.DataManagers.CharacteristicsDataManager(characteristicsDataPath));

      var audioDataManager = new SaveLoadSystem.DataManagers.AudioDataManager(audioDataPath);
      audioDataManager.Load();
      SaveSystem.DataManagers.Add(audioDataManager);
    }

    public void PlayPressed() {
      GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad = false;
      SaveSystem.DeleteSaves();

      MoveToTheGameScene();
    }

    public void ContinuePressed() {
      var path = Application.persistentDataPath + "/player.data";
      if (!File.Exists(path))
        return;
      GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad = true;

      MoveToTheGameScene();
    }

    public void ExitPressed() {
      var audioDataPath = Application.persistentDataPath + "/audio.data";
      var audioManager = new SaveLoadSystem.DataManagers.AudioDataManager(audioDataPath);
      audioManager.Save();
      Application.Quit();
    }

    private void MoveToTheGameScene() {
      DontDestroyOnLoad(GameObject.Find("AudioManager"));
      DontDestroyOnLoad(GameObject.Find("Sounds"));
      SceneManager.LoadScene("save");
    }
  }
}