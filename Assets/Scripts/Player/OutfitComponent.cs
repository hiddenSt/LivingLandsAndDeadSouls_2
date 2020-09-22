using System.Collections.Generic;
using DTOBetweenScenes;
using Components;
using InventorySystem;
using Items;
using UI;
using UnityEngine;

namespace Player {
  
  public class OutfitComponent : MonoBehaviour {
    private IOutfitSlotUi _outfitSlotUi;
    private InventoryComponent _playerInventoryComponent;
    private Animator _animator;
    private SortedDictionary<string, AnimatorOverrideController> _skinsAnimator;
    private SortedDictionary<string, AnimatorOverrideController> _characterDefaultAnimator;
    private string _gunType;
    private Outfit _outfit;

    public void SetOutfit(Outfit outfit) {
      if (_outfit != null) {
        RemoveToInventoryOrDrop();
      }
      _outfit = outfit;
      ActivateUi();
    }

    public void ChangeGunSkin(string gunType) {
      _gunType = gunType;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
    }

    public void RemoveToInventoryOrDrop() {
      var itemIsAdded = _playerInventoryComponent.AddItem(_outfit);
      if (!itemIsAdded) {
        _playerInventoryComponent.DropItem(_outfit);
      }
      _outfit = null;
      RemoveOutfitSkin();
    }
    
    private void RemoveOutfitSkin() {
      _skinsAnimator = _characterDefaultAnimator;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
    }

    public void SetOutfitSlotUi(IOutfitSlotUi outfitSlotUi) {
      _outfitSlotUi = outfitSlotUi;
    }

    private void ActivateUi() {
      _skinsAnimator = _outfit.GetSkinsAnimator();
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
      _outfitSlotUi.SetOutfitImageAndActivateListener(_outfit.GeItemUi().GetItemImage());
    }
    
    private void Start() {
      _characterDefaultAnimator = GameObject.Find("PlayerParameters")
        .GetComponent<PlayerParameters>().characterDefaultAnimator;
      _animator = gameObject.GetComponent<Animator>();
      _skinsAnimator = _characterDefaultAnimator;
      _gunType = "WithoutGun";
      _playerInventoryComponent = gameObject.GetComponent<InventoryComponent>();
    }
  }
}