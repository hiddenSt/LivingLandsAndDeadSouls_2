using System.Collections;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class Bag : MonoBehaviour
    {
        void Start()
        {
            _playerInventory = GameObject.Find("Player").GetComponent<Inventory>();
            _skills = GameObject.Find("Skills");
            //_isClosed = false;
            //OpenCloseBag();
        }

        public bool IsClosed()
        {
            return _isClosed;
        }
        public void OpenCloseBag()
        {
            if (_isClosed == true)
            {
                foreach (var bagElement in _playerInventory.slots)
                    bagElement.SetActive(true);
                _skills.SetActive(true);
                _isClosed = false;
            }
            else
            {
                foreach (var bagElement in _playerInventory.slots)
                    bagElement.SetActive(false);
                _skills.SetActive(false);
                _isClosed = true;
            }
        }

        //data members
        private bool _isClosed;
        private Inventory _playerInventory;
        private GameObject _skills;
    }
}// end of namespace InventorySystem

