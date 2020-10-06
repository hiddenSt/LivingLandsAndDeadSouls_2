using SaveLoadSystem.SaveSystem;
using SaveLoadSystem.SaveSystem.Savers;
using UnityEngine;

namespace Components {

  public class GameSaver : MonoBehaviour {
    private void Start() {
      var playerSaver = new PlayerSaver("Player.data");
      SaveSystem.AddSaver(playerSaver);
    }

    public void Save() {
      SaveSystem.Save();
    }
  }

}
