using UnityEngine;
using UnityEngine.Serialization;

namespace HealthFight {
  public class DamageComponent : MonoBehaviour {
    private void Start() {
      damageCollider = gameObject.AddComponent<CircleCollider2D>();
      damageCollider.isTrigger = true;
      damageCollider.radius = damageRadius;

      _damage = new Damage(damagePoints);
    }

    public Damage GetDamage() {
      return _damage;
    }

    [FormerlySerializedAs("damage")] public float damagePoints;
    public float damageRadius;
    public int originId;
    public CircleCollider2D damageCollider;
    private Damage _damage;
  }
}