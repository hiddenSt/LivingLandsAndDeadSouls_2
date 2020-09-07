using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class Slot : MonoBehaviour
    {
        private void Start()
        {
            _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        }

        private void Update()
        {
            if (transform.GetChild(0).childCount <= 0 && transform.childCount <= 1)
            {
                _playerInventory.items[index] = 0;
            }
        }
        
        //data members
        public int index;
        public GameObject destroyButton;
        public GameObject buttonSlot;
        private Inventory _playerInventory;
    }
}// end of namespace InventorySystem