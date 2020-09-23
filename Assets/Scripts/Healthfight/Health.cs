namespace HealthFight {
  
  public class Health {
    private float _healthPoints;
    private float _healthPointsLimit;
    private IHealthUi _healthUi;
    
    public Health(float healthPoints, float healthPointsLimit, IHealthUi healthUi) {
      _healthPoints = healthPoints;
      _healthPointsLimit = healthPointsLimit;
      _healthUi = healthUi;
      _healthUi.SetHealthPoints(_healthPoints);
      _healthUi.SetHealthPointsLimit(_healthPointsLimit);
    }

    public void SetHealthPoints(float points) {
      _healthPoints = points;
      if (_healthPoints < 0) {
        _healthPoints = 0;
      }

      if (_healthPoints > _healthPointsLimit) {
        _healthPoints = _healthPointsLimit;
      }
      _healthUi.SetHealthPoints(_healthPoints);
    }

    public void Decrease(float points) {
      _healthPoints -= points;
      if (_healthPoints < 0)
        _healthPoints = 0;
      _healthUi.SetHealthPoints(_healthPoints);
    }

    public void Increase(float points) {
      _healthPoints += points;
      if (_healthPoints >= _healthPointsLimit) {
        _healthPoints = _healthPointsLimit;
      }
      _healthUi.SetHealthPoints(points);
    }

    public float GetHealthPoints() {
      return _healthPoints;
    }

    public void SetHealthPointsLimit(float points) {
      _healthPointsLimit = points;
      if (_healthPoints > _healthPointsLimit) {
        _healthPoints = _healthPointsLimit;
      }

      _healthUi.SetHealthPointsLimit(_healthPointsLimit);
    }

    public float GetHealthPointsLimit() {
      return _healthPointsLimit;
    }

    public bool IsDead() {
      return _healthPoints <= 0;
    }

    public bool IsAlive() {
      return _healthPoints >= 0;
    }
  }
  
}