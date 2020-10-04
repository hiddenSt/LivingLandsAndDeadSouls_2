using UnityEngine;

namespace InventorySystem {

  public interface IItemUi {
     GameObject SetItemButton(Transform position);
     GameObject SetItemImage(Transform position);
     Sprite GetItemImage();

  }

}
