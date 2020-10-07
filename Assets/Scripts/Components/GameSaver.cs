using SaveLoadSystem.SaveSystem;
using SaveLoadSystem.SaveSystem.Savers;
using UnityEngine;

namespace Components {

  public class GameSaver : MonoBehaviour {
    private void Start() {
      var playerSaver = new PlayerSaver("Player.data");
      var mapSaver = new MapSaver("Map.data");
      var botsSaver = new BotsSaver("Bots.data");
      SaveSystem.AddSaver(playerSaver);
      SaveSystem.AddSaver(mapSaver);
      SaveSystem.AddSaver(botsSaver);
    }

    public void Save() {
      SaveSystem.Save();
    }
  }

}
