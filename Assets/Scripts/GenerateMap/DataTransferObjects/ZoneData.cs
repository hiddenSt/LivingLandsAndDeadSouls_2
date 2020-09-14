namespace GenerateMap.DataTransferObjects {
  public class ZoneData: GeneratingObjectData {
    
    public int PlaceSize;
    public int PlaceDistance;
    
    public ZoneData(int value, int distance, int objectCode, int placeSize, int placeDistance) : 
      base( value, distance, objectCode) {
      PlaceSize = placeSize;
      PlaceDistance = placeDistance;
    }
  }
}