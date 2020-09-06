using UnityEngine;
using UnityEngine.Serialization;

namespace HealthFight {
  public class DamageComponent : MonoBehaviour {
    private void Start() {
      damageCollider = this.gameObject.AddComponent<CircleCollider2D>();
      damageCollider.isTrigger = true;
      damageCollider.radius = damageRadius;
      
      _damage = new Damage(damagePoints);
    }

    [FormerlySerializedAs("damage")] public int damagePoints;
    public float damageRadius;
    public int originId;
    public CircleCollider2D damageCollider;
    private Damage _damage;
  }
}