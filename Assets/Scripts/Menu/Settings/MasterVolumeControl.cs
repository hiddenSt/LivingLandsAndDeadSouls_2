using UnityEngine;
using UnityEngine.UI;

namespace Menu.Settings {
  public class MasterVolumeControl : MonoBehaviour {
    public Slider slider;
    
    public void Awake() {
      slider.value = AudioManager.Instance.masterVolume;
    }

    public void IsChanged() {
      AudioManager.Instance.masterVolume = slider.value;
    }
  }
}