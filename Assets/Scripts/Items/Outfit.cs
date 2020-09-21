using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items {
  
  public class Outfit : InventorySystem.Item {
    public Outfit(string outfitType, Image outfitImage) {
      _type = "Outfit";
      _outfitType = outfitType;
      _outfitImage = outfitImage;
    }

    public override void Use() {
      _outfitComponent.SetOutfit(_animatorOverrideController, _outfitImage);
    }

    public override void Drop() {
      _outfitComponent = null;
      _playerAnimator = null;
    }

    public override void PickUp() {
      _outfitComponent = GameObject.Find("Player").GetComponent<Player.OutfitComponent>();
      _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public Image GetOutfitImage() {
      return _outfitImage;
    }

    public string GetOutfitType() {
      return _outfitType;
    }

    private Player.OutfitComponent _outfitComponent;
    private Animator _playerAnimator;
    private Dictionary<string, AnimatorOverrideController> _animatorOverrideController;
    private Image _outfitImage;
    private string _outfitType;
  }
}