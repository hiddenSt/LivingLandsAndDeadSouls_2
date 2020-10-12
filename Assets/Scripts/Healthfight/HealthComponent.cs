using System.Collections.Generic;
using UI.HealthFightSystemUi;
using UnityEngine;
using UnityEngine.Serialization;


namespace HealthFight {
  
  public class HealthComponent : MonoBehaviour {
    [FormerlySerializedAs("health")] public float healthPoints;
    public int originId;
    public float maxHealth = 100;
    public HealthBarUi healthBarUi;
    private List<IHealthEventSubscriber> _subscribers;
    private Health _health;
    private bool _isDead = false;

    public void Setup() {
      _subscribers = new List<IHealthEventSubscriber>();
      originId = gameObject.GetInstanceID();
      _health = new Health(healthPoints, maxHealth, healthBarUi);
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.GetComponent<DamageComponent>() == null ||
          other.GetComponent<DamageComponent>().originId == originId)
        return;
      var damage = other.GetComponent<DamageComponent>().GetDamage();
      DecreaseHealth(damage.GetDamagePoints());
    }

    public void DecreaseHealth(float points) {
      _health.Decrease(points);

      if (_health.IsDead() && !_isDead) {
        _isDead = true;
        NotifySubscribers();
        Destroy(gameObject);
      }

      healthPoints = _health.GetHealthPoints();
    }

    public void IncreaseHealthPointsLimit(float points) {
      _health.SetHealthPointsLimit(maxHealth);
      maxHealth = _health.GetHealthPointsLimit();
    }

    public Health GetHealthEntity() {
      return _health;
    }

    public void SetHealthEntity(Health health) {
      _health = health;
    }
    
    public void SetHealth(float healthPoints) {
      _health.SetHealthPoints(healthPoints);
      this.healthPoints = _health.GetHealthPoints();
    }
    
    public void IncreaseHealth(float points) {
      _health.Increase(points);
      healthPoints = _health.GetHealthPoints();
    }

    public bool IsDead() {
      return _health.IsDead();
    }

    public void AddSubscriber(IHealthEventSubscriber subscriber) {
      _subscribers.Add(subscriber);
      
    }
    
    private void  NotifySubscribers() {
      var objectPosition = new Vector3(transform.position.x, transform.position.y);
      Debug.Log("Subs count + " + _subscribers.Count);
      foreach (var subscriber in _subscribers) {
        subscriber.EntityIsDead(objectPosition, originId);
      }
    }
  }
  
}