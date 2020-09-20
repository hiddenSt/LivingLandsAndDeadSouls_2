using UnityEngine;
using UnityEngine.SceneManagement;

namespace Authenticate {
  public class SceneLoader : MonoBehaviour {
    public void LoadFirstPageScene() {
      SceneManager.LoadScene("FirstPage");
    }

    public void LoadRegisterScene() {
      SceneManager.LoadScene("Register");
    }

    public void LoadLoginScene() {
      SceneManager.LoadScene("Login");
    }
  }
}