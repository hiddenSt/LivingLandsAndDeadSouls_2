using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Components.Player;
using HealthFight;
using SaveLoadSystem.DTO;
using SaveLoadSystem.Serializers;
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
      playerData.inventory = GetPlayerInventory();
      playerData.suitedGun = GetSuitedGun();
      playerData.suitedOutfit = GetSuitedOutfit();
      
      var binaryFormatter = new BinaryFormatter();
      var path = Application.persistentDataPath + _fileName;
      var fileStream = new FileStream(path, FileMode.Create);
      binaryFormatter.Serialize(fileStream, playerData);
      fileStream.Close();
      Debug.Log("Hello i am saver");
    }

    private ObjectPosition GetPlayerPosition() {
      var playerPosition = new ObjectPosition();
      Debug.Log("Player" + _player);
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
      var inventoryData = new InventoryData();
      var inventory = _player.GetComponent<InventoryComponent>().GetInventory();
      inventoryData.capacity = inventory.GetInventoryCapacity();
      inventoryData.size = inventory.GetInventorySize();

      var iterator = inventory.GetIterator();
      //for (iterator.First(); !iterator.IsDone(); iterator.Next()) { }

      return inventoryData;
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
      Debug.Log("PlayerIsSaved");
      
      var outfitSerializer = new OutfitSerializer();
      return outfitSerializer.Serialize(outfit);
    }

    private string _fileName;
    private GameObject _player;
  }

}
