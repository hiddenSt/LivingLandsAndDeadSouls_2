using UnityEngine;
using UnityEngine.UI;

namespace Menu {
  
  public class AudioManager : MonoBehaviour {
    public GameObject masterSlider;
    public GameObject musicSlider;
    public float masterVolume;
    public float musicVolume;
    private float _lastMusicVolume;
    private float _lastAllVolume;
    public static AudioManager Instance = null;
    private AudioSource _soundOfRun;
    private AudioSource _musicVolume;
    private GameObject _sounds;
    private GameObject _rainSound;
    
    public void Setup() {
      _musicVolume = GameObject.Find("MenuMusic").GetComponent<AudioSource>();
      _sounds = GameObject.Find("Sounds");
      masterVolume = 50f;
      musicVolume = 50f;

      if (!_musicVolume.isPlaying)
        _musicVolume.Play();

      _lastAllVolume = 0.5f;
      _lastAllVolume = 0.5f;
    }

    private void Update() {
      _rainSound = GameObject.Find("Rain Generator");

      if (_rainSound != null) {
        if (!GameObject.Find("Rain Sound").GetComponent<AudioSource>().isPlaying)
          GameObject.Find("Rain Sound").GetComponent<AudioSource>().Play();
      }
      else {
        GameObject.Find("Rain Sound").GetComponent<AudioSource>().Stop();
      }

      if (musicVolume != _lastMusicVolume)
        _sounds.transform.GetChild(0).GetComponent<AudioSource>().volume = masterVolume / 100f * musicVolume / 100f;

      if (masterVolume != _lastAllVolume) {
        for (var i = 0; i < _sounds.transform.childCount; i++)
          _sounds.transform.GetChild(i).GetComponent<AudioSource>().volume = masterVolume / 100f;
        _sounds.transform.GetChild(0).GetComponent<AudioSource>().volume = masterVolume / 100f * musicVolume / 100f;
      }

      _lastAllVolume = masterVolume;
      _lastMusicVolume = musicVolume;
    }

    public void ChangeSlider() {
      if (masterSlider == null)
        return;
      masterSlider.GetComponent<Slider>().value = masterVolume;
      musicSlider.GetComponent<Slider>().value = musicVolume;
    }
    
    private void Awake() {
      if (Instance) {
        DestroyImmediate(gameObject);
      }
      else {
        Instance = this;
        DontDestroyOnLoad(gameObject);
      }
    }
  }
  
}