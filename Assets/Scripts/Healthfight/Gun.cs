using UnityEngine;
using UnityEngine.UI;

namespace HealthFight { 
  public class Gun : MonoBehaviour {
    public void Use() {
      _direction = _playerController.moveVelocity;
      
      if (ammoCount <= 0)
        return;
      
      if (_direction == Vector2.zero) {
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
        
        --ammoCount;
        ChangeBulletsCountUi();
        return;
      }
      
      for (int i = 0; i < fireRate; ++i) {
        --ammoCount;
        ChangeBulletsCountUi();
        _bullet = Bullet.Create(_playerController.transform, _direction, 5f * fireRate, damage + damageBuff,
            _damageRadius, _originID);
        if (ammoCount <= 0)
          return;
      }
    }
    
    private void Start() {
      ammoCount = 0;
      _originID = GameObject.Find("Player").GetInstanceID();
      _playerController = GameObject.Find("Player").GetComponent<Player.PlayerController>();
      _ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
      damage = 0;
      _damageRadius = 0.2f;
      fireRate = 0;
      _ammoText.text = ammoCount.ToString();
    }

    public void SetGun(int damage, int ammoCount, int fireRate) {
      this.damage = damage;
      this.ammoCount = ammoCount;
      this.fireRate = fireRate;
      _ammoText.text = ammoCount.ToString();
    }
    
    private void SendBullet(Vector2 directionVec2) {
      _bullet = Bullet.Create(_playerController.transform, directionVec2,5f * fireRate, damage + damageBuff,
        _damageRadius, _originID);
    }

    private void ChangeBulletsCountUi() {
      _ammoText.text = ammoCount.ToString();
    }
        
    public int fireRate;
    public int ammoCount;
    public int damage;
    public int damageBuff = 10;

    private int _originID;
    private Vector2 _direction;
    private float _damageRadius;
    private GameObject _bullet;
    private Player.PlayerController _playerController;
    private Text _ammoText;
    }
}//end of namespace HealthFight