using Components.Player;
using DataTransferObjects;
using HealthFight;
using InventorySystem;
using Items;
using Menu;
using SaveLoadSystem.DTO;
using SpawnSystem;
using UI;
using UI.Controls;
using UnityEngine;

namespace Components {

  public class GameSetuper : MonoBehaviour {
    public HealthComponent playerHealthComponent;
    public OutfitComponent playerOutfitComponent;
    public GunComponent playerGunComponent;
    public GameObject player;
    public GunSlotControl gunSlotControl;
    public InventoryComponent playerInventory;
    public OutfitSlotControl outfitSlotControl;
    public CharacteristicsComponent playerCharacteristicsComponent;
    public InventoryUi inventoryUi;
    public CharacteristicsUi characteristicsUi;
    public LootUiData lootUiData;
    public OutfitsAnimators outfitsAnimators;
    public Spawner spawner;
    public EndGameController endGameController;

    private void Start() {
      SetDependencies();
      SetUpPlayer();
      SpawnBots();
    }
    
    private void SetDependencies() {
      playerHealthComponent.SetUp();
      playerOutfitComponent.SetUp();
      playerGunComponent.SetUp();
      playerCharacteristicsComponent.SetUp(playerHealthComponent.GetHealthEntity(), playerGunComponent, characteristicsUi);
      characteristicsUi.SetUp(playerCharacteristicsComponent);
      inventoryUi.SetUp();
      playerInventory.SetUp();
      gunSlotControl.SetUp();
      outfitSlotControl.SetUp();
      spawner.SetUp();
    }

    private void SetUpPlayer() {
      SetupPlayerPosition();
      SetupPlayerHealth();
      SetupPlayerOutfit();
      SetupPlayerGun();
      SetupPlayerInventory();
      playerHealthComponent.AddSubscriber(endGameController);
    }

    private void SpawnBots() {
      IHealthEventSubscriber[] subscribers = new IHealthEventSubscriber[1];
      subscribers[0] = playerCharacteristicsComponent;
      spawner.SpawnEnemies(subscribers);
      spawner.SpawnAnimals(subscribers);
    }

    private void SetupPlayerPosition() {
      var playerPosition = ParameterManager.instance.playerPosition;
      player.transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
    }
    
    private void SetupPlayerHealth() {
      var playerHealth = player.GetComponent<HealthComponent>().GetHealthEntity();
      playerHealth.SetHealthPointsLimit(ParameterManager.instance.healthLimit);
      playerHealth.SetHealthPoints(ParameterManager.instance.health);
    }
    
    private void SetupPlayerGun() {
      if (ParameterManager.instance.suitedGun == null) {
        return;
      }
      
      var gun = ParameterManager.instance.suitedGun;
      var gunUi = lootUiData.GetGunUi(gun.GetGunType());
      gun.SetItemUi(gunUi);
      gun.SetGunComponent(playerGunComponent);
      gun.Use();
    }

    private void SetupPlayerOutfit() {
      playerOutfitComponent.SetCharacterDefaultOutfit(ParameterManager.instance.defaultAnimatorController);
      if (ParameterManager.instance.suitedOutfit == null) {
        return;
      }
      
      var outfit = ParameterManager.instance.suitedOutfit;
      outfit.SetAnimatorOverrider(outfitsAnimators.GetAnimators(outfit.GetOutfitType()));
      var outfitUi = lootUiData.GetOutfitUi(outfit.GetOutfitType());
      outfit.SetItemUi(outfitUi);
      outfit.SetOutfitComponent(playerOutfitComponent);
      outfit.Use();
    }

    private void SetupPlayerInventory() {
      var inventory = playerInventory.GetInventory();
      if (ParameterManager.instance.inventoryItems == null) {
        return;
      }

      var items = ParameterManager.instance.inventoryItems;
      for (int i = 0; i < items.Count; ++i) {
        if (items[i].GetItemType() == "Outfit") {
          var outfit = items[i] as Outfit;
          outfit.SetAnimatorOverrider(outfitsAnimators.GetAnimators(outfit.GetOutfitType()));
        }
        SetItemUi(items[i]);
        inventory.AddItem(items[i]);
      }
    }

    private void SetItemUi(Item item) {
      IItemUi itemUi = null;
      switch (item.GetItemType()) {
        case "Gun":
          var gun = item as Gun;
          itemUi = lootUiData.GetGunUi(gun.GetGunType());
          break;
        case "Outfit":
          var outfit = item as Outfit;
          itemUi = lootUiData.GetOutfitUi(outfit.GetOutfitType());
          break;
        case "MedKit":
          var medKit = item as MedKit;
          itemUi = lootUiData.GetMedKitUi(medKit.GetMedKitType());
          break;
        case "Ammo":
          var ammo = item as Ammo;
          itemUi = lootUiData.GetAmmoUi();
          break;
      }
      item.SetItemUi(itemUi);
    }
  }

}
