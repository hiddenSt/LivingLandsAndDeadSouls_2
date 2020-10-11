using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Components.Player;
using DataTransferObjects;
using HealthFight;
using SaveLoadSystem.DTO;
using SaveLoadSystem.Serializers;
using UnityEngine;

namespace SaveLoadSystem.SaveSystem.Savers {

  public class PlayerSaver : ISaver {
    private string _fileName;
    private GameObject _player;
    
    public PlayerSaver(string fileName) {
      _fileName = fileName;
    }

    public void Save() {
      _player = GameObject.Find("Player");
      ObjectPosition playerPosition = GetPlayerPosition();
      Health playerHealth = GetHealthEntity();
      var playerData = new PlayerData();

      
      
      playerData.position = playerPosition;
      playerData.healthPoints = playerHealth.GetHealthPoints();
      playerData.healthPointsLimit = playerHealth.GetHealthPointsLimit();
      playerData.inventory = GetPlayerInventory();
      playerData.suitedGun = GetSuitedGun();
      playerData.suitedOutfit = GetSuitedOutfit();
      playerData.characterName = ParameterManager.Instance.characterName;
      SetUpCharacteristics(playerData);
      var binaryFormatter = new BinaryFormatter();
      var path = Application.persistentDataPath + _fileName;
      var fileStream = new FileStream(path, FileMode.Create);
      binaryFormatter.Serialize(fileStream, playerData);
      fileStream.Close();
    }

    private void SetUpCharacteristics(PlayerData playerData) {
      var characteristicsComp = _player.GetComponent<CharacteristicsComponent>();
      playerData.experience = characteristicsComp.GetExperience();
      playerData.freePoints = characteristicsComp.GetFreePoints();
      playerData.damageBuff = characteristicsComp.GetDamageBuff();
      playerData.accuracy = characteristicsComp.GetAccuracy();
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

    private InventoryData GetPlayerInventory() {
      var inventory = _player.GetComponent<InventoryComponent>().GetInventory();
      var inventorySerializer = new InventorySerializer();
      return inventorySerializer.Serialize(inventory);
    }

    private GunData GetSuitedGun() {
      var gun = _player.GetComponent<GunComponent>().GetGun();
      if (gun == null) {
        return null;
      }
      var gunSerializer = new GunSerializer();
      return gunSerializer.Serialize(gun);
    }

    private OutfitData GetSuitedOutfit() {
      var outfit = _player.GetComponent<OutfitComponent>().GetOutfit();
      if (outfit == null) {
        return null;
      }

      var outfitSerializer = new OutfitSerializer();
      return outfitSerializer.Serialize(outfit);
    }
  }

}
