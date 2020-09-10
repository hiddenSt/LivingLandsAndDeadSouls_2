using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Authenticate {
  public class Login : Authenticate {
    public void OnClickLogin() {
      GetUserEmail();
      GetUserPassword();
      Debug.Log("Email"+_userEmail);
      Debug.Log("Password"+_userPassword);
      var request = new LoginWithEmailAddressRequest { Email = _userEmail, Password = _userPassword };
      PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailed);
    }
  
    private void OnLoginSuccess(LoginResult result) {
      Debug.Log("User logged");
      SceneManager.LoadScene("Menu");
    }

    private void OnLoginFailed(PlayFabError error) {
      Debug.Log(error.GenerateErrorReport());
      var errorReport = error.GenerateErrorReport().Split();
      if (errorReport[1] == "User") {
        GameObject.Find("LoginFailed").GetComponent<Text>().text = "Данный пользователь не найден";
      }
      if (errorReport[4] == "host") {
        GameObject.Find("LoginFailed").GetComponent<Text>().text = "Отсутствует соединение с сетью Интернет";
      }
      if (errorReport[4] == "Email:") {
        GameObject.Find("LoginFailed").GetComponent<Text>().text ="Неправильный пароль или логин";
      }
      if (errorReport[1] == "Invalid") {
        GameObject.Find("LoginFailed").GetComponent<Text>().text = "Неправильный пароль или логин";
      }
    }
  }
}
