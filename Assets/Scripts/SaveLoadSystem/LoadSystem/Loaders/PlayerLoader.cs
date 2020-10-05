using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataTransferObjects;
using SaveLoadSystem.DTO;
using SaveLoadSystem.Serializers;
using UI.Items;
using UnityEngine;

namespace SaveLoadSystem.LoadSystem.Loaders {

  public class PlayerLoader : ILoader {
    public PlayerLoader(string fileName) {
      _fileName = fileName;
    }
    
    public void Load() {
      
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      var binaryFormatter = new BinaryFormatter();
      var fileStream = new FileStream(path, FileMode.Open);
      _playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;
      fileStream.Close();
      LoadSuitedGun();
      LoadPlayerPosition();
      LoadPlayerHealth();
    }

    private void LoadSuitedGun() {
      if (_playerData.suitedGun == null) {
        return;
      }
      var gunSerializer = new GunSerializer();
      
      ParameterManager.instance.suitedGun = gunSerializer.Deserialize(_playerData.suitedGun);
    }

    private void LoadSuitedOutfit() {
      
    }

    private void LoadPlayerHealth() {
      ParameterManager.instance.health = _playerData.healthPoints;
      ParameterManager.instance.healthLimit = _playerData.healthPointsLimit;
    }

    private void LoadPlayerPosition() {
      ParameterManager.instance.playerPosition = _playerData.position;
    }

    private void LoadInventory() {
      
    }

    public void DeleteSaves() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      File.Delete(path);
    }

    private string _fileName;
    private LootUiData _lootUiData;
    private PlayerData _playerData;
  }

}