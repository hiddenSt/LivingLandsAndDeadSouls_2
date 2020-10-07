using DataTransferObjects;
using HealthFight;
using UnityEngine;

namespace SpawnSystem {
  public class Spawner : MonoBehaviour {
    public void SetUp() {
      _xAxisBeginOfRange = -ParameterManager.instance.MapSizeVector.x / 2f;
      _xAxisEndOfRange = ParameterManager.instance.MapSizeVector.x / 2f;
      _yAxisBeginOfRange = -ParameterManager.instance.MapSizeVector.y / 2f; 
      _yAxisEndOfRange = ParameterManager.instance.MapSizeVector.y / 2f;
      _enemyCount = ParameterManager.instance.HostileCharVal;
      _animalsCount = ParameterManager.instance.NeutralCharVal;
    }

    public void SpawnEnemies(IHealthEventSubscriber[] subscribers) {
      for (int i = 0; i < enemyGameObjects.Length; ++i) {
        for (int j = 0; j < _enemyCount / enemyGameObjects.Length; ++j) {
          _randX = Random.Range(_xAxisBeginOfRange, _xAxisEndOfRange);
          _randY = Random.Range(_yAxisBeginOfRange, _yAxisEndOfRange);
          _spawnPosition = new Vector2(_randX, _randY);
          var spawnedObj = Instantiate(enemyGameObjects[i], _spawnPosition, Quaternion.identity);
          var healthComp = spawnedObj.GetComponent<HealthComponent>();
          healthComp.SetUp();
          AddSubscribers(healthComp, subscribers);
        }
      }
    }

    public void SpawnAnimals(IHealthEventSubscriber[] subscribers) {
      for (int i = 0; i < commonAnimals.Length; ++i) {
        for (int j = 0; j < _animalsCount / commonAnimals.Length; ++j) {
          _randX = Random.Range(_xAxisBeginOfRange, _xAxisEndOfRange);
          _randY = Random.Range(_yAxisBeginOfRange, _yAxisEndOfRange);
          _spawnPosition = new Vector2(_randX, _randY);
          var spawnedObj = Instantiate(commonAnimals[i], _spawnPosition, Quaternion.identity);
          var healthComp = spawnedObj.GetComponent<HealthComponent>();
          healthComp.SetUp();
          AddSubscribers(healthComp, subscribers);
        }
      }
    }

    private void AddSubscribers(HealthComponent healthComponent, IHealthEventSubscriber[] subscribers) {
      foreach (var subscriber in subscribers) {
        healthComponent.AddSubscriber(subscriber);
      }
    }

    //data members
    public GameObject[] enemyGameObjects;
    public GameObject[] commonAnimals;
    private float _xAxisBeginOfRange;
    private float _xAxisEndOfRange;
    private float _yAxisBeginOfRange;
    private float _yAxisEndOfRange;
    private float _randX;
    private float _randY;
    private Vector2 _spawnPosition;
    private int _enemyCount;
    private int _animalsCount;
  }
}