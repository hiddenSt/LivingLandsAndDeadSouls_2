

namespace SaveLoadSystem.DTO {
  [System.Serializable]
  public class MapData {
    public int mapSizeX;
    public int mapSizeY;
    public int[,] map;
    public int season;
  }
}