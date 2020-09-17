using System.Collections;
using System.Collections.Generic;
using Menu;
using UnityEngine;

namespace SaveLoadSystem
{
    public class Loader : MonoBehaviour
    {
        public void LoadButtons()
        {
            var parametrManager = GameObject.Find("ParametersManager").GetComponent<ParameterManager>();
            meatButton = parametrManager.MeatButton;
            medkitButton = parametrManager.MedkitButton;
            outfit1Button = parametrManager.Outfit1Button;
            outfit2Button = parametrManager.Outfit2Button;
            gun1Button = parametrManager.Gun1Button;
            gun2Button = parametrManager.Gun2Button;
            ammoButton = parametrManager.AmmoButton;
            outfit1Image = parametrManager.Outfit1Image;
            outfit2Image = parametrManager.Outfit2Image;
            gun1Image = parametrManager.Gun1Image;
            gun2Image = parametrManager.Gun2Image;
        }
        
        public GameObject LoadObjectOnScene(GameObject objectToLoad, Transform parentTransform)
        {
            return Instantiate(objectToLoad, parentTransform, false);
        }
        
        //data members
        public GameObject medkitButton;
        public GameObject meatButton;
        public GameObject outfit1Button;
        public GameObject outfit2Button;
        public GameObject gun1Button;
        public GameObject gun2Button;
        public GameObject ammoButton;
        public GameObject outfit1Image;
        public GameObject outfit2Image;
        public GameObject gun1Image;
        public GameObject gun2Image;
    }
}//end pf namespace SaveLoadSystem
