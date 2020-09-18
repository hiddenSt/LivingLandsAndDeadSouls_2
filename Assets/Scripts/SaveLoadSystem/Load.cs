using Menu;
using UnityEngine;


namespace SaveLoadSystem {
  public class Load : MonoBehaviour {
    private void Update() {

      if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().needToLoad == true) {
        SaveLoadSystem.SaveSystem.Load();
      }

      Destroy(this.gameObject);
    }
  }
}