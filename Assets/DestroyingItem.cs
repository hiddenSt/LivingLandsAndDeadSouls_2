using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingItem : MonoBehaviour {
  public GameObject destroyingItem;

  public void Destroy() {
    Destroy(GameObject.Find("DestroyingItem").GetComponent<Item>().destroyingItem);
    GameObject.Find("DestroyCanvas").transform.GetChild(0).gameObject.SetActive(false);
  }

  public void DontDestroy() {
    GameObject.Find("DestroyCanvas").transform.GetChild(0).gameObject.SetActive(false);
  }
}