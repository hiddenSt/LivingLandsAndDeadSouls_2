using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public void LoadFirstPageScene()
  {
    SceneManager.LoadScene("FirstPage");
  }
  
  public void LoadRegisterScene()
  {
    SceneManager.LoadScene("Register");
  }

  public void LoadLoginScene()
  {
    SceneManager.LoadScene("Login");
  }
  
  public void LoadPasswordRecoveryScene()
  {
    SceneManager.LoadScene("PasswordReset");
  }
}
