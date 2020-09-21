using System;
using System.Collections;
using System.Collections.Generic;
using HealthFight;
using UnityEngine;

public class UnitDeath : MonoBehaviour {
  public GameObject loot;

  public void AfterDeath() {
    var meatPosition = gameObject.transform.position;
    var locMeat = Instantiate(loot);
    locMeat.transform.position = meatPosition;
    Debug.Log("Loot dropped !");
  }
}