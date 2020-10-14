using HealthFight;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Interaction {
  public class HouseInteraction : MonoBehaviour {
    public GameObject[] items;
    public float damage;
    private bool _isLooted;
    private Button _interactButton;
    private Transform _playerPosition;
    
    private void OnTriggerEnter2D(Collider2D other) {
      if (_isLooted)
          return;
      if (other.name == "Player") {
          _interactButton.GetComponent<Button>().onClick.AddListener(Use);
          _interactButton.interactable = true;
          _playerPosition = other.gameObject.transform;
      }
    }

    public void Use() {
      if (_isLooted) {
        return;
      }
      _isLooted = true;
      var dropChance = Random.Range(0, items.Length + 1);
      if (dropChance == items.Length) {
        DropDamage();
      } else {
        DropItem(dropChance);
      }
    }

    private void OnTriggerExit2D(Collider2D other) {
      if (other.name == "Player") {
        _interactButton.interactable = false;
        _interactButton.GetComponent<Button>().onClick.RemoveListener(Use);
      }
    }

    private void DropDamage() {
      var droppedDamage = new GameObject();
      var damageComponent = droppedDamage.AddComponent<DamageComponent>();
      damageComponent.originId = gameObject.GetInstanceID();
      damageComponent.damageRadius = 0.2f;
      damageComponent.damagePoints = damage;
      droppedDamage.transform.position = _playerPosition.position;
    }

    private void DropItem(int index) {
      Instantiate(items[index], _playerPosition.position, Quaternion.identity);
    }
    
    private void Start() {
      _interactButton = GameObject.Find("EButton").GetComponent<Button>();
      _isLooted = false;
    }
  }
} // end of namespace interaction