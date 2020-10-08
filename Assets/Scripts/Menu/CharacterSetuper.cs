using System.Collections.Generic;
using DataTransferObjects;
using UnityEngine;

namespace Menu {

  public class CharacterSetuper : MonoBehaviour {
    public string[] gunTypes;
    public AnimatorOverrideController[] animatorOverrideControllersClark;
    public AnimatorOverrideController[] animatorOverrideControllersHuLie;
    public AnimatorOverrideController[] animatorOverrideControllersTsal;

    public void SetupCharacter(string characterName) {
      switch (characterName) {
        case "Dick Clark":
          SetUpDickClark();
          break;
        case "Hu Lee":
          SetUpHeLee();
          break;
        case "Vitali Tsal":
          SetUpVitaliTsal();
          break;
      }
    }

    private void SetUpDickClark() {
      ParameterManager.instance.characterName = "Dick Clark";
      ParameterManager.instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersClark[i]);
      }
    }

    private void SetUpHeLee() {
      ParameterManager.instance.characterName = "Hu Lee";
      ParameterManager.instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersHuLie[i]);
      }
    }

    private void SetUpVitaliTsal() {
      ParameterManager.instance.characterName = "Vitali Tsal";
      ParameterManager.instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersTsal[i]);
      }
    }
  }

}
