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
      ParameterManager.Instance.characterName = "Dick Clark";
      ParameterManager.Instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.Instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersClark[i]);
      }
    }

    private void SetUpHeLee() {
      ParameterManager.Instance.characterName = "Hu Lee";
      ParameterManager.Instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.Instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersHuLie[i]);
      }
    }

    private void SetUpVitaliTsal() {
      ParameterManager.Instance.characterName = "Vitali Tsal";
      ParameterManager.Instance.defaultAnimatorController = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        ParameterManager.Instance.defaultAnimatorController.Add(gunTypes[i], animatorOverrideControllersTsal[i]);
      }
    }
  }

}
