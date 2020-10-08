using DataTransferObjects;
using SaveLoadSystem.LoadSystem;
using SaveLoadSystem.LoadSystem.Loaders;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class MenuController : MonoBehaviour {
    public CharacterSetuper characterSetuper;

    private void Start() {
      var playerLoader = new PlayerLoader("Player.data");
      var mapLoader = new MapLoader("Map.data");
      var botsLoader = new BotsLoader("Bots.data");
      LoadSystem.AddLoader(playerLoader);
      LoadSystem.AddLoader(mapLoader);
      LoadSystem.AddLoader(botsLoader);
    }

    public void PlayPressed() {
      LoadSystem.DeleteSaves();
      MoveToTheGameScene();
    }

    public void ContinuePressed() {
      LoadSystem.Load();
      characterSetuper.SetupCharacter(ParameterManager.instance.characterName);
      MoveToTheGameScene();
    }

    public void ExitPressed() {
      Application.Quit();
    }

    private void MoveToTheGameScene() {
      DontDestroyOnLoad(GameObject.Find("AudioManager"));
      DontDestroyOnLoad(GameObject.Find("Sounds"));
      SceneManager.LoadScene("save");
    }
  }
}