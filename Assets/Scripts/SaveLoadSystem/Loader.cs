using Menu;
using UnityEngine;

namespace SaveLoadSystem {
  public class Loader : MonoBehaviour {
    public void LoadButtons() {
      var parameterManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
      meatButton = parameterManager.meatButton;
      medkitButton = parameterManager.medkitButton;
      outfit1Button = parameterManager.outfit1Button;
      outfit2Button = parameterManager.outfit2Button;
      gun1Button = parameterManager.gun1Button;
      gun2Button = parameterManager.gun2Button;
      ammoButton = parameterManager.ammoButton;
      outfit1Image = parameterManager.outfit1Image;
      outfit2Image = parameterManager.outfit2Image;
      gun1Image = parameterManager.gun1Image;
      gun2Image = parameterManager.gun2Image;
    }

    public GameObject LoadObjectOnScene(GameObject objectToLoad, Transform parentTransform) {
      return Instantiate(objectToLoad, parentTransform, false);
    }

    //data members
    public GameObject medkitButton;
    public GameObject meatButton;
    public GameObject outfit1Button;
    public GameObject outfit2Button;
    public GameObject gun1Button;
    public GameObject gun2Button;
    public GameObject ammoButton;
    public GameObject outfit1Image;
    public GameObject outfit2Image;
    public GameObject gun1Image;
    public GameObject gun2Image;
  }
}
