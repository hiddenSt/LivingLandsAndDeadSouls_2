using HealthFight;
using UnityEngine;

namespace SpawnSystem {
  public class BotsSpawner : MonoBehaviour {
    private Vector3Int _mapSize;
    public GameObject[] enemyGameObjects;
    public GameObject[] commonAnimals;
    private int _enemyCount;
    private int _animalsCount;
    
    public void Setup(int enemyCount, int animalsCount, Vector3Int mapSize) {
      _mapSize = mapSize;
      _animalsCount = animalsCount;
      _enemyCount = enemyCount;
    }

    public void SpawnEnemies(IHealthEventSubscriber[] subscribers) {
      for (int i = 0; i < enemyGameObjects.Length; ++i) {
        for (int j = 0; j < _enemyCount / enemyGameObjects.Length; ++j) {
          var spawnedObj = Instantiate(enemyGameObjects[i], GetRandomSpawnPosition(_mapSize), Quaternion.identity);
          var healthComp = spawnedObj.GetComponent<HealthComponent>();
          healthComp.Setup();
          AddSubscribers(healthComp, subscribers);
        }
      }
    }

    public void SpawnAnimals(IHealthEventSubscriber[] subscribers) {
      for (int i = 0; i < commonAnimals.Length; ++i) {
        for (int j = 0; j < _animalsCount / commonAnimals.Length; ++j) {
          var spawnedObj = Instantiate(commonAnimals[i], GetRandomSpawnPosition(_mapSize), Quaternion.identity);
          var healthComp = spawnedObj.GetComponent<HealthComponent>();
          healthComp.Setup();
          AddSubscribers(healthComp, subscribers);
        }
      }
    }

    private Vector3 GetRandomSpawnPosition(Vector3Int mapSize) {
      float xBegin = -mapSize.x / 2f;
      float xEnd = mapSize.x / 2f;
      float yBegin = -mapSize.y / 2f;
      float yEnd = mapSize.y / 2f;
      float randomX = Random.Range(xBegin, xEnd);
      float randomY = Random.Range(yBegin, yEnd);
      return  new Vector3(randomX, randomY);
    }
    
    private void AddSubscribers(HealthComponent healthComponent, IHealthEventSubscriber[] subscribers) {
      foreach (var subscriber in subscribers) {
        healthComponent.AddSubscriber(subscriber);
      }
    }
  }
}