using UI.HealthFightSystemUi;
using UnityEngine;


namespace HealthFight {
  
  public class HealthComponent : MonoBehaviour {
    public float health;
    public int originId;
    public float maxHealth = 100;
    public HealthBarUi healthBarUi;
    private Health _health;
    private Animator _animator;

    private void OnTriggerEnter2D(Collider2D other) {
      if (other.GetComponent<DamageComponent>() == null ||
          other.GetComponent<DamageComponent>().originId == originId)
        return;
      GetDamageFrom(other.GetComponent<DamageComponent>().GetDamage());
    }

    public void IncreaseHealthPointsLimit(float points) {
      _health.SetHealthPointsLimit(maxHealth);
      maxHealth = _health.GetHealthPointsLimit();
    }

    public void GetDamageFrom(Damage damage) {
      damage.MakeDamage(_health);
    }
    
    public void DecreaseHealth(float points) {
      _health.Decrease(points);

      if (_health.IsDead()) {
        _animator.Play("Death_left");
        Destroy(gameObject);
      }

      health = _health.GetHealthPoints();
    }
    
    public void SetHealth(float healthPoints) {
      _health.SetHealthPoints(healthPoints);
      health = _health.GetHealthPoints();
    }
    
    public void IncreaseHealth(float points) {
      _health.Increase(points);
      health = _health.GetHealthPoints();
    }

    private void Start() {
      originId = gameObject.GetInstanceID();
      _animator = gameObject.GetComponent<Animator>();
      _health = new Health(health, maxHealth, healthBarUi);
    }
  }
}