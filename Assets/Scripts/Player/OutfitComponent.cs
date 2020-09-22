using System.Collections.Generic;
using DTOBetweenScenes;
using Components;
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

    public void SetOutfit(SortedDictionary<string, AnimatorOverrideController> skinsAnimator, Sprite outfitImage) {
      _skinsAnimator = skinsAnimator;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
      _outfitSlotUi.SetOutfitImageAndActivateListener(outfitImage);
    }

    public void ChangeGunSkin(string gunType) {
      _gunType = gunType;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
    }

    public void RemoveOutfitSkin() {
      _animator.runtimeAnimatorController = _characterDefaultAnimator[_gunType];
    }

    public void SetOutfitSlotUi(IOutfitSlotUi outfitSlotUi) {
      _outfitSlotUi = outfitSlotUi;
    }
    
    private void Start() {
      _characterDefaultAnimator = GameObject.Find("PlayerParameters")
        .GetComponent<PlayerParameters>().characterDefaultAnimator;
      _animator = gameObject.GetComponent<Animator>();
    }
  }
}