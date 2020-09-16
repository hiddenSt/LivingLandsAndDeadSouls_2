using UnityEngine;
using UnityEngine.UI;

namespace Menu.Settings {
  public class MasterVolumeControl : MonoBehaviour {
    public void Awake() {
      slider.value = AudioManager.instance.masterVolume;
      var audioDataManager = new SaveLoadSystem.DataManagers.AudioDataManager();
      audioDataManager.Load();
    }

    public void IsChanged() {
      AudioManager.instance.masterVolume = slider.value;
    }

    //data members
    public Slider slider;
  }
}