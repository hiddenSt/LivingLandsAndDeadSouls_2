
using System.Collections.Generic;

namespace SaveLoadSystem.LoadSystem {

  public static class LoadSystem {
    public static void Load() {
      foreach (var loader in _loaders) {
        loader.Load();
      }
    }

    public static void DeleteSaves() {
      foreach (var loader in _loaders) {
        loader.DeleteSaves();
      }
    }

    public static void AddLoader(ILoader loader) {
      _loaders.Add(loader);
    }

    private static List<ILoader> _loaders = new List<ILoader>();
  }

}
