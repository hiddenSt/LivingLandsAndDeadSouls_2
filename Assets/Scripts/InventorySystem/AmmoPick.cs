using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem {
  public class AmmoPick : MonoBehaviour {
    private void Start() {
      _fireButton = GameObject.Find("FireButton");
      _gunSlot = GameObject.Find("GunSlot").GetComponent<GunSlot>();
    }
    
    public void Use() {
      if (_gunSlot.transform.childCount <= 0)
        return;
      _gun = _fireButton.GetComponent<HealthFight.Gun>();
      _gun.ammoCount += ammoCount;
      GameObject.Find("AmmoText").GetComponent<Text>().text = _gun.ammoCount.ToString();
      Destroy(gameObject);
    }

    //data members
    public int ammoCount;

    private GameObject _fireButton;
    private HealthFight.Gun _gun;
    private GunSlot _gunSlot;
  }
}