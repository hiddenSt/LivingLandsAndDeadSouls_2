using System.IO;
using DataTransferObjects;
using SaveLoadSystem.LoadSystem;
using SaveLoadSystem.LoadSystem.Loaders;
using SaveLoadSystem.SaveSystem.Savers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class MenuController : MonoBehaviour {
    public CharacterSetuper characterSetuper;

    private void Start() {
      AudioManager.Instance.Setup();
      var audioSettingsLoader = new AudioSettingsLoader("Audio.data");
      audioSettingsLoader.Load();
      audioSettingsLoader.DeleteSaves();

      var playerLoader = new PlayerLoader("Player.data");
      var mapLoader = new MapLoader("Map.data");
      var botsLoader = new BotsLoader("Bots.data");
      ParameterManager.Instance.SetDefaults();
      LoadSystem.AddLoader(playerLoader);
      LoadSystem.AddLoader(mapLoader);
      LoadSystem.AddLoader(botsLoader);
    }

    public void PlayPressed() {
      LoadSystem.DeleteSaves();
      MoveToTheGameScene();
    }

    public void ContinuePressed() {
      var path = Application.persistentDataPath + "Player.data";
      if (!File.Exists(path)) {
        return;
      }
      LoadSystem.Load();
      characterSetuper.SetupCharacter(ParameterManager.Instance.characterName);
      MoveToTheGameScene();
    }

    public void ExitPressed() {
      var audioSettingsSaver = new AudioSettingsSaver("Audio.data");
      audioSettingsSaver.Save();
      Application.Quit();
    }

    private void MoveToTheGameScene() {
      SceneManager.LoadScene("Game");
    }
  }
}