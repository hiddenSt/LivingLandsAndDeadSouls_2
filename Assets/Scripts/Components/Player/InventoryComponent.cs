using InventorySystem;
using InventorySystem.ArrayRepository;
using UnityEngine;
using Utility;
using Components.Loot;

namespace Components.Player {
  
  public class InventoryComponent : MonoBehaviour {
    public int inventorySize;
    public float dropDistanceY = 0.3f;
    private IInventoryUi _inventoryUi;
    private Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D other) {
      var loot = other.gameObject.GetComponent<LootComponent>();
      if (loot == null)
        return;
      var itemIsAdded = AddItem(loot.item);
      if (itemIsAdded)
        Destroy(other.gameObject);
    }
    
    public bool AddItem(Item item) {
      if (!CanAddItem())
        return false;
      _inventory.AddItem(item);
      return true;
    }

    public void DropItem(Item item) {
      var droppedItem = new GameObject();
      var lootComponent = droppedItem.AddComponent<LootComponent>();
      var circleCollider2D = droppedItem.AddComponent<CircleCollider2D>();
      var spriteRenderer = droppedItem.AddComponent<SpriteRenderer>();

      lootComponent.item = item;
      spriteRenderer.sprite = item.GetItemUi().GetItemImage();
      spriteRenderer.sortingOrder = 100;
      circleCollider2D.radius = 0.15f;
      circleCollider2D.isTrigger = true;
      var dropPosition = new Vector3(0, 0);
      dropPosition += gameObject.transform.position;
      dropPosition += new Vector3(0, dropDistanceY);
      droppedItem.transform.position = dropPosition;
      droppedItem.transform.localScale = new Vector3(3f, 3f);
    }
    
    
    public void SetInventory(Inventory inventory) {
      _inventory = inventory;
    }

    public Inventory GetInventory() {
      return _inventory;
    }

    public Item GetItem(Identifier identifier) {
      return _inventory.GetItem(identifier);
    }
    
    public void SetInventoryUi(IInventoryUi inventoryUi) {
      _inventoryUi = inventoryUi;
    }

    private void SetItemsUi() {
      IItemIterator iterator = _inventory.GetIterator();
      for (iterator.First(); iterator.IsDone(); iterator.Next()) {
        _inventoryUi.SetItem(iterator.CurrentItem().GetItemUi(), iterator.CurrentItem().GetIdentifier());
      }
    }
    
    private bool CanAddItem() {
      return _inventory.GetInventorySize() <= _inventory.GetInventoryCapacity();
    }
    
    private void Start() {
      _inventory = new Inventory(new ArrayRepository(inventorySize), _inventoryUi, inventorySize);
    }
  }
}