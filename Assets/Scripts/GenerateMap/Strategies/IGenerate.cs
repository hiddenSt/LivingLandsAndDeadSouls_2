namespace GenerateMap.Strategies {
  interface IGenerator {
    
    public int[,] Generate(int[,] mapData);
  }
}