namespace HealthFight {
  public class Damage {
    public Damage(float damagePoints) {
      _damagePoints = damagePoints;
    }

    public void IncreaseDamage(float points) {
      _damagePoints += points;
    }

    public void DecreaseDamage(float points) {
      _damagePoints -= points;
      if (_damagePoints < 0)
        _damagePoints = 0;
    }

    public float GetDamagePoints() {
      return _damagePoints;
    }

    private float _damagePoints;
  }
}