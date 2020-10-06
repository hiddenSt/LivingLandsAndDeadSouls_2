using HealthFight;
using Items;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Player;

namespace Components.Player {
  
  public class GunComponent : MonoBehaviour {
    public Button fireButton;
    private IGunSlotUi _gunSlotUi;
    private float _damageBuff = 0;
    private int _ammoCount;
    private Vector2 _direction;
    private InventoryComponent _playerInventoryComponent;
    private PlayerController _playerController;
    private Gun _gun;
    private OutfitComponent _outfitComponent;

    public void SetGun(Items.Gun gun) {
      if (_gun != null) {
        DeactivateGun();
        _gun.SetAmmoCount(_ammoCount);
        _playerInventoryComponent.AddItem(_gun);
      }
      _gun = gun;
      _outfitComponent.ChangeGunSkin(_gun.GetGunType());
      _ammoCount = _gun.GetAmmoCount();
      ActivateGun();
    }
    
    public void RemoveToInventoryOrDrop() {
      var itemIsAdded = _playerInventoryComponent.AddItem(_gun);
      if (!itemIsAdded) {
        _playerInventoryComponent.DropItem(_gun);
      }
      DeactivateGun();
      _gun.SetAmmoCount(_ammoCount);
      _gun = null;
      _outfitComponent.ChangeGunSkin("WithoutGun");
      _gunSlotUi.ChangeAmmoCount(0);
    }

    public Gun GetGun() {
      if (_gun == null) {
        return null;
      }
      _gun.SetAmmoCount(_ammoCount);
      return _gun;
    }

    public void AddAmmo(int ammo) {
      if (_gun == null) {
        return;
      }
      _ammoCount += ammo;
      _gunSlotUi.ChangeAmmoCount(_ammoCount);
    }
    
    private void ActivateGun() {
      fireButton.interactable = true;
      fireButton.onClick.AddListener(Shot);
      _gunSlotUi.SetGunImageAndActivateListener(_gun.GetItemUi().GetItemImage());
      _gunSlotUi.ChangeAmmoCount(_ammoCount);
    }

    public void Shot() {
      if (_ammoCount <= 0) {
        return;
      }
      _direction = _playerController.moveVelocity;
      if (_direction == Vector2.zero) {
        for (int i = 0; i < _gun.GetFireRate(); ++i) {
          SendBulletWhenStandStill();
          if (_ammoCount <= 0) {
            return;
          }
        }
        return;
      }
      
      for (var i = 0; i < _gun.GetFireRate(); ++i) {
        SendBullet(_direction);
        if (_ammoCount <= 0) {
          return;
        }
      }
    }

    public void SetGunSlotUi(IGunSlotUi gunSlotUi) {
      _gunSlotUi = gunSlotUi;
    }

    public void SetOutfitComponent(OutfitComponent outfitComponent) {
      _outfitComponent = outfitComponent;
    }

    private void SendBulletWhenStandStill() {
      switch (_playerController.direction) {
        case 0:
          SendBullet(new Vector2(0, -1));
          break;
        case 1:
          SendBullet(new Vector2(0, 1));
          break;
        case 2:
          SendBullet(new Vector2(1, 0));
          break;
        case 3:
          SendBullet(new Vector2(-1, 0));
          break;
      }
    }

    private void SendBullet(Vector2 directionVec2) {
      Bullet.Create(_playerController.transform, directionVec2, 5f * _gun.GetFireRate(),
                      _gun.GetDamagePoints() + _damageBuff, 0.1f, gameObject.GetInstanceID());
      --_ammoCount;
      _gunSlotUi.ChangeAmmoCount(_ammoCount);
    }

    private void DeactivateGun() {
      fireButton.interactable = false;
      fireButton.onClick.RemoveListener(Shot);
      _gunSlotUi.RemoveGunImageAndDeactivateListener();
      _gunSlotUi.ChangeAmmoCount(0);
    }
    
    public void SetUp() {
      _playerController = gameObject.GetComponent<PlayerController>();
      _playerInventoryComponent = gameObject.GetComponent<InventoryComponent>();
      _outfitComponent = gameObject.GetComponent<OutfitComponent>();
      fireButton.interactable = false;
      _gun = null;
    }
  }
}