
using UnityEngine;

namespace HealthFight {

  public interface IHealthEventSubscriber {
    void EntityIsDead(Vector3 position);
  }

}

