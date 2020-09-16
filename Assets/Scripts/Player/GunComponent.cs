using HealthFight;
using UnityEngine;
using UnityEngine.UI;

namespace Player {

  public class GunComponent : MonoBehaviour {
    public Button fireButton;
    
    private void Start() {
      fireButton.interactable = false;
      _playerTransform = gameObject.transform;
      _playerController = gameObject.GetComponent<Player.PlayerController>();
      _ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
    }

    public void SetGun(Items.Gun gun) {
      _gun = gun;
      _fireRate = _gun.GetFireRate();
      _damage = _gun.GetDamage();
      _ammoCount = _gun.GetAmmoCount();
      fireButton.interactable = true;
      fireButton.onClick.AddListener(Shot);
    }

    public void Shot() {
      if (_ammoCount <= 0)
        return;
      
      _direction = _playerController.moveVelocity;
      
      if (_direction == Vector2.zero) {
        SendBulletWhenStandStill();
        --_ammoCount;
        ChangeBulletsCountUi();
        return;
      }
      
      for (int i = 0; i < _fireRate; ++i) {
        --_ammoCount;
        ChangeBulletsCountUi();
        SendBullet(_direction);
        if (_ammoCount <= 0)
          return;
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
      _bullet = Bullet.Create(_playerController.transform, directionVec2,5f * _fireRate, _damage.GetDamagePoints() + _damageBuff,
        0.1f, gameObject.GetInstanceID());
    }

    private void ChangeBulletsCountUi() {
      _ammoText.text = _ammoCount.ToString();
    }
    
    public void RemoveGun() {
      fireButton.interactable = true;
      fireButton.onClick.AddListener(Shot);
      _gun.SetAmmoCount(_ammoCount);
      _gun = null;
      _ammoText.text = "0";
    }

    private int _damageBuff = 0;
    private int _ammoCount;
    private int _fireRate;
    private Damage _damage;
    private Items.Gun _gun;
    private Transform _playerTransform;
    private Vector2 _direction;
    private Player.PlayerController _playerController;
    private GameObject _bullet;
    private Text _ammoText;
  }
}
