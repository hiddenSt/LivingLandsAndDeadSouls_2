using UnityEngine;
using UnityEngine.UI;

namespace Menu {

  public class MapSize : MonoBehaviour {
    void Start() {
      Transform button1T = this.gameObject.transform.Find("SmallButton");
      Transform button2T = this.gameObject.transform.Find("MediumButton");
      Transform button3T = this.gameObject.transform.Find("LargeButton");
      _button1 = button1T.gameObject.GetComponent<Image>();
      _button2 = button2T.gameObject.GetComponent<Image>();
      _button3 = button3T.gameObject.GetComponent<Image>();
    }

    public void SmallPressed() {
      Menu.ParameterManager.instance.tmpSize.x = 200;
      Menu.ParameterManager.instance.tmpSize.y = 200;
      SwitchButtonColor(1);
    }

    public void MedPressed() {
      Menu.ParameterManager.instance.tmpSize.x = 500;
      Menu.ParameterManager.instance.tmpSize.y = 500;
      SwitchButtonColor(2);
    }

    public void LargePressed() {
      Menu.ParameterManager.instance.tmpSize.x = 1000;
      Menu.ParameterManager.instance.tmpSize.y = 1000;
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

    //data members
    private Image _button1;
    private Image _button2;
    private Image _button3;
  }
}
