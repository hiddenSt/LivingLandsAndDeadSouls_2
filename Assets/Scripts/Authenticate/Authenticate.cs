using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Authenticate
{
  public class Authenticate: MonoBehaviour
  {
    protected  string userEmail;
    protected string userPassword;
    public GameObject loginPanel;

    public void GetUserEmail(){
      userEmail = loginPanel.transform.Find("Login").GetComponent<InputField>().text;
    }

    public void GetUserPassword()
    {
      userPassword = loginPanel.transform.Find("Password").GetComponent<InputField>().text;
    }
  }
}
