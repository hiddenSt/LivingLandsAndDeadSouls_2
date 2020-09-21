using UnityEngine;

namespace InventorySystem.NewInventorySystem {

  public interface IItemUi {
     GameObject SetItemButton(Transform position);
     GameObject SetItemImage(Transform position);
     Sprite GetItemImage();
  }

}
