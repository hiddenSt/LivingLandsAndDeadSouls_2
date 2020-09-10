using UnityEngine;

namespace Characteristics
{
  public class ActiveController : MonoBehaviour {
    private GameObject _characteristics;

    public void Start() {
      _characteristics = GameObject.Find("Characteristics");
    }

    public void Enable() {
      _characteristics.GetComponent<Canvas>().enabled = true;
      _characteristics.GetComponent<AllParameters>().Display();
    }

    public void Disable() {
      _characteristics.GetComponent<Canvas>().enabled = false;
    }
  }
}