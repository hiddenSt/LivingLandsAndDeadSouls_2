using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
    public class GreenDensity : MonoBehaviour
    {
        void Start()
        {
            Transform button1T = this.gameObject.transform.Find("NormalButton");
            Transform button2T = this.gameObject.transform.Find("MediumButton");
            Transform button3T = this.gameObject.transform.Find("HightButton");
            Transform button4T = this.gameObject.transform.Find("GBTBButton");
            _button1 = button1T.gameObject.GetComponent<Image>();
            _button2 = button2T.gameObject.GetComponent<Image>();
            _button3 = button3T.gameObject.GetComponent<Image>();
            _button4 = button4T.gameObject.GetComponent<Image>();
        }

        public void NormalPressed()
        {
            SetForestSettings(3, 10);
            SwitchButtonColor(1);
        }

        public void MedPressed()
        {
            SetForestSettings(5, 15);
            SwitchButtonColor(2);
        }

        public void HighPressed()
        {
            SetForestSettings(5, 17);
            SwitchButtonColor(3);
        }

        public void GBTBPressed()
        {
            SetForestSettings(20, 30);
            SwitchButtonColor(4);
        }
        
        private void SetForestSettings(int forestValue, int sizeofForest)
        {
            ParameterManager.instance.forestValue = forestValue;
            ParameterManager.instance.sizeOfForest = sizeofForest;
        }
        
        private void SwitchButtonColor(int button)
        {
            switch (button)
            {
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
        
        //data members
        private Image _button1;
        private Image _button2;
        private Image _button3;
        private Image _button4;

    }
}//end of namespace Menu