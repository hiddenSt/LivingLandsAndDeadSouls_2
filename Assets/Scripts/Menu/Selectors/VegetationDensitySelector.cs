using DataTransferObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Selectors {
  
  public class VegetationDensitySelector : MonoBehaviour {
    private Image _button1;
    private Image _button2;
    private Image _button3;
    private Image _button4;
    
    private void Start() {
      var button1T = gameObject.transform.Find("NormalButton");
      var button2T = gameObject.transform.Find("MediumButton");
      var button3T = gameObject.transform.Find("HightButton");
      var button4T = gameObject.transform.Find("GBTBButton");
      _button1 = button1T.gameObject.GetComponent<Image>();
      _button2 = button2T.gameObject.GetComponent<Image>();
      _button3 = button3T.gameObject.GetComponent<Image>();
      _button4 = button4T.gameObject.GetComponent<Image>();
    }

    public void NormalPressed() {
      SetForestSettings(3, 10);
      SwitchButtonColor(1);
    }

    public void MediumPressed() {
      SetForestSettings(5, 15);
      SwitchButtonColor(2);
    }

    public void HighPressed() {
      SetForestSettings(5, 17);
      SwitchButtonColor(3);
    }

    public void GBTBPressed() {
      SetForestSettings(20, 30);
      SwitchButtonColor(4);
    }

    private void SetForestSettings(int forestValue, int sizeofForest) {
      ParameterManager.instance.ForestValue = forestValue;
      ParameterManager.instance.SizeOfForest = sizeofForest;
    }

    private void SwitchButtonColor(int button) {
      switch (button) {
        case 1:
          _button1.color = new Vector4(0.6f, 0.6f, 0.6f, 1f);
          _button2.color = new Vector4(1f, 1f, 1f, 1f);
          _button3.color = new Vector4(1f, 1f, 1f, 1f);
          _button4.color = new Vector4(1f, 1f, 1f, 1f);
          break;
        case 2:
          _button1.color = new Vector4(1f, 1f, 1f, 1f);
          _button2.color = new Vector4(0.6f, 0.6f, 0.6f, 1f);
          _button4.color = new Vector4(1f, 1f, 1f, 1f);
          _button3.color = new Vector4(1f, 1f, 1f, 1f);
          break;
        case 3:
          _button1.color = new Vector4(1f, 1f, 1f, 1f);
          _button2.color = new Vector4(1f, 1f, 1f, 1f);
          _button3.color = new Vector4(1f, 1f, 1f, 1f);
          _button4.color = new Vector4(0.6f, 0.6f, 0.6f, 1f);
          break;
        case 4:
          _button1.color = new Vector4(1f, 1f, 1f, 1f);
          _button2.color = new Vector4(1f, 1f, 1f, 1f);
          _button3.color = new Vector4(1f, 1f, 1f, 1f);
          _button4.color = new Vector4(0.6f, 0.6f, 0.6f, 1f);
          break;
      }
    }
  }
  
}