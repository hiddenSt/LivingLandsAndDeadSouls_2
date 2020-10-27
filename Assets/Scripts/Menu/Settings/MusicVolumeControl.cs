using UnityEngine;
using UnityEngine.UI;

namespace Menu.Settings {
  
  public class MusicVolumeControl : MonoBehaviour {
    public Slider slider;
    
    public void Start() {
      slider.value = AudioManager.Instance.musicVolume;
    }

    public void IsChanged() {
      AudioManager.Instance.musicVolume = slider.value;
    }
  }
  
}