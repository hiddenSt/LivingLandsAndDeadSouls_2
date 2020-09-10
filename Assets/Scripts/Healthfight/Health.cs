
namespace HealthFight {

  public class Health {
    public Health(int healthPoints, int healthPointsLimit) {
      _healthPoints = healthPoints;
      _healthPointsLimit = healthPointsLimit;
    }

    public void Decrease(int points) {
      _healthPoints -= points;
      if (_healthPoints < 0)
        _healthPoints = 0;
    }

    public void Increase(int points) {
      _healthPoints += points;
      if (_healthPoints >= _healthPointsLimit)
        _healthPoints = _healthPointsLimit;
    }

    public int GetHealthPoints() {
      return _healthPoints;
    }

    public void SetHealthPointsLimit(int points) {
      _healthPointsLimit = points;
      if (_healthPoints > _healthPointsLimit)
        _healthPoints = _healthPointsLimit;
    }

    public int GetHealthPointsLimit() {
      return _healthPointsLimit;
    }

    public bool IsDead() {
      return _healthPoints <= 0;
    }

    public bool IsAlive() {
      return _healthPoints >= 0;
    }
    
    private int _healthPoints;
    private int _healthPointsLimit;
  }
}
