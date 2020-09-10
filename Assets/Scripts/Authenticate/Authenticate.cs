using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Authenticate
{
  public class Authenticate: MonoBehaviour {
    public GameObject LoginPanel;
    
    protected  string _userEmail;
    protected string _userPassword;

    public void GetUserEmail() {
      _userEmail = LoginPanel.transform.Find("Login").GetComponent<InputField>().text;
    }

    public void GetUserPassword() {
      _userPassword = LoginPanel.transform.Find("Password").GetComponent<InputField>().text;
    }
  }
}
