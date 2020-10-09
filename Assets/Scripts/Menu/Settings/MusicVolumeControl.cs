using UnityEngine;
using UnityEngine.UI;

namespace Menu.Settings {
  public class MusicVolumeControl : MonoBehaviour {
    public void Start() {
      slider.value = AudioManager.Instance.musicVolume;
      //SaveLoadSystem.DataManagers.AudioDataManager
      // audioDataManager = new SaveLoadSystem.DataManagers.AudioDataManager();
      //audioDataManager.Load();
    }

    public void IsChanged() {
      AudioManager.Instance.musicVolume = slider.value;
    }

    //data members
    public Slider slider;
  }
}