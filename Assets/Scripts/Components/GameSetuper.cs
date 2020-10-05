using Components.Player;
using DataTransferObjects;
using HealthFight;
using UI.Controls;
using UnityEngine;

namespace Components {

  public class GameSetuper : MonoBehaviour {
    public OutfitComponent playerOutfitComponent;
    public GunComponent playerGunComponent;
    public Animator playerAnimator;
    public GameObject player;
    public GunSlotControl gunSlotControl;
    public InventoryComponent playerInventory;

    private void Start() {
      SetDependencies();
      SetUpPlayer();
    }

    private void SetUpPlayer() {
      var playerPosition = ParameterManager.instance.playerPosition;
      player.transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
      playerOutfitComponent.SetCharacterDefaultOutfit(ParameterManager.instance.defaultAnimatorController);
      var playerHealth = player.GetComponent<HealthComponent>().GetHealthEntity();
      playerHealth.SetHealthPointsLimit(ParameterManager.instance.healthLimit);
      playerHealth.SetHealthPoints(ParameterManager.instance.health);

      if (ParameterManager.instance.suitedGun != null) {
        ParameterManager.instance.suitedGun.SetGunComponent(playerGunComponent);
        ParameterManager.instance.suitedGun.Use();
      }

      if (ParameterManager.instance.suitedOutfit != null) {
        ParameterManager.instance.suitedOutfit.SetOutfitComponent(playerOutfitComponent);
        ParameterManager.instance.suitedOutfit.Use();
      }

      var inventory = playerInventory.GetInventory();
      if (ParameterManager.instance.inventoryItems == null) {
        return;
      }
      for (int i = 0; i < ParameterManager.instance.inventoryItems.Length; ++i) {
        inventory.AddItem(ParameterManager.instance.inventoryItems[i]);
      }

    }
    
    private void SetDependencies() {
      playerGunComponent.SetOutfitComponent(playerOutfitComponent);
      playerOutfitComponent.SetAnimator(playerAnimator);
      playerGunComponent.SetGuSlotUi(gunSlotControl);
    }
  }

}
