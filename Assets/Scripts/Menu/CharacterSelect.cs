using System.Collections.Generic;
using DataTransferObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
  public class CharacterSelect : MonoBehaviour {
    public string[] gunTypes;
    public AnimatorOverrideController[] animatorOverrideControllersClark;
    public AnimatorOverrideController[] animatorOverrideControllersHuLie;
    public AnimatorOverrideController[] animatorOverrideControllersTsal;

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
      ParameterManager.instance.CharacterI = 0;
      ParameterManager.instance.characterName = "Dick Clark";
      ParameterManager.instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersClark[i]);
      }
      SwitchButtonColor(1);
    }

    public void HuLeePressed() {
      ParameterManager.instance.CharacterI = 1;
      ParameterManager.instance.characterName = "Hu Lee";
      ParameterManager.instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersHuLie[i]);
      }
      SwitchButtonColor(2);
    }

    public void VitaliTsalPressed() {
      ParameterManager.instance.CharacterI = 2;
      ParameterManager.instance.characterName = "Vitali Tsal";
      Debug.Log("I am Tsal");
      ParameterManager.instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersTsal[i]);
      }
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

    //data  members
    private Image _button1;
    private Image _button2;
    private Image _button3;
  }
} //end of namespace Menu