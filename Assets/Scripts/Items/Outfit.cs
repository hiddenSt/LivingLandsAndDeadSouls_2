using System.Collections.Generic;
using UnityEngine;

namespace Items {

  public class Outfit : InventorySystem.NewInventorySystem.Item {
    public Outfit() {
      _type = "Outfit";
    }

    public override void Use() {
      _outfitComponent.SetOutfitAnimator(_animatorOverrideController);
    }

    public override void Drop() {
      _outfitComponent = null;
      _playerAnimator = null;
    }

    public override void PickUp() {
      _outfitComponent = GameObject.Find("SuitSlot").GetComponent<Player.OutfitComponent>();
      _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    private Player.OutfitComponent _outfitComponent;
    private Animator _playerAnimator;
    private Dictionary<string, AnimatorOverrideController> _animatorOverrideController;
  }
}
