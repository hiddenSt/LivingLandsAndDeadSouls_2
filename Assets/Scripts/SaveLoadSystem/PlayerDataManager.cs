using System.Collections;
using System.Collections.Generic;
using SaveLoadSystem;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using InventorySystem;
using System.IO;


namespace SaveLoadSystem
{
   public class PlayerDataManager : DataManager
   {
       public PlayerDataManager()
       {
           _loader = null;
       }
       
      public override void Save()
      {
          var bag = GameObject.Find("BackpackButton").GetComponent<Bag>();
          if (bag.IsClosed())
              bag.OpenCloseBag();
          var player = GameObject.Find("Player");
         var formatter = new BinaryFormatter();
         var path = Application.persistentDataPath + "/player.data";
         var gunSlot = GameObject.Find("GunSlot");
         var gunSlotComponent = gunSlot.GetComponent<GunSlot>();
         int gun = 0;
         if (gunSlot.transform.childCount > 0)
         {
             var damage = gunSlot.GetComponent<GunSlot>().GetDamage();
             gun = damage == 5 ? 1 : 2;
         }

         var playerHealthComponent = GameObject.Find("Player").GetComponent<HealthFight.HealthComponent>();
         var outfitSlot = GameObject.Find("SuitSlot");
         var data = new PlayerData(player.transform.position,
            player.GetComponent<InventorySystem.Inventory>(), gun, 
            outfitSlot.GetComponent<OutfitSlot>().skinIndex,
            gunSlot.GetComponent<GunSlot>().character,
            playerHealthComponent.health, gunSlotComponent.GetAmmoCount(), playerHealthComponent.maxHealth);
         var stream = new FileStream(path, FileMode.Create);
         formatter.Serialize(stream, data);
         stream.Close();
      }

      public override void Load()
      {
         var path = Application.persistentDataPath + "/player.data";
         if (!File.Exists(path)) return;
         _loader = new GameObject();
         var loaderComponent = _loader.AddComponent<Loader>();
         var formatter = new BinaryFormatter();
         var stream = new FileStream(path, FileMode.Open);
         var data = formatter.Deserialize(stream) as PlayerData;
         stream.Close();
         
         var player = GameObject.Find("Player");
          player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
          var cameraObj = GameObject.Find("Main Camera");
          cameraObj.transform.position = new Vector3(data.position[0], data.position[1], -10f);
          player.GetComponent<HealthFight.HealthComponent>().maxHealth = data.maxHealth;
          player.GetComponent<HealthFight.HealthComponent>().SetHealth(data.health);
          var playerInventory = player.GetComponent<InventorySystem.Inventory>();
          GameObject loadedObj;
          loaderComponent.LoadButtons();
          for (int i = 0; i < playerInventory.slots.Length; ++i)
          {
              switch (data.inventory[i])
              {
                  case 0:
                      continue;
                  case 1:
                      loaderComponent.LoadObjectOnScene(loaderComponent.medkitButton, playerInventory.slots[i].transform);
                      playerInventory.items[i] = 1;
                      break;
                  case 2:
                      loaderComponent.LoadObjectOnScene(loaderComponent.meatButton, playerInventory.slots[i].transform);
                      playerInventory.items[i] = 1;
                      break;
                  case 3:
                      loadedObj = loaderComponent.LoadObjectOnScene(loaderComponent.gun1Button, playerInventory.buttonSlots[i].transform);
                      var immgObj0 = loaderComponent.LoadObjectOnScene(loaderComponent.gun1Image,
                          playerInventory.slots[i].transform);
                      playerInventory.items[i] = 1;
                      var gunSelectComp = loadedObj.GetComponent<InventorySystem.GunSelect>();
                      gunSelectComp.ammoCount = data.gunsAmmoCount[i];
                      gunSelectComp.imageObj = immgObj0;
                      gunSelectComp.slotIndex = i;
                      break;
                  case 4:
                      loadedObj = loaderComponent.LoadObjectOnScene(loaderComponent.gun2Button, playerInventory.buttonSlots[i].transform);
                      var immgObj = loaderComponent.LoadObjectOnScene(loaderComponent.gun2Image,
                          playerInventory.slots[i].transform);
                      playerInventory.items[i] = 1;
                      var gunSelectComp2 = loadedObj.GetComponent<InventorySystem.GunSelect>();
                      gunSelectComp2.ammoCount = data.gunsAmmoCount[i];
                      gunSelectComp2.imageObj = immgObj;
                      gunSelectComp2.slotIndex = i;
                      break;
                  case 5:
                      loaderComponent.LoadObjectOnScene(loaderComponent.ammoButton, playerInventory.slots[i].transform);
                      playerInventory.items[i] = 1;
                      break;
                  case 6:
                      loadedObj = loaderComponent.LoadObjectOnScene(loaderComponent.outfit1Button, playerInventory.buttonSlots[i].transform);
                      var immgObj1 = loaderComponent.LoadObjectOnScene(loaderComponent.outfit1Image,
                          playerInventory.slots[i].transform);
                      loadedObj.GetComponent<OutfitSelect>().imageObj = immgObj1;
                      playerInventory.items[i] = 1;
                      var outfitSelectComp = loadedObj.GetComponent<InventorySystem.OutfitSelect>();
                      outfitSelectComp.slotIndex = i;
                      break;
                  case 7:
                      loadedObj = loaderComponent.LoadObjectOnScene(loaderComponent.outfit2Button, playerInventory.buttonSlots[i].transform);
                      var immgObj2 = loaderComponent.LoadObjectOnScene(loaderComponent.outfit2Image,
                          playerInventory.slots[i].transform);
                      loadedObj.GetComponent<OutfitSelect>().imageObj = immgObj2;
                      playerInventory.items[i] = 1;
                      var outfitSelectComp2 = loadedObj.GetComponent<InventorySystem.OutfitSelect>();
                      outfitSelectComp2.slotIndex = i;
                      break;
              }
          }

          var gunSlot = GameObject.Find("GunSlot");
          var outfitSlot = GameObject.Find("SuitSlot");
          gunSlot.GetComponent<GunSlot>().character = data.currentCharacter;
          gunSlot.GetComponent<GunSlot>().ChangeCharacter();
          outfitSlot.GetComponent<OutfitSlot>().skinIndex = data.currentSkinIndex;
          outfitSlot.GetComponent<OutfitSlot>().ChangeSkin();
          
          switch (data.currentSkinIndex)
          {
              case 0:
                  break;
              case 1:
                  outfitSlot.GetComponent<OutfitSlot>().SetOutfit(loaderComponent.outfit1Button);
                  break;
              case 2:
                  outfitSlot.GetComponent<OutfitSlot>().SetOutfit(loaderComponent.outfit2Button);
                  break;
          }
          
          switch (data.currentGun)
          {
              case 0:
                  break;
              case 1:
                  loaderComponent.gun1Button.GetComponent<GunSelect>().ammoCount = data.ammoCount;
                  gunSlot.GetComponent<GunSlot>().SetGun(loaderComponent.gun1Button);
                  break;
              case 2:
                  loaderComponent.gun2Button.GetComponent<GunSelect>().ammoCount = data.ammoCount;
                  gunSlot.GetComponent<GunSlot>().SetGun(loaderComponent.gun2Button);
                  break;
          }
      }

      public override void DeleteSaves()
      {
          var path = Application.persistentDataPath + "/player.data";
          if (!File.Exists(path)) return;
          File.Delete(path);
      }

      //data members
      private GameObject _loader;
   }
}//end of namespace SaveLoadSystem
