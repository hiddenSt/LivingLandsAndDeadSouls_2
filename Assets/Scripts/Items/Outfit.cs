using System.Collections.Generic;
using UnityEngine;

namespace Items {
  
  public class Outfit : InventorySystem.Item {
    public Outfit(string outfitType, SortedDictionary<string, AnimatorOverrideController> animatorOverrideController) {
      _type = "Outfit";
      _outfitType = outfitType;
      _animatorOverrideController = animatorOverrideController;
    }

    public override void Use() {
      _outfitComponent.SetOutfit(this);
    }

    public override void Drop() {
      _outfitComponent = null;
      _playerAnimator = null;
    }

    public override void PickUp() {
      _outfitComponent = GameObject.Find("Player").GetComponent<Player.OutfitComponent>();
      _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public SortedDictionary<string, AnimatorOverrideController> GetSkinsAnimator() {
      return _animatorOverrideController;
    }

    public string GetOutfitType() {
      return _outfitType;
    }

    private Player.OutfitComponent _outfitComponent;
    private Animator _playerAnimator;
    private SortedDictionary<string, AnimatorOverrideController> _animatorOverrideController;
    private string _outfitType;
  }
}