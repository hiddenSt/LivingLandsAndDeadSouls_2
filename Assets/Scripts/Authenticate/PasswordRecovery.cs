using UnityEngine;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PasswordRecovery : Authenticate.Authenticate
{
  private string PLAYFABLOGIN_APP_ID = "99BF5";
  public void RecoveryPassword()
  {
    GetUserEmail();
    var request = new SendAccountRecoveryEmailRequest();
    request.Email = userEmail;
    request.TitleId = PLAYFABLOGIN_APP_ID;
    PlayFab.PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoveryEmailSuccess,
      OnRecoveryEmailFailed);
  }
  public void OnRecoveryEmailSuccess(SendAccountRecoveryEmailResult result)
  {
    Debug.Log("Password reset");
    SceneManager.LoadScene("Login");
  }
  public void OnRecoveryEmailFailed(PlayFab.PlayFabError error)
  {
    Debug.LogError(error.GenerateErrorReport());
  }
}
