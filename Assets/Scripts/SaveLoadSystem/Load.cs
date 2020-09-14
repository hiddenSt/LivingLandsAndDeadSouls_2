using Menu;
using UnityEngine;


namespace SaveLoadSystem {
  public class Load : MonoBehaviour {
    private void Update() {
      while (GameObject.Find("GunSlot") == null) { }

      if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad == true) {
        SaveLoadSystem.SaveSystem.Load();
      }

      Destroy(this.gameObject);
    }
  }
}