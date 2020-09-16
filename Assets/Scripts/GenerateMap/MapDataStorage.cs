using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapDataStorage : MonoBehaviour
{
  public List<GameObject> TreeList;
  public List<GameObject> RockList;
  public List<GameObject> BushList;
  public List<GameObject> HouseList;
  public List<int> HouseTypeList;
  public int Season;
}
