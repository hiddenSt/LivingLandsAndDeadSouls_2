using UnityEngine;



namespace HealthFight {

  public class HealthComponent : MonoBehaviour { 
    void Start() {
      originID = this.gameObject.GetInstanceID();
      
      //Bad if statement
      if (!isPlayer) {
        CreateHealthBar();
        _bar.maxHealth = maxHealth;
      } else {
        var barObj = GameObject.Find("PlayerHealthBar");
        _bar = barObj.GetComponent<HealthBar>();
        _bar.initialHealth = health;
      }
      
      var circleCollider = this.gameObject.GetComponent<CircleCollider2D>();
      _animator = this.gameObject.GetComponent<Animator>();
    }
    
    //Bad Dependency
    private void CreateHealthBar() {
      _bar = HealthBar.Create(this.gameObject.transform, new Vector3(60f, 10f), 7f, Color.green, Color.grey, 100f, 0.4f);
      _bar.initialHealth = health;
    }
    
    //Bad parameter name
    public void DecreaseHealth(int decrease) { 
      health -= decrease; 
      
      if (health <= 0) {
        _animator.Play("Death_left");
        Destroy(this.gameObject);
      }
      
      _bar.SetSize(health/100f);
    }
    
    public void SetHealth(int healthPoints) {
      if (healthPoints > maxHealth)
        healthPoints = maxHealth;
      
      health = healthPoints;
      _bar.SetSize(health/maxHealth);
    }
        
    //Dependency on HealthBar
    public void IncreaseHealth(int increase) {
      health += increase;

      if (health > maxHealth)
        health = maxHealth;
      
      _bar.SetSize(health/maxHealth);
    }
        
    //Dependency on DamageComponent and Dirty function
    private void OnTriggerEnter2D(Collider2D other) {
      if (other.GetComponent<DamageComponent>() == null || other.GetComponent<DamageComponent>().originID == this.originID)
        return;
      DecreaseHealth(other.gameObject.GetComponent<DamageComponent>().damagePoints);
      Debug.Log("Got damagePoints from " + other.name);
      
      if (health > 0)
        return;
      
      _animator.Play("Death_left");
      _animator.speed = 0.5f;
      GameObject.Find("Characteristics").GetComponent<AllParameters>().AddExperience(50); // Dirty dependency
      
      Destroy(_bar.gameObject);
      Destroy(other.gameObject);
      Destroy(this.gameObject);
    } 
    
    public int health;
    public bool isPlayer = false;
    public int originID;
    public int maxHealth = 100;

    private Health _health;
    
    private HealthBar _bar;
    private Animator _animator;
  }
  
}//end of namespace HealthFight