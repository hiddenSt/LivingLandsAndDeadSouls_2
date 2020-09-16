using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataStorage : MonoBehaviour
{ 
  public int[,] MapContent = new int[2,2];
  public List<GameObject> TreeList;
  public List<GameObject> RockList;
  public List<GameObject> BushList;
  public List<GameObject> HouseList;
  public List<int> HouseTypeList;
  public int MapHeight;
  public int MapWidth;
  public int Season;
}
