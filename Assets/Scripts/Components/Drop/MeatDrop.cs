using HealthFight;
using UnityEngine;

namespace Components.Drop {

  public class MeatDrop : MonoBehaviour, IHealthEventSubscriber {
    public GameObject meat;
    
    public void EntityIsDead(Vector3 position) {
      var chance = Random.Range(0, 2);
      if (chance == 1) {
        Instantiate(meat, position, Quaternion.identity);
      }
    }
  }

}
