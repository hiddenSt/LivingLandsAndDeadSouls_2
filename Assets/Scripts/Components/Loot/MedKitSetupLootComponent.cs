using InventorySystem;
using Items;
using UI.Items;
using UnityEngine;

namespace Components.Loot {
  public class MedKitSetupLootComponent : MonoBehaviour {
    public float healthBoostPoints;
    public string medKitType;
    private LootComponent _lootComponent;
    private IItemUi _itemUi;

    private void Awake() {
      _lootComponent = gameObject.AddComponent<LootComponent>();
    }

    private void Start() {
      _itemUi = gameObject.GetComponent<ItemUiWithSingleButton>();
      _lootComponent.item = new MedKit(medKitType, healthBoostPoints);
      _lootComponent.item.SetItemUi(_itemUi);
    }
  }

}
