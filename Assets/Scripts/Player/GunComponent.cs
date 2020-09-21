using Components;
using HealthFight;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player {
  
  public class GunComponent : MonoBehaviour {
    public Button fireButton;
    public IGunSlotUi gunSlotUi;
    private int _damageBuff = 0;
    private int _ammoCount;
    private Vector2 _direction;
    private GameObject _bullet;
    private bool _isActive;
    private InventoryComponent _playerInventoryComponent;
    private PlayerController _playerController;
    private Transform _playerTransform;
    private Items.Gun _gun;

    public void SetGun(Items.Gun gun) {
      if (_isActive) {
        RemoveToInventoryOrDrop();
      }
      _gun = gun;
      _ammoCount = _gun.GetAmmoCount();
      ActivateGun();
    }
    
    public void RemoveToInventoryOrDrop() {
      var itemIsAdded = _playerInventoryComponent.AddItem(_gun, _gun.GetGunImage());
      if (!itemIsAdded) {
        DropGun();
      }
      DeactivateGun();
      _gun.SetAmmoCount(_ammoCount);
      _gun = null;
      gunSlotUi.ChangeAmmoCount(0);
    }
    
    private void ActivateGun() {
      _isActive = true;
      fireButton.interactable = true;
      fireButton.onClick.AddListener(Shot);
      gunSlotUi.SetGunImageAndActivateListener(_gun.GetGunImage());
    }

    public void Shot() {
      if (_ammoCount <= 0) {
        return;
      }

      _direction = _playerController.moveVelocity;
      if (_direction == Vector2.zero) {
        SendBulletWhenStandStill();
        return;
      }

      for (var i = 0; i < _gun.GetFireRate(); ++i) {
        SendBullet(_direction);
        if (_ammoCount <= 0) {
          return;
        }
      }
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
      _bullet = Bullet.Create(_playerController.transform, directionVec2, 5f * _gun.GetFireRate(),
                      _gun.GetDamagePoints() + _damageBuff, 0.1f, gameObject.GetInstanceID());
      --_ammoCount;
      gunSlotUi.ChangeAmmoCount(_ammoCount);
    }

    private void DropGun() {
      var droppedGun = new GameObject();
      
      var lootComponent = droppedGun.AddComponent<LootComponent>();
      var circleCollider2D = droppedGun.AddComponent<CircleCollider2D>();
      var spriteRenderer = droppedGun.AddComponent<SpriteRenderer>();
      
      lootComponent.item = _gun;
      lootComponent.itemImage = _gun.GetGunImage();
      circleCollider2D.radius = 0.3f;
      spriteRenderer.sprite = _gun.GetGunImage();
      
      _gun.Drop();
      Instantiate(droppedGun);
      droppedGun.transform.position = _playerTransform.position + new Vector3(0, 3f);
    }

    private void DeactivateGun() {
      _isActive = false;
      fireButton.interactable = false;
      fireButton.onClick.RemoveListener(Shot);
      gunSlotUi.RemoveGunImageAndDeactivateListener();
    }
    
    private void Start() {
      _playerController = gameObject.GetComponent<PlayerController>();
      _playerInventoryComponent = gameObject.GetComponent<InventoryComponent>();
      fireButton.interactable = false;
      _playerTransform = gameObject.transform;
      gunSlotUi.SetGunComponent(this);
      _isActive = false;
    }
  }
}