using System.Collections.Generic;
using InventorySystem;
using Items;
using SaveLoadSystem.DTO;

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
      for (int i = 0; i < inventoryData.gunsSize; ++i) {
        var gun = _gunSerializer.Deserialize(inventoryData.guns[i]);
        items.Add(gun);
      }

      for (int i = 0; i < inventoryData.medKitsSize; ++i) {
        var medKit = _medKitSerializer.Deserialize(inventoryData.medKits[i]);
        items.Add(medKit);
      }

      for (int i = 0; i < inventoryData.ammoSize; ++i) {
        var ammo = _ammoSerializer.Deserialize(inventoryData.ammoData[i]);
        items.Add(ammo);
      }

      for (int i = 0; i < inventoryData.outfitsSize; ++i) {
        var outfit = _outfitSerializer.Deserialize(inventoryData.outfits[i]);
        items.Add(outfit);
      }

      return items;
    }

    private void SerializeItems(InventoryData inventoryData, Inventory inventory) {
      var iterator = inventory.GetIterator();
      Item item;

      inventoryData.gunsSize = CalculateItemTypeCount(iterator, "Gun");
      inventoryData.outfitsSize = CalculateItemTypeCount(iterator, "Outfit");
      inventoryData.medKitsSize = CalculateItemTypeCount(iterator, "MedKit");
      inventoryData.ammoSize = CalculateItemTypeCount(iterator, "Ammo");
      inventoryData.SetUp();
      
      int gunIndex = 0;
      int outfitIndex = 0;
      int medKitIndex = 0;
      int ammoIndex = 0;
      
      for (iterator.First(); !iterator.IsDone(); iterator.Next()) {
        item = iterator.CurrentItem();
        switch (item.GetItemType()) {
          case "Gun":
            var gun = item as Gun;
            inventoryData.guns[gunIndex] = _gunSerializer.Serialize(gun);
            ++gunIndex;
            break;
          case "Outfit":
            var outfit = item as Outfit;
            inventoryData.outfits[outfitIndex] = _outfitSerializer.Serialize(outfit);
            ++outfitIndex;
            break;
          case "MedKit":
            var medKit = item as MedKit;
            inventoryData.medKits[medKitIndex] = _medKitSerializer.Serialize(medKit);
            ++medKitIndex;
            break;
          case "Ammo":
            var ammo = item as Ammo;
            inventoryData.ammoData[ammoIndex] = _ammoSerializer.Serialize(ammo);
            ++ammoIndex;
            break;
        }
      }
    }
    
    private int CalculateItemTypeCount(IItemIterator iterator, string itemType) {
      int count = 0;
      for (iterator.First(); !iterator.IsDone(); iterator.Next()) {
        if (iterator.CurrentItem().GetItemType() == itemType) {
          ++count;
        }
      }

      return count;
    }
  }

}
