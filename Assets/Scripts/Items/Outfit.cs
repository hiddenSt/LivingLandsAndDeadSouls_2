using System.Collections.Generic;
using Components.Player;
using UnityEngine;

namespace Items {
  
  public class Outfit : InventorySystem.Item {
    public Outfit(string outfitType, SortedDictionary<string, AnimatorOverrideController> animatorOverrideController) {
      _type = "Outfit";
      _outfitType = outfitType;
      _animatorOverrideController = animatorOverrideController;
    }

    public Outfit(string outfitType) {
      _type = "Outfit";
      _outfitType = outfitType;
    }

    public override void Use() {
      _outfitComponent.SetOutfit(this);
    }

    public override void Drop() {
    }

    public override void PickUp() {
      var player = GameObject.Find("Player");
      if (player == null) {
        return;
      }
      _outfitComponent = player.GetComponent<OutfitComponent>();
      _playerAnimator = player.GetComponent<Animator>();
    }

    public void SetAnimatorOverrider(SortedDictionary<string, AnimatorOverrideController> animatorOverrider) {
      _animatorOverrideController = animatorOverrider;
    }
    
    public void SetOutfitComponent(OutfitComponent outfitComponent) {
      _outfitComponent = outfitComponent;
    }

    public void SetAnimator(Animator animator) {
      _playerAnimator = animator;
    }

    public SortedDictionary<string, AnimatorOverrideController> GetSkinsAnimator() {
      return _animatorOverrideController;
    }

    public string GetOutfitType() {
      return _outfitType;
    }

    private OutfitComponent _outfitComponent;
    private Animator _playerAnimator;
    private SortedDictionary<string, AnimatorOverrideController> _animatorOverrideController;
    private string _outfitType;
  }
}