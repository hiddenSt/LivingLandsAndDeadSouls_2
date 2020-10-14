using Components;
using DataTransferObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu {
  public class PauseMenu : MonoBehaviour {
    public void OnGamePause() {
      Time.timeScale = 0;
      pausePanel.SetActive(true);
    }

    public void OnGameResume() {
      Time.timeScale = 1;
      pausePanel.SetActive(false);
    }

    public void OnGameExit() {
      OnGameResume();
      var saver = gameObject.GetComponent<GameSaver>();
      saver.Save();
      DontDestroyOnLoad(ParameterManager.Instance);
      SceneManager.LoadScene("Menu");
    }

    //data members
    public GameObject pausePanel;
  }
}