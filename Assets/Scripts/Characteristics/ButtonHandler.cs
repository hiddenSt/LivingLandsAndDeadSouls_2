using HealthFight;
using UnityEngine;

namespace Characteristics
{
  public class ButtonHandler : MonoBehaviour
  {
    public void UpStrength()
    {
      characteristics = GameObject.Find("Characteristics");
      if (characteristics.GetComponent<AllParameters>().freePoints <= 0) return;
      GameObject.Find("FireButton").GetComponent<Gun>().damageBuff += 10;
      characteristics.GetComponent<AllParameters>().freePoints -= 1;
      characteristics.GetComponent<AllParameters>().strength += 1;
      characteristics.GetComponent<AllParameters>().Display();
    }

    public void UpHealth()
    {
      characteristics = GameObject.Find("Characteristics");
      if (characteristics.GetComponent<AllParameters>().freePoints <= 0) return;
      GameObject.Find("Player").GetComponent<HealthComponent>().maxHealth += 10;
      characteristics.GetComponent<AllParameters>().freePoints -= 1;
      characteristics.GetComponent<AllParameters>().health += 1;
      characteristics.GetComponent<AllParameters>().Display();
    }

    public void UpSniper()
    {
      characteristics = GameObject.Find("Characteristics");
      if (characteristics.GetComponent<AllParameters>().freePoints <= 0) return;
      characteristics.GetComponent<AllParameters>().freePoints -= 1 ;
      characteristics.GetComponent<AllParameters>().sniper += 1 ;
      characteristics.GetComponent<AllParameters>().Display();
    }

    public GameObject characteristics;
  }
}
