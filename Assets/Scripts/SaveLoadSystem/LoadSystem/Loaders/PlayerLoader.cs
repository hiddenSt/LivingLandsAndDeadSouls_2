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
    }

    private void LoadSuitedGun() {
      var gunSerializer = new GunSerializer();
      ItemUiWithSeparatedButton gunUi = new ItemUiWithSeparatedButton();
      gunUi.itemImage = GameObject.Find("LootImages").GetComponent<ItemImages>().gunsImages[_playerData.suitedGun.gunType];
        ParameterManager.instance.suitedGun = gunSerializer.Deserialize(_playerData.suitedGun);
    }
    

    public void DeleteSaves() {
      var path = Application.persistentDataPath + _fileName;
      if (!File.Exists(path)) {
        return;
      }
      File.Delete(path);
    }

    private string _fileName;
    private PlayerData _playerData;
  }

}