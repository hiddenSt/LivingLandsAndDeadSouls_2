using HealthFight;
using UnityEngine;

namespace Components.Player {

  public class CharacteristicsComponent : MonoBehaviour, IHealthEventSubscriber {
    private Health _playerHealth;
    private GunComponent _playerGunComponent;
    private int _experiencePoints;
    private int _freePoints;
    private float _damageBuff;
    private float _healthLimit;
    private int _accuracy;
    private int _currentEntityId = -1;
    private ICharacteristicsUi _characteristicsUi;
    private int _level;
    private int _damagePoints;
    private int _healthPoints;

    public void EntityIsDead(Vector3 position, int originId) {
      if (originId == _currentEntityId) {
        return;
      }
      _currentEntityId = originId;
      IncreaseExperiencePoints();
      _currentEntityId = -1;
    }

    public void Setup(Health playerHealth, GunComponent playerGunComponent, ICharacteristicsUi characteristicsUi) {
      _characteristicsUi = characteristicsUi;
      _playerHealth = playerHealth;
      _playerGunComponent = playerGunComponent;
    }

    public void SetUpCharacteristics(int experience, int freePoints, float damageBuff, float healthLimit, int accuracy) {
      _experiencePoints = experience;
      _freePoints = freePoints;
      _damageBuff = damageBuff;
      _healthLimit = healthLimit;
      _accuracy = accuracy;
      _level = 1;
      if (experience % 2 == 1) {
        experience -= 1;
      }
      while (experience > 0) {
        experience -= 2;
        _level += 1;
      }

      _healthPoints = 0;
      healthLimit -= 100;
      while (healthLimit > 0) {
        _healthPoints += 1;
        healthLimit -= 20f;
      }

      _damagePoints = 0;
      while (damageBuff > 0) {
        _damagePoints += 1;
        damageBuff -= 5f;
      }
      
      _characteristicsUi.SetLevel(_level);
      _characteristicsUi.SetFreePoints(_freePoints);
      _characteristicsUi.SetHealthLimitPoints(_healthPoints);
      _characteristicsUi.SetDamageBuffPoints(_damagePoints);
      _characteristicsUi.SetAccuracyPoints(_accuracy);
    }
    
    public void BuffHealthLimit() {
      if (_freePoints <= 0)
        return;
      --_freePoints;
      _characteristicsUi.SetFreePoints(_freePoints);
      _healthLimit += 20f;
      _healthPoints += 1;
      _playerHealth.SetHealthPointsLimit(_healthLimit);
      _characteristicsUi.SetHealthLimitPoints(_healthPoints);
    }

    public void BuffDamage() {
      if (_freePoints <= 0)
        return;
      --_freePoints;
      _characteristicsUi.SetFreePoints(_freePoints);
      _damageBuff += 5f;
      _damagePoints += 1;
      _playerGunComponent.SetDamageBuff(_damageBuff);
      _characteristicsUi.SetDamageBuffPoints(_damagePoints);
    }

    public void BuffAccuracy() {
      if (_freePoints <= 0)
        return;
      --_freePoints;
      _characteristicsUi.SetFreePoints(_freePoints);
      _accuracy += 1;
      _characteristicsUi.SetAccuracyPoints(_accuracy);
    }
    
    private void IncreaseExperiencePoints() {
      ++_experiencePoints;
      if (_experiencePoints % 2 != 0 || _experiencePoints == 0) {
        return;
      }

      ++_level;
      _characteristicsUi.SetLevel(_level);
      ++_freePoints;
      _characteristicsUi.SetFreePoints(_freePoints);
    }

    public float GetDamageBuff() {
      return _damageBuff;
    }

    public int GetExperience() {
      return _experiencePoints;
    }

    public int GetFreePoints() {
      return _freePoints;
    }

    public int GetAccuracy() {
      return _accuracy;
    }
  }

}