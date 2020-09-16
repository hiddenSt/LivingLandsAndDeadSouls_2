using System.Collections.Generic;
using UnityEngine;

namespace Player {
  public class OutfitComponent : MonoBehaviour {
    private void Start() {
      _animator = this.gameObject.GetComponent<Animator>();
    }

    public void SetOutfitAnimator(Dictionary<string, AnimatorOverrideController> skinsAnimator) {
      _skinsAnimator = skinsAnimator;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
    }

    public void ChangeGunSkin(string gunType) {
      _gunType = gunType;
      _animator.runtimeAnimatorController = _skinsAnimator[_gunType];
    }
    
    private Animator _animator;
    private Dictionary<string, AnimatorOverrideController> _skinsAnimator;
    private string _gunType;
  }
  
}