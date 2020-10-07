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
    }

    private void LoadSuitedGun() {
      if (_playerData.suitedGun == null) {
        return;
      }
      var gunSerializer = new GunSerializer();
      var suitedGun = gunSerializer.Deserialize(_playerData.suitedGun);
      ParameterManager.instance.suitedGun = suitedGun;
    }

    private void LoadCharacter() {
      ParameterManager.instance.characterName = _playerData.characterName;
      var characterSelect = GameObject.Find("CharacterSelection").GetComponent<CharacterSelect>();
      switch (ParameterManager.instance.characterName) {
        case "Dick Clark":
          characterSelect.DickClarkPressed();
          break;
        case "Hu Lee":
          characterSelect.HuLeePressed();
          break;
        case "Vitali Tsal":
          characterSelect.VitaliTsalPressed();
          break;
      }
    }
    
    private void LoadSuitedOutfit() {
      if (_playerData.suitedOutfit == null) {
        return;
      }
      var outfitSerializer = new OutfitSerializer();
      
      var suitedOutfit = outfitSerializer.Deserialize(_playerData.suitedOutfit);
      ParameterManager.instance.suitedOutfit = suitedOutfit;
    }

    private void LoadPlayerHealth() {
      ParameterManager.instance.health = _playerData.healthPoints;
      ParameterManager.instance.healthLimit = _playerData.healthPointsLimit;
    }

    private void LoadPlayerPosition() {
      ParameterManager.instance.playerPosition = _playerData.position;
    }

    private void LoadInventory() {
      var inventorySerializer = new InventorySerializer();
      ParameterManager.instance.inventoryItems = inventorySerializer.Deserialize(_playerData.inventory);
    }

    public void DeleteSaves() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      File.Delete(path);
    }
  }

}