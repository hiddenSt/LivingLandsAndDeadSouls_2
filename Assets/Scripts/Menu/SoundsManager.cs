using UnityEngine;

namespace Menu {
  public class SoundsManager : MonoBehaviour {
    public static SoundsManager Instance {
      get {
        if (instance == null) instance = new GameObject("GameManager").AddComponent<SoundsManager>();
        return instance;
      }
    }

    private void Awake() {
      if (instance) {
        DestroyImmediate(gameObject);
      }
      else {
        instance = this;
        DontDestroyOnLoad(gameObject);
      }
    }

    public static SoundsManager instance = null;
  }
}