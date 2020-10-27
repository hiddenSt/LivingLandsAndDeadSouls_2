using System;
using Items;
using UI.Items;
using UnityEngine;

namespace Components.Loot {

  public class AmmoLootSetupComponent : MonoBehaviour {
    public int ammoCount;
    private LootComponent _lootComponent;

    private void Awake() {
      _lootComponent = gameObject.AddComponent<LootComponent>();
    }

    private void Start() {
      _lootComponent.item = new Ammo(ammoCount);
      var itemUi = gameObject.GetComponent<ItemUiWithSingleButton>();
      _lootComponent.item.SetItemUi(itemUi);
    }
  }

}
