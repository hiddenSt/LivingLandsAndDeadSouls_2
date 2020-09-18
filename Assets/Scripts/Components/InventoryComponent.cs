using InventorySystem.NewInventorySystem;
using InventorySystem.NewInventorySystem.ArrayRepository;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Components {
  public class InventoryComponent : MonoBehaviour {
    public int inventorySize;
    private IUiController _inventoryUi;

    private void Start() {
      _inventory = new Inventory(new ArrayRepository(inventorySize), inventorySize);
    }

    public void SetUiController(IUiController uiController) {
      _inventoryUi = uiController;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
      var loot = other.gameObject.GetComponent<LootComponent>();
      if (loot == null)
        return;
      bool itemIsAdded = AddItem(loot.item, loot.itemImage);
      if (itemIsAdded)
        Destroy(other.gameObject);
    }

    public bool AddItem(InventorySystem.NewInventorySystem.Item item, Sprite itemImage) {
      if (!CanAddItem())
        return false;
      _inventory.AddItem(item);
      Debug.Log("LOOT");
      _inventoryUi.SetItem(itemImage, item.GetIdentifier());
      return true;
    }

    public void DropItem(Identifier identifier, Sprite itemImage) {
      InventorySystem.NewInventorySystem.Item item = _inventory.GetItem(identifier);
      _inventory.RemoveItem(identifier);
      
      var droppedItem = new GameObject();
      var lootComponent = droppedItem.AddComponent<LootComponent>();
      var circleCollider2D = droppedItem.AddComponent<CircleCollider2D>();
      var spriteRenderer = droppedItem.AddComponent<SpriteRenderer>();
      
      lootComponent.item = item;
      lootComponent.itemImage = itemImage;
      spriteRenderer.sprite = itemImage;
      circleCollider2D.radius = 0.1f;
      droppedItem.transform.position = gameObject.transform.position + new Vector3(0, 3f);
      
      Instantiate(droppedItem);
    }

    public void RemoveItem(Identifier identifier) {
      _inventory.RemoveItem(identifier);
    }

    public InventorySystem.NewInventorySystem.Item GetItem(Identifier identifier) {
      return _inventory.GetItem(identifier);
    }
    
    private bool CanAddItem() {
      return _inventory.GetInventorySize() <= _inventory.GetInventoryCapacity();
    }

    private InventorySystem.NewInventorySystem.Inventory _inventory;
    private Image[] _itemsImages;
  }
}
