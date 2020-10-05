using Components.Player;
using DataTransferObjects;
using UnityEngine;

namespace Components {

  public class GameSetuper : MonoBehaviour {
    public OutfitComponent playerOutfitComponent;
    public GunComponent playerGunComponent;
    private ParameterManager _parameterManager;

    private void Awake() {
      _parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      SetUpPlayer();
    }

    private void SetUpPlayer() {
      playerOutfitComponent.SetCharacterDefaultOutfit(_parameterManager.defaultAnimatorController);
    }
  }

}
