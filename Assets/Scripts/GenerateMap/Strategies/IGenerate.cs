namespace GenerateMap.Strategies {
  interface IGenerator {
    int[,] Generate(int[,] mapData);
  }
}
