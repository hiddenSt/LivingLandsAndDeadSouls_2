using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Interaction {
  
  public class HouseInteraction : MonoBehaviour {
    /*private void Start() {
      _interactButton = GameObject.Find("EButton").GetComponent<Button>();
      _playerInventory = GameObject.Find("Player").GetComponent<InventorySystem.Inventory>();
      _playerHealthComponent = GameObject.Find("Player").GetComponent<HealthFight.HealthComponent>();
      _isLooted = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
      if (_isLooted)
          return;
      if (other.name == "Player") {
          _interactButton.GetComponent<Button>().onClick.AddListener(Use);
          _interactButton.interactable = true;
      }
    }

    public void Use() {
      if (_isLooted)
        return;
      var i = Random.Range(0, loots.Length);
      if (i == loots.Length) {
        _playerHealthComponent.DecreaseHealth(10);
        _isLooted = true;
        return;
      }

      _interactButton.interactable = false;
      for (var j = 0; j < _playerInventory.items.Length; j++) {
        if (_playerInventory.items[j] == 1) continue;
        _playerInventory.items[j] = 1;
        _isLooted = true;
        var gunSelectComp = loots[i].GetComponent<InventorySystem.GunSelect>();
        if (gunSelectComp != null) {
          gunSelectComp.slotIndex = j;
          var loadedObj = Instantiate(loots[i], _playerInventory.buttonSlots[j].transform, false);
          var immgObj = Instantiate(loots[i].GetComponent<InventorySystem.GunSelect>().gunImage, _playerInventory.slots[j].transform, false);
          loadedObj.GetComponent<InventorySystem.GunSelect>().imageObj = immgObj;
          return;
        }

        var outfitSelectComp = loots[i].GetComponent<InventorySystem.OutfitSelect>();
        if (outfitSelectComp != null) {
          outfitSelectComp.slotIndex = i;
          var loadedObj = Instantiate(loots[i], _playerInventory.buttonSlots[j].transform, false);
          var immgObj = Instantiate(loots[i].GetComponent<InventorySystem.OutfitSelect>().outfitImage, _playerInventory.slots[j].transform, false);
          loadedObj.GetComponent<InventorySystem.OutfitSelect>().imageObj = immgObj;
          return;
        }
        Instantiate(loots[i], _playerInventory.slots[j].transform, false);
        return;
      }
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.name == "Player") {
        _interactButton.interactable = false;
        _interactButton.GetComponent<Button>().onClick.RemoveListener(Use);
      }
    }
    
    //data members
    public GameObject[] loots;
    
    private InventorySystem.Inventory _playerInventory;
    private HealthFight.HealthComponent _playerHealthComponent;
    private bool _isLooted;
    private Button _interactButton;*/
  }
}// end of namespace interaction
