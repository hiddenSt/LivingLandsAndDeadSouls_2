using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMapData : MonoBehaviour
{
  public int[,] MapData;
  public int MapWidth;
  public int MapHeight;
  public int Year;
  public int Day;
  public int Season;
  public int Hour;

  public LoadingMapData(int[,] mapData, int mapWidth, int mapHeight, int year, int day, int season, int hour){
    MapData = mapData;
    MapWidth = mapWidth;
    MapHeight = mapHeight;
    Year = year;
    Day = day;
    Season = season;
    Hour = hour;
  }
}
