using InventorySystem;
using UnityEngine;

namespace UI.Items {

  public class NewBehaviourScript : MonoBehaviour, IItemUi {
    public GameObject itemButton;
    private GameObject _instantiatedItemButton;
    
    public GameObject SetItemButton(Transform position) {
      _instantiatedItemButton = Instantiate(itemButton, position);
      return _instantiatedItemButton;
    }

    public GameObject SetItemImage(Transform position) {
      return _instantiatedItemButton;
    }

    public Sprite GetItemImage() {
      return itemButton.GetComponent<Sprite>();
    }
  }

}
