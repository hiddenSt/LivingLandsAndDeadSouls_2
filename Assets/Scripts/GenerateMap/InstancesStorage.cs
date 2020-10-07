using System.Collections.Generic;
using UnityEngine;

namespace GenerateMap {
  public class InstancesStorage : MonoBehaviour {
    public List<GameObject> InstanceList;

    public GameObject GetObjectInstance(string objectName) {
      for (int i = 0; i < InstanceList.Count; i++) {
        if (InstanceList[i].name == objectName) {
          return InstanceList[i];
        }
      }

      return null;
    }
  }
}