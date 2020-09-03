using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InventorySystem
{
    public class OutfitSelect : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            _outfitSlot = GameObject.Find("SuitSlot");
            _outfitSlotComponent = _outfitSlot.GetComponent<OutfitSlot>();
        }

        public void Use()
        {
            if (_outfitSlot.transform.childCount > 1)
            {
                _outfitSlotComponent.SwapOutfits(slotIndex);
            }
            _outfitSlotComponent.SetOutfit(outfitButton);
            Destroy(imageObj);
            Destroy(gameObject);
        }

        public void LoadOutfit(GameObject outfitImage_)
        {
            Instantiate(outfitImage_, _outfitSlot.transform, false);
            _outfitSlotComponent.SetOutfit(outfitButton);
            _outfitSlotComponent.skinIndex = skinIndex;
            _outfitSlotComponent.ChangeSkin();
        }

        public void DestroyItem()
        {
            Destroy(this.gameObject);
        }

        //data members
        public GameObject outfitButton;
        public GameObject outfitImage;
        public int slotIndex;
        public int skinIndex;
        public GameObject imageObj;

        private GameObject _outfitSlot;
        private OutfitSlot _outfitSlotComponent;
    }
}// end of namespace InventorySystem
