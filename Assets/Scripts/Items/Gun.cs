using HealthFight;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Items {

  public class Gun : InventorySystem.NewInventorySystem.Item {
    public Gun(string gunType, int fireRate, int damagePoints, int ammoCount, int ammoLimit, Image gunImage) {
      _type = "Gun";
      _fireRate = fireRate;
      _ammoCount = ammoCount;
      _ammoLimit = ammoLimit;
      _damage = new Damage(damagePoints);
      _gunType = gunType;
      _gunImage = gunImage;
    }
    
    public override void Use() {
      _gunComponent.SetGun(this);
      _outfitComponent.ChangeGunSkin(_gunType);
      var button = _gunSlotUi.GetComponent<Button>();
    }

    public override void Drop() {
      _gunComponent = null;
    }

    public override void PickUp() {
      _gunComponent = GameObject.Find("Player").GetComponent<GunComponent>();
      _gunSlotUi = GameObject.Find("GunSlot");
    }
    
    public void SetGunTypeIndex(int index) {
      _gunTypeIndex = index;
    }

    public int GetGunTypeIndex() {
      return _gunTypeIndex;
    }

    public void SetAmmoLimit(int points) {
      _ammoLimit = points;
    }

    public int GetAmmoLimit() {
      return _ammoLimit;
    }

    public void SetAmmoCount(int points) {
      _ammoCount = points;
    }

    public int GetAmmoCount() {
      return _ammoCount;
    }

    public Damage GetDamage() {
      return _damage;
    }

    public int GetFireRate() {
      return _fireRate;
    }

    public string GetGunType() {
      return _gunType;
    }
    
    private int _fireRate;
    private int _ammoLimit;
    private Damage _damage;
    private int _ammoCount;
    private int _gunTypeIndex;
    private GunComponent _gunComponent;
    private string _gunType;
    private OutfitComponent _outfitComponent;
    private GameObject _gunSlotUi;
    private Image _gunImage;
  }
}
