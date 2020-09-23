using InventorySystem;
using InventorySystem.ArrayRepository;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Components {
  
  public class InventoryComponent : MonoBehaviour {
    public int inventorySize;
    public float dropDistanceY = 0.3f;
    public IInventoryUi inventoryInventoryUi;
    private Inventory _inventory;
    private Image[] _itemsImages;

    private void OnTriggerEnter2D(Collider2D other) {
      var loot = other.gameObject.GetComponent<LootComponent>();
      if (loot == null)
        return;
      var itemIsAdded = AddItem(loot.item);
      if (itemIsAdded)
        Destroy(other.gameObject);
    }
    
    public bool AddItem(InventorySystem.Item item) {
      if (!CanAddItem())
        return false;
      _inventory.AddItem(item);
      inventoryInventoryUi.SetItem(item.GetItemUi(), item.GetIdentifier());
      return true;
    }

    public void DropItem(InventorySystem.Item item) {
      _inventory.RemoveItem(item.GetIdentifier());

      var droppedItem = new GameObject();
      var lootComponent = droppedItem.AddComponent<LootComponent>();
      var circleCollider2D = droppedItem.AddComponent<CircleCollider2D>();
      var spriteRenderer = droppedItem.AddComponent<SpriteRenderer>();

      lootComponent.item = item;
      spriteRenderer.sprite = item.GetItemUi().GetItemImage();
      circleCollider2D.radius = 0.15f;
      circleCollider2D.isTrigger = true;
      var dropPosition = new Vector3(0, 0);
      dropPosition += gameObject.transform.position;
      dropPosition += new Vector3(0, dropDistanceY);
      droppedItem.transform.position = dropPosition;
      droppedItem.transform.localScale = new Vector3(3f, 3f);
    }

    public void SetInventoryUi(IInventoryUi inventoryInventoryUiParam) {
      inventoryInventoryUi = inventoryInventoryUiParam;
    }
    
    public void RemoveItem(Identifier identifier) {
      _inventory.RemoveItem(identifier);
    }

    public InventorySystem.Item GetItem(Identifier identifier) {
      return _inventory.GetItem(identifier);
    }

    private bool CanAddItem() {
      return _inventory.GetInventorySize() <= _inventory.GetInventoryCapacity();
    }
    
    private void Start() {
      _inventory = new Inventory(new ArrayRepository(inventorySize), inventorySize);
    }
  }
}