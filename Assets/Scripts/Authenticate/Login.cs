using UnityEngine;
using PlayFab;
using UnityEngine.UI;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class Login : Authenticate.Authenticate
{
  public void OnClickLogin(){
    GetUserEmail();
    GetUserPassword();
    Debug.Log("Email"+userEmail);
    Debug.Log("Password"+userPassword);
    var request = new LoginWithEmailAddressRequest { Email=userEmail, Password=userPassword };
    PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailed);
  }
  
  private void OnLoginSuccess(LoginResult result)
  {
    Debug.Log("User logged");
    SceneManager.LoadScene("Menu");
  }
  
  void OnLoginFailed(PlayFabError error)
  {
    Debug.Log(error.GenerateErrorReport());
    string[] errorReport = error.GenerateErrorReport().Split();
    if (errorReport[1] == "User")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Данный пользователь не найден";
    }
    if (errorReport[4]=="host")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Отсутствует соединение с сетью Интернет";
    }
    if (errorReport[4]=="Email:")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Неправильный пароль или логин";
    }
    if (errorReport[1] == "Invalid")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Неправильный пароль или логин";
    }
  }
}
