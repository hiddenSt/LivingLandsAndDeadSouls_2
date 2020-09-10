using HealthFight;
using UnityEngine;

namespace Characteristics {
  public class ButtonHandler : MonoBehaviour {
    public GameObject Characteristics;
    public void UpStrength() {
      Characteristics = GameObject.Find("Characteristics");
      if (Characteristics.GetComponent<AllParameters>().FreePoints <= 0) return;
      GameObject.Find("FireButton").GetComponent<Gun>().damageBuff += 10;
      Characteristics.GetComponent<AllParameters>().FreePoints -= 1;
      Characteristics.GetComponent<AllParameters>().Strength += 1;
      Characteristics.GetComponent<AllParameters>().Display();
    }

    public void UpHealth() {
      Characteristics = GameObject.Find("Characteristics");
      if (Characteristics.GetComponent<AllParameters>().FreePoints <= 0) return;
      GameObject.Find("Player").GetComponent<HealthComponent>().maxHealth += 10;
      Characteristics.GetComponent<AllParameters>().FreePoints -= 1;
      Characteristics.GetComponent<AllParameters>().Health += 1;
      Characteristics.GetComponent<AllParameters>().Display();
    }

    public void UpSniper() {
      Characteristics = GameObject.Find("Characteristics");
      if (Characteristics.GetComponent<AllParameters>().FreePoints <= 0) return;
      Characteristics.GetComponent<AllParameters>().FreePoints -= 1 ;
      Characteristics.GetComponent<AllParameters>().Skill += 1 ;
      Characteristics.GetComponent<AllParameters>().Display();
    }
  }
}
