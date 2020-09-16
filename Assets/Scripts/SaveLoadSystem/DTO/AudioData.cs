

namespace SaveLoadSystem.DTO {
  [System.Serializable]
  public class AudioData {
    public AudioData(float masterVolume, float musicVolume) {
      this.masterVolume = masterVolume;
      this.musicVolume = musicVolume;
    }

    //data members
    public float masterVolume;
    public float musicVolume;
  }
}
