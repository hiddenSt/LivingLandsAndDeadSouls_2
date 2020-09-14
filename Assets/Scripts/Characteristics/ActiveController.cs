using UnityEngine;

namespace Characteristics {
  public class ActiveController : MonoBehaviour {
    public void Enable() {
      _characteristics.GetComponent<Canvas>().enabled = true;
      _characteristics.GetComponent<AllParameters>().Display();
    }

    public void Disabled() {
      _characteristics.GetComponent<Canvas>().enabled = false;
    }
    
    private void Start() {
      _characteristics = GameObject.Find("Characteristics");
    }
    
    private GameObject _characteristics;
  }
}