using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem.DTO {

  public class OutfitsAnimators : MonoBehaviour {
    public string[] outfitsTypes;
    public AnimatorOverrideController[] outfitsWithoutGun;
    public AnimatorOverrideController[] outfitsWithGun1;
    public AnimatorOverrideController[] outfitsWithGun2;

    public SortedDictionary<string, AnimatorOverrideController> GetAnimators(string outfitType) {
      var animators = new SortedDictionary<string, AnimatorOverrideController>();
      int index = 0;
      for (int i = 0; i < outfitsTypes.Length; ++i) {
        if (outfitType == outfitsTypes[i]) {
          index = i;
        }
      }

      animators.Add("WithoutGun", outfitsWithoutGun[index]);
      animators.Add("Rifle", outfitsWithGun1[index]);
      animators.Add("MachineGun", outfitsWithGun2[index]);
      return animators;
    }

  }

}
