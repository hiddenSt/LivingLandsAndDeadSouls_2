using Components.Player;
using DataTransferObjects;
using HealthFight;
using SaveLoadSystem.DTO;
using UI;
using UI.Controls;
using UnityEngine;

namespace Components {

  public class GameSetuper : MonoBehaviour {
    public OutfitComponent playerOutfitComponent;
    public GunComponent playerGunComponent;
    public GameObject player;
    public GunSlotControl gunSlotControl;
    public InventoryComponent playerInventory;
    public OutfitSlotControl outfitSlotControl;
    public InventoryUi inventoryUi;
    public LootUiData lootUiData;

    private void Start() {
      SetDependencies();
      SetUpPlayer();
    }
    
    private void SetDependencies() {
      playerOutfitComponent.SetUp();
      playerGunComponent.SetUp();
      inventoryUi.SetUp();
      playerInventory.SetUp();
      gunSlotControl.SetUp();
      outfitSlotControl.SetUp();
    }

    private void SetUpPlayer() {
      SetupPlayerPosition();
      SetupPlayerHealth();
      SetupPlayerOutfit();
      SetupPlayerGun();
      SetupPlayerInventory();
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
      if (ParameterManager.instance.suitedGun != null) {
        var gun = ParameterManager.instance.suitedGun;
        var gunUi = lootUiData.GetGunUi(gun.GetGunType());
        gun.SetItemUi(gunUi);
        gun.SetGunComponent(playerGunComponent);
        gun.Use();
      }
    }

    private void SetupPlayerOutfit() {
      playerOutfitComponent.SetCharacterDefaultOutfit(ParameterManager.instance.defaultAnimatorController);
      if (ParameterManager.instance.suitedOutfit != null) {
        var outfit = ParameterManager.instance.suitedOutfit;
        var outfitUi = lootUiData.GetOutfitUi(outfit.GetOutfitType());
        outfit.SetItemUi(outfitUi);
        Debug.Log("SpriteInSetuper: " + outfit.GetItemUi().GetItemImage());
        outfit.SetOutfitComponent(playerOutfitComponent);
        outfit.Use();
      }
    }

    private void SetupPlayerInventory() {
      var inventory = playerInventory.GetInventory();
      if (ParameterManager.instance.inventoryItems == null) {
        return;
      }
      /*for (int i = 0; i < ParameterManager.instance.inventoryItems.Length; ++i) {
        inventory.AddItem(ParameterManager.instance.inventoryItems[i]);
      }*/
    }
    
    
  }

}
