using SaveLoadSystem.SaveSystem;
using SaveLoadSystem.SaveSystem.Savers;
using UnityEngine;

namespace Components {

  public class GameSaver : MonoBehaviour {
    public void Setup(string playerDataFileName, string mapDataFileName, string botsDataFileName) {
      var playerSaver = new PlayerSaver(playerDataFileName);
      var mapSaver = new MapSaver(mapDataFileName);
      var botsSaver = new BotsSaver(botsDataFileName);
      SaveSystem.AddSaver(playerSaver);
      SaveSystem.AddSaver(mapSaver);
      SaveSystem.AddSaver(botsSaver);
    }

    public void Save() {
      SaveSystem.Save();
    }
  }

}
