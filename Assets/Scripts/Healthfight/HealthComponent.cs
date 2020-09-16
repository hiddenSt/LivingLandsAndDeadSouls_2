using System;
using UnityEngine;


namespace HealthFight {

  public class HealthComponent : MonoBehaviour {
    private void Start() {
      originId = this.gameObject.GetInstanceID();

      _health = new Health(health, maxHealth);

      //Bad if statement
      if (bar == null) {
        CreateHealthBar();
      }
      
      _animator = this.gameObject.GetComponent<Animator>();
    }

    //Dependency on DamageComponent and Dirty function
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.GetComponent<DamageComponent>() == null ||
          other.GetComponent<DamageComponent>().originId == this.originId)
        return;
      DecreaseHealth(other.gameObject.GetComponent<DamageComponent>().damagePoints);
      Debug.Log("Got damagePoints from " + other.name);

      if (_health.IsAlive())
        return;
      //:(   
      _animator.Play("Death_left");
      _animator.speed = 0.5f;
      GameObject.Find("Characteristics").GetComponent<Characteristics.AllParameters>().AddExperience(50); // Dirty dependency

      Destroy(bar.gameObject);
      Destroy(other.gameObject);
      Destroy(this.gameObject);
    }

    public void IncreaseHealthPointsLimit(int points) {
      maxHealth += points;
      _health.SetHealthPointsLimit(maxHealth);
    }
    
    //Bad Dependency
    private void CreateHealthBar() {
      bar = HealthBar.Create(this.gameObject.transform, new Vector3(60f, 10f), 7f, Color.green, Color.grey, 100f, 0.4f);
      bar.initialHealth = health;
      bar.maxHealth = maxHealth;
    }

    public void GetDamageFrom(Damage damage) {
      damage.MakeDamage(_health);
    }
    
    //Bad parameter name
    public void DecreaseHealth(int points) { 
      _health.Decrease(points);
      
      if (_health.IsDead()) {
        _animator.Play("Death_left");
        Destroy(this.gameObject);
      }
      
      health = _health.GetHealthPoints();
      //...
      if (OnHealthChanged != null) {
        OnHealthChanged.Invoke(health);
      }
      
      bar.SetSize(health/100f);
    }
    
    //...
    public void SetHealth(int healthPoints) {
      if (healthPoints > maxHealth)
        healthPoints = maxHealth;
      
      health = healthPoints;
      //...
      if (OnHealthChanged != null) {
        OnHealthChanged.Invoke(health);
      }
      //...
      bar.SetSize(health/maxHealth);
    }
        
    //Dependency on HealthBar
    public void IncreaseHealth(int points) {
      _health.Increase(points);
      
      health = _health.GetHealthPoints();
      //...
      if (OnHealthChanged != null) {
        OnHealthChanged.Invoke(health);
      }
      
      //...
      bar.SetSize(health/maxHealth);
    }

    public int health;
    public int originId;
    public int maxHealth = 100;
    public HealthBar bar = null;
    public event Action<int> OnHealthChanged;
    
    private Health _health;
    private Animator _animator;
  }
  
}//end of namespace HealthFight