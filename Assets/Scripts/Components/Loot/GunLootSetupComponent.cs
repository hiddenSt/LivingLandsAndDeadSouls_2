using Items;
using UI.Items;
using UnityEngine;

namespace Components.Loot {

  public class GunLootSetupComponent : MonoBehaviour {
    public string gunType;
    public int fireRate;
    public int damagePoints;
    public int ammoCount;
    public int ammoLimit;
    
    private LootComponent _lootComponent;
    private ItemUiWithSeparatedButton _itemUi;
    
    private void Awake() {
      _lootComponent = gameObject.AddComponent<LootComponent>();
      _itemUi = gameObject.GetComponent<ItemUiWithSeparatedButton>();
    }

    private void Start() {
      _lootComponent.item = new Gun(gunType, fireRate, damagePoints, ammoCount, ammoLimit);
      _lootComponent.item.SetItemUi(_itemUi);
    }
  }

}
