using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Register : Authenticate.Authenticate
{
  private string userName;
  public void OnClickRegister()
  {
  GetUserEmail();
  GetUserPassword();
  GetUsername();
    var registerRequest = new RegisterPlayFabUserRequest { Email=userEmail, 
      Password=userPassword, Username=userName };
    PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
  }
  
  private void OnRegisterSuccess(RegisterPlayFabUserResult result)
  {
    Debug.Log("User registered");
    SceneManager.LoadScene("Menu");
  }
  
  private void OnRegisterFailure(PlayFabError error)
  {
    Debug.LogError(error.GenerateErrorReport());
    string[] errorReport = error.GenerateErrorReport().Split();
    if (errorReport[1]=="Username")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Никнейм занят";
    }
    else if (errorReport[1]=="Email")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Email занят или имеет неверный формат";
    }
    else if (errorReport[4]=="Username:")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Логин может содержать буквы латинницы";
    }
    else if (errorReport[4]=="Password:")
    {
      GameObject.Find("LoginFailed").GetComponent<Text>().text="Неверный формат пароля";
    }
  }
  public void GetUsername()
  {
    userName = loginPanel.transform.Find("Username").GetComponent<InputField>().text;
  }
}
