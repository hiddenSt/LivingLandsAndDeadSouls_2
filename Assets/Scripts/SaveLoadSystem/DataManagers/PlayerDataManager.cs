using UnityEngine;


namespace SaveLoadSystem.DataManagers {
  public class PlayerDataManager : IDataManager {
    public PlayerDataManager(string filePath) {
      _loader = null;
      _filePath = filePath;
    }

    public void Load() { }
    public void Save() { }
    public void DeleteSaves() { }

    
    //data members
    private GameObject _loader;
    private string _filePath;
  }
}
