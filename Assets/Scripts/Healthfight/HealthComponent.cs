using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;


namespace HealthFight
{
    public class HealthComponent : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            originID = this.gameObject.GetInstanceID();
            if (!isPlayer)
            {
                CreateHealthBar();
                _bar.maxHealth = maxHealth;
            }
            else
            {
                var barObj = GameObject.Find("PlayerHealthBar");
                _bar = barObj.GetComponent<HealthBar>();
                _bar.initialHealth = health;
            }
            var circleCollider = this.gameObject.GetComponent<CircleCollider2D>();
            _animator = this.gameObject.GetComponent<Animator>();
            lootStorage = GameObject.Find("LootStorage");
        }

        private void CreateHealthBar()
        {
            _bar = HealthBar.Create(this.gameObject.transform, new Vector3(60f, 10f), 7f, Color.green, Color.grey, 100f, 0.4f);
            _bar.initialHealth = health;
        }
        
        
        public void DecreaseHealth(int decrease)
        {
            health -= decrease;
            if (health <= 0)
            {
              DropLoot(lootStorage,this.gameObject);
                _animator.Play("Death_left");
                Destroy(this.gameObject);
            }
            _bar.SetSize(health/100f);
        }

        private void DropLoot(GameObject lootStorage, GameObject parentObject){
          int value = new Random().Next(0,100);
          if (value > 50){
            GameObject dropItem = Instantiate(lootStorage.transform.Find("Meat").gameObject);
            dropItem.transform.position = parentObject.transform.position;
          }
        }
        public void SetHealth(int healthPoints)
        {
            if (healthPoints > maxHealth)
                healthPoints = maxHealth;
            health = healthPoints;
            _bar.SetSize(health/maxHealth);
        }
        
        public void IncreaseHealth(int increase)
        {
            health += increase;
            if (health > maxHealth)
                health = maxHealth;
            _bar.SetSize(health/maxHealth);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<DamageComponent>() == null || other.GetComponent<DamageComponent>().originID == this.originID)
                return;
            DecreaseHealth(other.gameObject.GetComponent<DamageComponent>().damage);
            Debug.Log("Got damage from " + other.name);
            if (health > 0)
                return;
            _animator.Play("Death_left");
            _animator.speed = 0.5f;
            GameObject.Find("Characteristics").GetComponent<AllParameters>().AddExperience(50);
            Destroy(_bar.gameObject);
            Destroy(other.gameObject);
            /*if (isPlayer)
            {
                SceneManager.LoadScene("Menu");
                return;
            }*/
            Destroy(this.gameObject);
        }
        
        //data members
        public int health;
        public bool isPlayer = false;
        public int originID;
        public int maxHealth = 100;
        public GameObject lootStorage;
        private HealthBar _bar;
        private Animator _animator;
    }
}//end of namespace HealthFight