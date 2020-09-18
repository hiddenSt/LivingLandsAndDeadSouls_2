using Components;
using UnityEngine;


namespace Items {

  public class MachineGunComponent : MonoBehaviour {
    public string gunType;
    public int fireRate;
    public int damage;
    public Sprite image;
    public int ammoCount;
    public int ammoLimit;

    private void Awake() {
      _lootComponent = gameObject.AddComponent<LootComponent>();
    }

    private void Start() {
      _lootComponent.itemImage = image;
      _lootComponent.item = new Gun(gunType, fireRate, damage, ammoCount, ammoLimit, image);
    }

    private LootComponent _lootComponent;
  }
}
