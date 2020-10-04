
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using HealthFight;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.SaveSystem.Savers {

  public class PlayerSaver : ISaver {
    public PlayerSaver(string fileName) {
      _fileName = fileName;
      _player = GameObject.Find("Player");
    }
    
    public void Save() {
      ObjectPosition playerPosition = GetPlayerPosition();
      Health playerHealth = GetHealthEntity();
      var playerData = new PlayerData();
      playerData.position = playerPosition;
      playerData.healthPoints = playerHealth.GetHealthPoints();
      playerData.healthPointsLimit = playerHealth.GetHealthPointsLimit();

      var binaryFormatter = new BinaryFormatter();
      var path = Application.persistentDataPath + _fileName;
      var fileStream = new FileStream(path, FileMode.Create);
      binaryFormatter.Serialize(fileStream, playerData);
      fileStream.Close();
    }
    
    private ObjectPosition GetPlayerPosition() {
      var playerPosition = new ObjectPosition();
      playerPosition.x = _player.transform.position.x;
      playerPosition.y = _player.transform.position.y;
      playerPosition.z = _player.transform.position.z;
      return playerPosition;
    }

    private Health GetHealthEntity() {
      var healthComponent = _player.GetComponent<HealthComponent>();
      return healthComponent.GetHealthEntity();
    }
    
    private string _fileName;
    private GameObject _player;
  }

}
