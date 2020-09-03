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
            meatButton = parametrManager.meatButton;
            medkitButton = parametrManager.medkitButton;
            outfit1Button = parametrManager.outfit1Button;
            outfit2Button = parametrManager.outfit2Button;
            gun1Button = parametrManager.gun1Button;
            gun2Button = parametrManager.gun2Button;
            ammoButton = parametrManager.ammoButton;
            outfit1Image = parametrManager.outfit1Image;
            outfit2Image = parametrManager.outfit2Image;
            gun1Image = parametrManager.gun1Image;
            gun2Image = parametrManager.gun2Image;
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
