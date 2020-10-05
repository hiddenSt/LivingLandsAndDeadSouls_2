using Components.Player;
using DataTransferObjects;
using UnityEngine;

namespace Components {

  public class GameSetuper : MonoBehaviour {
    public OutfitComponent playerOutfitComponent;
    public GunComponent playerGunComponent;
    public Animator playerAnimator;
    public GameObject player;
    public InventoryComponent playerInventory;
    private ParameterManager _parameterManager;

    private void Awake() {
      _parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      SetDependencies();
      SetUpPlayer();
    }

    private void SetUpPlayer() {
      var playerPosition = _parameterManager.playerPosition;
      player.transform.position = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
      playerOutfitComponent.SetCharacterDefaultOutfit(_parameterManager.defaultAnimatorController);

      if (_parameterManager.suitedGun != null) {
        _parameterManager.suitedGun.SetGunComponent(playerGunComponent);
        _parameterManager.suitedGun.Use();
      }

      if (_parameterManager.suitedOutfit != null) {
        _parameterManager.suitedOutfit.SetOutfitComponent(playerOutfitComponent);
        _parameterManager.suitedOutfit.Use();
      }

      var inventory = playerInventory.GetInventory();
      if (_parameterManager.inventoryItems == null) {
        return;
      }
      for (int i = 0; i < _parameterManager.inventoryItems.Length; ++i) {
        inventory.AddItem(_parameterManager.inventoryItems[i]);
      }

    }
    
    private void SetDependencies() {
      Debug.Log("Animator: " + playerAnimator);
      playerGunComponent.SetOutfitComponent(playerOutfitComponent);
      playerOutfitComponent.SetAnimator(playerAnimator);
    }
  }

}
