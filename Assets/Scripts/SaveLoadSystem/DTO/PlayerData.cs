using UnityEngine;

namespace SaveLoadSystem.DTO {
  [System.Serializable]
  public class PlayerData {
    //0 - empty
    //1 - medkit
    //2 - meat
    //3 - gun1
    //4 - gun2
    //5 - ammo
    //6 - outfit1
    //7 - outfit2

    /*public PlayerData(Vector3 playerPosition, InventorySystem.Inventory playerInventory, int gun, int skinIndex,
      int character, int health, int ammoCount, int maxHealth) {
      this.health = health;
      this.maxHealth = maxHealth;
      position = new float[3];
      gunsAmmoCount = new int[6];
      position[0] = playerPosition.x;
      position[1] = playerPosition.y;
      position[2] = playerPosition.z;
      this.inventory = new int[6];
      currentCharacter = character;
      currentGun = gun;
      currentSkinIndex = skinIndex;
      this.ammoCount = ammoCount;

      for (int i = 0; i < playerInventory.slots.Length; ++i) {
        gunsAmmoCount[i] = 0;
        if (playerInventory.slots[i].transform.childCount <= 1) {
          inventory[i] = 0;
        }
        else if (playerInventory.slots[i].transform.GetChild(1).GetComponent<InventorySystem.HealthBoost>() != null) {
          if (playerInventory.slots[i].transform.GetChild(1).GetComponent<InventorySystem.HealthBoost>()
            .healthBoostPoints == 20)
            inventory[i] = 1;
          else
            inventory[i] = 2;
        }
        else if (playerInventory.slots[i].transform.GetChild(1).GetComponent<InventorySystem.AmmoPick>() != null) {
          inventory[i] = 5;
        }
        else if (playerInventory.buttonSlots[i].transform.GetChild(0).GetComponent<InventorySystem.GunSelect>() !=
                 null) {
          var dmg = playerInventory.buttonSlots[i].transform.GetChild(0).GetComponent<InventorySystem.GunSelect>()
            .damage;
          if (dmg == 5)
            inventory[i] = 3;
          else
            inventory[i] = 4;
          gunsAmmoCount[i] = playerInventory.buttonSlots[i].transform.GetChild(0)
            .GetComponent<InventorySystem.GunSelect>().ammoCount;
        }
        else {
          var otft = playerInventory.buttonSlots[i].transform.GetChild(0).GetComponent<InventorySystem.OutfitSelect>()
            .skinIndex;
          if (otft == 1)
            inventory[i] = 6;
          else
            inventory[i] = 7;
        }
      }
    }
    
    //data members
    public int health;
    public int damage;
    public int ammoCount;
    public int fireRate;
    public float[] position;
    public int[] inventory;
    public int[] gunsAmmoCount;
    public int currentSkinIndex;
    public int currentGun;
    public int currentCharacter;
    public int maxHealth;*/
  }
}