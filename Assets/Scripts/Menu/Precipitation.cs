﻿using DataTransferObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Menu {
  public class Precipitation : MonoBehaviour {
    private void Start() {
      var button1T = gameObject.transform.Find("FewButton");
      var button2T = gameObject.transform.Find("MediumButton");
      var button3T = gameObject.transform.Find("ManyButton");
      _button1 = button1T.gameObject.GetComponent<Image>();
      _button2 = button2T.gameObject.GetComponent<Image>();
      _button3 = button3T.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    public void SmallPressed() {
      SetPrecipitationSettings(1, 1);
    }

    public void MedPressed() {
      SetPrecipitationSettings(2, 2);
    }

    public void LargePressed() {
      SetPrecipitationSettings(3, 3);
    }

    private void SetPrecipitationSettings(int precipitation, int button) {
      ParameterManager.instance.Precipitation = precipitation;
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