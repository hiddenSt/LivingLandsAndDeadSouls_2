

using System.Collections.Generic;

namespace SaveLoadSystem.SaveSystem {
  
  public static class SaveSystem {
    public static void Save() {
      foreach (var saver in _savers) {
        saver.Save();
      }
    }

    public static void AddSaver(ISaver saver) {
      _savers.Add(saver);
    }

    private static List<ISaver> _savers = new List<ISaver>();
  }
}