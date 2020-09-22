using DTOBetweenScenes;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
  public class NeutralChar : MonoBehaviour {
    private void Start() {
      _button1 = gameObject.transform.Find("FewButton").GetComponent<Image>();
      _button2 = gameObject.transform.Find("MediumButton").GetComponent<Image>();
      _button3 = gameObject.transform.Find("ManyButton").GetComponent<Image>();
    }

    public void SmallPressed() {
      ParameterManager.instance.neutralCharVal = Random.Range(50, 200);
      SetNeutralCharSettings(50, 200, 1);
    }

    public void MedPressed() {
      ParameterManager.instance.neutralCharVal = Random.Range(100, 300);
      SetNeutralCharSettings(100, 300, 2);
    }

    public void LargePressed() {
      SetNeutralCharSettings(200, 450, 3);
    }

    private void SetNeutralCharSettings(int beginOfRange, int endORange, int button) {
      ParameterManager.instance.neutralCharVal = Random.Range(beginOfRange, endORange);
      SwitchButtonColor(button);
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