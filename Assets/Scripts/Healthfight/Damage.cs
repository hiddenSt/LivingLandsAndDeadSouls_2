
namespace HealthFight {

  public class Damage {
    public Damage(int damagePoints) {
      _damagePoints = damagePoints;
    }

    public void IncreaseDamage(int points) {
      _damagePoints += points;
    }

    public void DecreaseDamage(int points) {
      _damagePoints -= points;
      if (_damagePoints < 0)
        _damagePoints = 0;
    }

    public void MakeDamage(Health health) {
      health.Increase(_damagePoints);
    }

    public int GetDamagePoints() {
      return _damagePoints;
    }

    private int _damagePoints;
  }
}
