using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class ParameterManager : MonoBehaviour
    {
        void Start()
        {
            _mapScalerSmall = 3;
            _mapScalerMedium = 5;
            _mapScalerBig = 10;
            tmpSize.x = 200;
            tmpSize.y = 200;
            buildingValue = 8;
            rockValue = 4;
            forestValue = 3;
            sizeOfForest = 10;
            if (instance == null)
                instance = this;
            else if (instance == this)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        
        //data members
        public static ParameterManager instance = null;
        public int rockValue = 4;
        public int buildingValue = 8;
        public int forestValue = 3;
        public int sizeOfForest = 10;
        public int characterI = 0;
        public int hostileCharVal;
        public int neutralCharVal;
        public int precipitation;
        public int startSeason = 0;
        public Vector3Int tmpSize;
        public bool needToLoad = false;

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

        private int _mapScalerSmall;
        private int _mapScalerMedium;
        private int _mapScalerBig;
    }
}//end of namespace Menu