using System.Collections.Generic;
using System.IO;
using DTOBetweenScenes;
using SaveLoadSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class MenuController : MonoBehaviour {
    private void Start() {

    }

    public void PlayPressed() {

      MoveToTheGameScene();
    }

    public void ContinuePressed() {
    

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