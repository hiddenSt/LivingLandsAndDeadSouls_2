using UnityEngine;

namespace InventorySystem {
  public class GunSelect : MonoBehaviour {
    private void Start() {
      _gunSlot = GameObject.Find("GunSlot");
      _gunSlotComponent = _gunSlot.GetComponent<GunSlot>();
    }

    public void Use() {
      if (_gunSlot.transform.childCount > 1) {
        _gunSlotComponent.SwapGuns(slotIndex);
      }

      _gunSlotComponent.SetGun(gunButton);
      Destroy(imageObj);
      Destroy(gameObject);
    }

    public void LoadGun() {
      //_gunSlot = GameObject.Find("GunSlot");
      _gunSlotComponent.animatorOverride = animatorOverride;
      Instantiate(gunImage, _gunSlot.transform, false);
      _gunSlotComponent.SetGun(gunButton);
      _fireButton = GameObject.Find("FireButton").GetComponent<HealthFight.Gun>();
      _fireButton.SetGun(damage, ammoCount, fireRate);
    }

    public void DestroyItem() {
      Destroy(this.gameObject);
    }


    //data members
    public GameObject gunButton;
    public GameObject gunImage;
    public int damage;
    public int slotIndex;
    public int fireRate;
    public int ammoCount;
    public AnimatorOverrideController[] animatorOverride;
    public GameObject imageObj;

    private GameObject _gunSlot;
    private GunSlot _gunSlotComponent;
    private HealthFight.Gun _fireButton;
  }
}