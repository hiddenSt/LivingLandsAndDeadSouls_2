using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class MapData
    {
        public MapData(List<GameObject> bushList, List<GameObject> treeList, List<GameObject> rockList,
            List<GameObject> houseList, List<int> houseTypeList, int season, int year, int day, Vector3Int tmpSize)
        {
            tmpSizeX = tmpSize.x;
            tmpSizeY = tmpSize.y;
            tmpSizeZ = tmpSize.z;
            bushPosition = new List<ObjectPosition>(bushList.Count);
            bushSortingOrder = new int[bushList.Count];
            for (int i = 0; i < bushList.Count; ++i)
            {
                var objPos = new ObjectPosition();
                objPos.x = bushList[i].transform.position.x;
                objPos.y = bushList[i].transform.position.y;
                objPos.z = bushList[i].transform.position.z;
                bushPosition.Add(objPos);
                bushSortingOrder[i] = bushList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder;
            }
            
            treePosition = new List<ObjectPosition>(treeList.Count);
            treeSortingOrder = new int[treeList.Count];
            for (var i = 0; i < treeList.Count; ++i)
            {
                var objPos = new ObjectPosition();
                objPos.x = treeList[i].transform.position.x;
                objPos.y = treeList[i].transform.position.y;
                objPos.z = treeList[i].transform.position.z;
                treePosition.Add(objPos);
                treeSortingOrder[i] = treeList[i].GetComponentInChildren<SpriteRenderer>().sortingOrder;
            }
            
            rockPosition = new List<ObjectPosition>(rockList.Count);
            rockSortingOrder = new int[rockList.Count];
            for (var i = 0; i < rockList.Count; ++i)
            {
                var objPos = new ObjectPosition();
                objPos.x = rockList[i].transform.position.x;
                objPos.y = rockList[i].transform.position.y;
                objPos.z = rockList[i].transform.position.z;
                rockPosition.Add(objPos);
                rockSortingOrder[i] = rockList[i].GetComponent<SpriteRenderer>().sortingOrder;
            }
            
            housePosition = new List<ObjectPosition>(houseList.Count);
            houseSortingOrder = new int[houseList.Count];
            this.houseTypeList = new int[houseList.Count]; 
            for (var i = 0; i < houseList.Count; ++i)
            {
                var objPos = new ObjectPosition();
                objPos.x = houseList[i].transform.position.x;
                objPos.y = houseList[i].transform.position.y;
                objPos.z = houseList[i].transform.position.z;
                housePosition.Add(objPos);
                houseSortingOrder[i] = houseList[i].GetComponent<SpriteRenderer>().sortingOrder;
                this.houseTypeList[i] = houseTypeList[i];
            }

            this.season = season;
            this.year = year;
            this.day = day;
        }
        
        //data members
        public List<ObjectPosition> bushPosition;
        public List<ObjectPosition> treePosition;
        public List<ObjectPosition> housePosition;
        public List<ObjectPosition> rockPosition;

        public int[] bushSortingOrder;
        public int[] rockSortingOrder;
        public int[] treeSortingOrder;
        public int[] houseSortingOrder;

        public int[] houseTypeList;

        public int season;
        public int year;
        public int day;
        public int tmpSizeX;
        public int tmpSizeY;
        public int tmpSizeZ;
    }
}// end of namespace SaveLoadSystem
