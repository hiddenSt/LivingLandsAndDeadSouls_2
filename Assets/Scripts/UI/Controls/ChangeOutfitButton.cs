using UnityEngine;

namespace InventorySystem {
  public class ChangeOutfitButton : MonoBehaviour {
    private void Start() {
      _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public void ChangeOutfit() {
      _playerAnimator.runtimeAnimatorController = outfitAnimator as RuntimeAnimatorController;
    }

    //data members
    public AnimatorOverrideController outfitAnimator;

    private Animator _playerAnimator;
  }
}
