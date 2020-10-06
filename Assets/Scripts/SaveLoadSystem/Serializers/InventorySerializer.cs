using System.Collections.Generic;
using InventorySystem;
using Items;
using SaveLoadSystem.DTO;
using UnityEngine;

namespace SaveLoadSystem.Serializers {

  public class InventorySerializer {
    private GunSerializer _gunSerializer;
    private OutfitSerializer _outfitSerializer;
    private MedKitSerializer _medKitSerializer;
    private AmmoSerializer _ammoSerializer;

    public InventorySerializer() {
      _gunSerializer = new GunSerializer();
      _outfitSerializer = new OutfitSerializer();
      _medKitSerializer = new MedKitSerializer();
      _ammoSerializer = new AmmoSerializer();
    }
    
    public InventoryData Serialize(Inventory inventory) {
      var inventoryData = new InventoryData();
      inventoryData.capacity = inventory.GetInventoryCapacity();
      inventoryData.size = inventory.GetInventorySize();
      SerializeItems(inventoryData, inventory);
      return inventoryData;
    }

    public List<Item> Deserialize(InventoryData inventoryData) {
      var items = new List<Item>();
      foreach (var t in inventoryData.guns) {
        var gun = _gunSerializer.Deserialize(t);
        items.Add(gun);
        Debug.Log("GunType: " + gun.GetGunType());
      }

      foreach (var t in inventoryData.medKits) {
        var medKit = _medKitSerializer.Deserialize(t);
        items.Add(medKit);
        Debug.Log("MedKitType: " + medKit.GetMedKitType());
      }

      foreach (var t in inventoryData.ammoData) {
        var ammo = _ammoSerializer.Deserialize(t);
        items.Add(ammo);
        Debug.Log("Ammo:" + ammo);
      }

      foreach (var t in inventoryData.outfits) {
        var outfit = _outfitSerializer.Deserialize(t);
        items.Add(outfit);
        Debug.Log("OutfitType: " + outfit.GetItemType());
      }

      return items;
    }

    private void SerializeItems(InventoryData inventoryData, Inventory inventory) {
      var iterator = inventory.GetIterator();
      Item item;
      
      for (iterator.First(); !iterator.IsDone(); iterator.Next()) {
        item = iterator.CurrentItem();
        switch (item.GetItemType()) {
          case "Gun":
            var gun = item as Gun;
            inventoryData.guns.Add(_gunSerializer.Serialize(gun));
            break;
          case "Outfit":
            var outfit = item as Outfit;
            inventoryData.outfits.Add(_outfitSerializer.Serialize(outfit));
            break;
          case "MedKit":
            var medKit = item as MedKit;
            inventoryData.medKits.Add(_medKitSerializer.Serialize(medKit));
            break;
          case "Ammo":
            var ammo = item as Ammo;
            inventoryData.ammoData.Add(_ammoSerializer.Serialize(ammo));
            break;
        }
      }
    }
  }

}
