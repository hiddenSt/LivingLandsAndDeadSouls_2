using UnityEngine;

namespace SpawnSystem {

  public class LootSpawner : MonoBehaviour {
    public GameObject[] items;
    private int _lootSize;

    public void Spawn(int lootSize, Vector3Int mapSize) {
      _lootSize = lootSize;
      for (int i = 0; i < items.Length; ++i) {
        for (int j = 0; j < _lootSize / items.Length; ++j) {
          Instantiate(items[i], GetRandomSpawnPosition(mapSize), Quaternion.identity);
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
  }

}
