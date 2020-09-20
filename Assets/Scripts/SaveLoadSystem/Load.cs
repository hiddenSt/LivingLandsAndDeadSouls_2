using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using Menu;
using UnityEngine;


namespace SaveLoadSystem
{
    public class Load : MonoBehaviour
    {
        void Start()
        {
            
        }
        void Update()
        {
            while (GameObject.Find("GunSlot") == null) {}
            if (GameObject.Find("ParametersManager").GetComponent<ParameterManager>().NeedToLoad == true)
            {
                SaveLoadSystem.SaveSystem.Load();
            }
            Destroy(this.gameObject);
        }
    }
}// end of namespace SaveLoadSystem
