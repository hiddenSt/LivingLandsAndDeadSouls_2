namespace GenerateMap.DataTransferObjects {
  public abstract class GeneratingObjectData {
    public int Value;
    public int DistanceFromAnotherObjects;
    public int ObjectCode;

    public GeneratingObjectData(int value, int distance, int objectCode) {
      Value = value;
      DistanceFromAnotherObjects = distance;
      ObjectCode = objectCode;
    }
  }
}