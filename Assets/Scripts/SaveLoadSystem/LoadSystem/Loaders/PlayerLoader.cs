using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DataTransferObjects;
using Menu;
using SaveLoadSystem.DTO;
using SaveLoadSystem.Serializers;
using UnityEngine;

namespace SaveLoadSystem.LoadSystem.Loaders {

  public class PlayerLoader : ILoader {
    private string _fileName;
    private PlayerData _playerData;
    
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
      LoadCharacter();
      LoadSuitedOutfit();
      LoadPlayerPosition();
      LoadPlayerHealth();
      LoadInventory();
      LoadCharacteristics();
    }

    public void DeleteSaves() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      File.Delete(path);
    }
    
    private void LoadSuitedGun() {
      if (_playerData.suitedGun == null) {
        return;
      }
      var gunSerializer = new GunSerializer();
      var suitedGun = gunSerializer.Deserialize(_playerData.suitedGun);
      ParameterManager.Instance.suitedGun = suitedGun;
    }

    private void LoadCharacter() {
      ParameterManager.Instance.characterName = _playerData.characterName;
    }
    
    private void LoadSuitedOutfit() {
      if (_playerData.suitedOutfit == null) {
        return;
      }
      var outfitSerializer = new OutfitSerializer();
      
      var suitedOutfit = outfitSerializer.Deserialize(_playerData.suitedOutfit);
      ParameterManager.Instance.suitedOutfit = suitedOutfit;
    }

    private void LoadPlayerHealth() {
      ParameterManager.Instance.health = _playerData.healthPoints;
      ParameterManager.Instance.healthLimit = _playerData.healthPointsLimit;
    }

    private void LoadPlayerPosition() {
      ParameterManager.Instance.playerPosition = _playerData.position;
    }

    private void LoadInventory() {
      var inventorySerializer = new InventorySerializer();
      ParameterManager.Instance.inventoryItems = inventorySerializer.Deserialize(_playerData.inventory);
    }

    private void LoadCharacteristics() {
      ParameterManager.Instance.experience = _playerData.experience;
      ParameterManager.Instance.freePoints = _playerData.freePoints;
      ParameterManager.Instance.damageBuff = _playerData.damageBuff;
    }

    
  }

}