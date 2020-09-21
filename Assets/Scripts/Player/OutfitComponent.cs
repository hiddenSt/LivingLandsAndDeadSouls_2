using System.Collections.Generic;
using Components;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player {
  
  public class OutfitComponent : MonoBehaviour {
    public IOutfitSlotUi outfitSlotUi;
    private InventoryComponent _playerInventoryComponent;
    private Animator _animator;
    private Dictionary<string, AnimatorOverrideController> _skinsAnimator;
    private string _gunType;
    private bool _isSuited;

    public void SetOutfit(Dictionary<string, AnimatorOverrideController> skinsAnimator, Image outfitImage) {
      _skinsAnimator = skinsAnimator;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
      outfitSlotUi.SetOutfitImageAndActivateListener(outfitImage);
    }

    public void ChangeGunSkin(string gunType) {
      _gunType = gunType;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
    }
    
    private void Start() {
      _animator = gameObject.GetComponent<Animator>();
      outfitSlotUi.SetOutfitComponent(this);
      _isSuited = false;
    }
  }
}