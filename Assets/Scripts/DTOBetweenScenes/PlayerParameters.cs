using System.Collections.Generic;
using UnityEngine;

namespace DTOBetweenScenes {

  public class PlayerParameters : MonoBehaviour {
    public string[] gunTypes;
    public AnimatorOverrideController[] animatorOverrideControllers;
    
    public SortedDictionary<string, AnimatorOverrideController> characterDefaultAnimator;

    private void Start() {
      characterDefaultAnimator = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        characterDefaultAnimator.Add(gunTypes[i], animatorOverrideControllers[i]);
      }
    }
  }

}
