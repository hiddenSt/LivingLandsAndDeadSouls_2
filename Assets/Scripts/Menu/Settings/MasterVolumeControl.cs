using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Settings
{
    public class MasterVolumeControl : MonoBehaviour
    {
        public void Awake()
        {
            slider.value = AudioManager.instance.masterVolume;
            SaveLoadSystem.AudioDataManager audioDataManager = new SaveLoadSystem.AudioDataManager();
            audioDataManager.Load();
        }
        public void IsChanged()
        {
            AudioManager.instance.masterVolume = slider.value;
        }
        
        //data members
        public Slider slider;
    }
}//end of namespace Menu.Settings