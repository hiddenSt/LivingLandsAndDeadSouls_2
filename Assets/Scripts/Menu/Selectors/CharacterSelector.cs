using UnityEngine;
using UnityEngine.UI;

namespace Menu.Selectors {
  
  public class CharacterSelector : MonoBehaviour {
    public CharacterSetuper characterSetuper;
    private Image _button1;
    private Image _button2;
    private Image _button3;

    private void Start() {
      var button1T = gameObject.transform.Find("DickClarkButton");
      var button2T = gameObject.transform.Find("HuLieButton");
      var button3T = gameObject.transform.Find("VitaliTsalButton");
      _button1 = button1T.gameObject.GetComponent<Image>();
      _button2 = button2T.gameObject.GetComponent<Image>();
      _button3 = button3T.gameObject.GetComponent<Image>();
      DickClarkPressed();
    }

    public void DickClarkPressed() {
      characterSetuper.SetupCharacter("Dick Clark");
      SwitchButtonColor(1);
    }

    public void HuLeePressed() {
      characterSetuper.SetupCharacter("Hu Lee");
      SwitchButtonColor(2);
    }

    public void VitaliTsalPressed() {
      characterSetuper.SetupCharacter("Vitali Tsal");
      SwitchButtonColor(3);
    }

    private void SwitchButtonColor(int button) {
      switch (button) {
        case 1:
          _button1.color = new Vector4(0.6f, 0.6f, 0.6f, 1f);
          _button2.color = new Vector4(1f, 1f, 1f, 1f);
          _button3.color = new Vector4(1f, 1f, 1f, 1f);
          break;
        case 2:
          _button1.color = new Vector4(1f, 1f, 1f, 1f);
          _button2.color = new Vector4(0.6f, 0.6f, 0.6f, 1f);
          _button3.color = new Vector4(1f, 1f, 1f, 1f);
          break;
        case 3:
          _button1.color = new Vector4(1f, 1f, 1f, 1f);
          _button2.color = new Vector4(1f, 1f, 1f, 1f);
          _button3.color = new Vector4(0.6f, 0.6f, 0.6f, 1f);
          break;
      }
    }
  }
  
}