using System.Collections.Generic;

namespace SaveLoadSystem {
  public static class SaveSystem {
    public static void Save() {
      foreach (var dataManager in DataManagers)
        dataManager.Save();
    }

    public static void Load() {
      foreach (var dataManager in DataManagers)
        dataManager.Load();
    }

    public static void DeleteSaves() {
      foreach (var dataManager in DataManagers)
        dataManager.DeleteSaves();
    }

    //data members
    public static List<IDataManager> DataManagers;
  }
}
