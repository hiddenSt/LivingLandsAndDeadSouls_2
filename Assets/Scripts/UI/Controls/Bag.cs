using UnityEngine;

namespace InventorySystem {
  public class Bag : MonoBehaviour {
    public GameObject[] inventorySlots;
    
    private void Start() {
      _skills = GameObject.Find("Skills");
    }
    

    public bool IsClosed() {
      return _isClosed;
    }

    public void OpenCloseBag() {
      if (_isClosed == true) {
        foreach (var bagElement in inventorySlots)
          bagElement.SetActive(true);
        _skills.SetActive(true);
        _isClosed = false;
      }
      else {
        foreach (var bagElement in inventorySlots)
          bagElement.SetActive(false);
        _skills.SetActive(false);
        _isClosed = true;
      }
    }

    //data members
    private bool _isClosed;
    private GameObject _skills;
  }
}
