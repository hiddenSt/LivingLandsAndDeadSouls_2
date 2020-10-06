
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
        items.Add(_gunSerializer.Deserialize(t));
      }

      foreach (var t in inventoryData.medKits) {
        items.Add(_medKitSerializer.Deserialize(t));
      }

      foreach (var t in inventoryData.ammoData) {
        items.Add(_ammoSerializer.Deserialize(t));
      }

      return items;
    }

    private void SerializeItems(InventoryData inventoryData, Inventory inventory) {
      var iterator = inventory.GetIterator();
      Item item;
      for (iterator.First(); !iterator.IsDone(); iterator.Next()) {
        item = iterator.CurrentItem();
        Debug.Log("item: " + item.GetItemType());
        switch (item.GetItemType()) {
          case "Gun":
            inventoryData.guns.Add(_gunSerializer.Serialize(item as Gun));
            break;
          case "Outfit":
            inventoryData.outfits.Add(_outfitSerializer.Serialize(item as Outfit));
            break;
          case "MedKit":
            inventoryData.medKits.Add(_medKitSerializer.Serialize(item as MedKit));
            break;
          case "Ammo":
            inventoryData.ammoData.Add(_ammoSerializer.Serialize(item as Ammo));
            break;
        }
      }
    }
    

  }

}
