using SaveLoadSystem.LoadSystem;
using SaveLoadSystem.LoadSystem.Loaders;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class MenuController : MonoBehaviour {
    private void Start() {
      var playerLoader = new PlayerLoader("Player.data");
      LoadSystem.AddLoader(playerLoader);
    }

    public void PlayPressed() {
      LoadSystem.DeleteSaves();
      MoveToTheGameScene();
    }

    public void ContinuePressed() {
      LoadSystem.Load();
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