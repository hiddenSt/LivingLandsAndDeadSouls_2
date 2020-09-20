using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace InventorySystem
{
    public class GunSlot : MonoBehaviour
    {
        private void Start()
        {
            _playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
            _gunComponent = GameObject.Find("FireButton").GetComponent<HealthFight.Gun>();
            character = GameObject.Find("ParametersManager").GetComponent<Menu.ParameterManager>().CharacterI;
            ChangeCharacter();
        }

        public void ChangeCharacter()
        {
            if (character == 1)
                _playerAnimator.runtimeAnimatorController = animatorOverrideWG[3];
            else if (character == 2)
                _playerAnimator.runtimeAnimatorController = animatorOverrideWG[4];
        }
        
        public void Cross()
        {
            var child1 = this.gameObject.transform.GetChild(0);
            var child2 = this.gameObject.transform.GetChild(1);
            if (child1 == null)
                return;
            itemButton.GetComponent<GunSelect>().ammoCount =
                GameObject.Find("FireButton").GetComponent<HealthFight.Gun>().ammoCount;
            if (skinIndex == 0)
            {
                switch (character)
                {
                    case 0: break;
                    case 1: skinIndex = 3;
                        break;
                    case 2: skinIndex = 4;
                        break;
                }
            }
            _playerAnimator.runtimeAnimatorController = animatorOverrideWG[skinIndex];
            for (int i = 0; i < _playerInventory.items.Length; ++i)
            {
                if (_playerInventory.items[i] == 0)
                {
                    itemButton.SetActive(true);
                    Instantiate(itemButton, _playerInventory.slots[i].transform, false);
                    _playerInventory.items[i] = 1;
                    Destroy(child1.gameObject);
                    Destroy(child2.gameObject);
                    isEmpty = 1;
                    _gunComponent.ammoCount = 0;
                    return;
                }
            }

            Destroy(child1.gameObject);
            Destroy(child2.gameObject);
            isEmpty = 1;
            _gunComponent.ammoCount = 0;
        }

        public void SwapGuns(int i)
        {
            var child1 = this.gameObject.transform.GetChild(0);
            var child2 = this.gameObject.transform.GetChild(1);
            itemButton.GetComponent<GunSelect>().ammoCount =
                GameObject.Find("FireButton").GetComponent<HealthFight.Gun>().ammoCount;
            itemButton.SetActive(true);
            itemButton.GetComponent<GunSelect>().slotIndex = i;
            var gameObj = Instantiate(itemButton, _playerInventory.buttonSlots[i].transform, false);
            var imageObj = Instantiate(itemButton.GetComponent<GunSelect>().gunImage, _playerInventory.slots[i].transform,
                false);
            gameObj.GetComponent<GunSelect>().imageObj = imageObj;
            imageObj.GetComponent<DropItem>().buttonSlot = gameObj;
            Destroy(child1.gameObject);
            Destroy(child2.gameObject);
        }

        public void SetGun(GameObject itemButton)
        {
            gameObject.GetComponent<DropToInventory>().isEmpty = false;
            this.itemButton = Instantiate(itemButton, this.transform, false);
            this.itemButton.SetActive(false);
            var gunSelectComponent = itemButton.GetComponent<GunSelect>();
            Instantiate(itemButton.GetComponent<GunSelect>().gunImage, this.transform, false);
            _gunComponent.SetGun(gunSelectComponent.damage, gunSelectComponent.ammoCount, gunSelectComponent.fireRate);
            isEmpty = 0;
            animatorOverride = this.itemButton.GetComponent<GunSelect>().animatorOverride;
            ChangeSkin(skinIndex);
            gameObject.transform.GetChild(1).GetComponent<DropItem>().isActive = false;
        }
        
        public void ChangeSkin(int skinIndex)
        {
            this.skinIndex = skinIndex;
            if (skinIndex == 0)
            {
                switch (character)
                {
                    case 0: break;
                    case 1: skinIndex = 3;
                        break;
                    case 2: skinIndex = 4;
                        break;
                }
            }
            if (isEmpty == 1)
            {
                _playerAnimator.runtimeAnimatorController = animatorOverrideWG[skinIndex];
                return;
            }

            Debug.Log("Override size: " + animatorOverride.Length);
            _playerAnimator.runtimeAnimatorController = animatorOverride[skinIndex];
        }

        public int GetDamage()
        {
            if (itemButton == null)
                return 0;
            return itemButton.GetComponent<GunSelect>().damage;
        }

        public int GetAmmoCount()
        {
            return _gunComponent.ammoCount;
        }

        //data members
        public AnimatorOverrideController[] animatorOverride;
        public AnimatorOverrideController[] animatorOverrideWG;
        public int isEmpty = 1;
        public int character;
        public GameObject itemButton;
        public int skinIndex = 0;
        
        private HealthFight.Gun _gunComponent;
        private Inventory _playerInventory;
        private Animator _playerAnimator;
      
    }
}//end of namespace InventorySystem