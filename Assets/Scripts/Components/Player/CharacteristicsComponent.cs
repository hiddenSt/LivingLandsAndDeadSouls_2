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
    private ICharacteristicsUi _characteristicsUi;

    public void EntityIsDead() {
      _experiencePoints += 1;
      IncreaseExperiencePoints();
    }

    public void SetUp(Health playerHealth, GunComponent playerGunComponent, ICharacteristicsUi characteristicsUi) {
      _damageBuff = 0f;
      _freePoints = 0;
      _experiencePoints = 0;
      _characteristicsUi = characteristicsUi;
      _playerHealth = playerHealth;
      _playerGunComponent = playerGunComponent;
      _healthLimit = _playerHealth.GetHealthPointsLimit();
      _characteristicsUi.SetHealthLimitPoints((int)_healthLimit);
    }
    
    public void BuffHealthLimit() {
      if (_freePoints <= 0)
        return;
      --_freePoints;
      _characteristicsUi.SetFreePoints(_freePoints);
      _healthLimit += 20f;  
      _playerHealth.SetHealthPointsLimit(_healthLimit);
      var points = (int)(_healthLimit);
      _characteristicsUi.SetHealthLimitPoints(points);
    }

    public void BuffDamage() {
      if (_freePoints <= 0)
        return;
      --_freePoints;
      _characteristicsUi.SetFreePoints(_freePoints);
      _damageBuff += 5f;
      _playerGunComponent.SetDamageBuff(_damageBuff);
      var points = (int) (_damageBuff);
      _characteristicsUi.SetDamageBuffPoints(points);
    }
    
    private void IncreaseExperiencePoints() {
      ++_experiencePoints;
      if (_experiencePoints % 2 != 0 || _experiencePoints == 0) {
        return;
      }
      ++_freePoints;
      _characteristicsUi.SetFreePoints(_freePoints);
    }
  }

}