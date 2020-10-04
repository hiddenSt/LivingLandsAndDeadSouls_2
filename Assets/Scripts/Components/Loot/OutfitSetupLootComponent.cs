using System.Collections.Generic;
using Items;
using UI.Items;
using UnityEngine;

namespace Components.Loot {

  public class OutfitSetupLootComponent : MonoBehaviour {
    public string outfitType;
    public string[] gunTypes;
    public AnimatorOverrideController[] animatorOverrideControllers;
    private SortedDictionary<string, AnimatorOverrideController> _animatorOverrideControllers;

    private LootComponent _lootComponent;
    private ItemUiWithSeparatedButton _itemUi;

    private void Awake() {
      _lootComponent = gameObject.AddComponent<LootComponent>();
    }

    private void Start() {
      _animatorOverrideControllers = new SortedDictionary<string, AnimatorOverrideController>();
      for (int i = 0; i < gunTypes.Length; ++i) {
        _animatorOverrideControllers.Add(gunTypes[i], animatorOverrideControllers[i]);
      }
      _itemUi = gameObject.GetComponent<ItemUiWithSeparatedButton>();
      _lootComponent.item = new Outfit(outfitType, _animatorOverrideControllers);
      _lootComponent.item.SetItemUi(_itemUi);
    }
  }

}
