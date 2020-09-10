using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Authenticate
{
  public class PasswordRecovery : Authenticate { 
    private const string _playfabloginAppID = "99BF5";
    public void RecoveryPassword() {
      GetUserEmail();
      var request = new SendAccountRecoveryEmailRequest{Email = _userEmail, 
        TitleId = _playfabloginAppID};
      PlayFab.PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoveryEmailSuccess,
        OnRecoveryEmailFailed);
    }

    private void OnRecoveryEmailSuccess(SendAccountRecoveryEmailResult result) {
      Debug.Log("Password reset");
      SceneManager.LoadScene("Login");
    }

    private void OnRecoveryEmailFailed(PlayFab.PlayFabError error) {
      Debug.LogError(error.GenerateErrorReport());
    }
  }
}
