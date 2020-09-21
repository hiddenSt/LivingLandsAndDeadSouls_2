using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
  public void LoadRegisterScene() {
    SceneManager.LoadScene("Register");
  }

  public void LoadLoginScene() {
    SceneManager.LoadScene("Login");
  }
}