using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class AmmoPick : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _fireButton = GameObject.Find("FireButton");
            _gunSlot = GameObject.Find("GunSlot").GetComponent<GunSlot>();
        }

        // Update is called once per frame
        public void Use()
        {
            if (_gunSlot.transform.childCount <= 0)
                return;
            gun = _fireButton.GetComponent<HealthFight.Gun>();
            gun.ammoCount += ammoCount;
            GameObject.Find("AmmoText").GetComponent<Text>().text = gun.ammoCount.ToString();
            Destroy(gameObject);
        }

        //data members
        public int ammoCount;

        private GameObject _fireButton;
        private HealthFight.Gun gun;
        private GunSlot _gunSlot;
    }
}//end of namespace InventorySystem
