using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Menu.Settings
{
    public class MusicVolumeControl : MonoBehaviour
    {
        public void Start()
        {
            slider.value = AudioManager.instance.musicVolume;
            SaveLoadSystem.AudioDataManager audioDataManager = new SaveLoadSystem.AudioDataManager();
            audioDataManager.Load();
        }
        public void IsChanged()
        {
            AudioManager.instance.musicVolume = slider.value;
        }
        
        //data members
        public Slider slider;
    }
}//end of namespace Menu.Settings