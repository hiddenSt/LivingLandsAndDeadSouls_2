using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class CharacteristicsData 
    {
        public CharacteristicsData(AllParameters characteristics)
        {
            level = characteristics.level;
            experience = characteristics.experience;
            toNextLevelExp = characteristics.toNextLevelExp;
            strength = characteristics.strength;
            health = characteristics.health;
            sniper = characteristics.sniper;
            freePoints = characteristics.freePoints;
        }
        
        //data members
        public float experience;
        public int level;
        public float toNextLevelExp;
        public int strength;
        public int health;
        public int sniper;
        public int freePoints;
    }
}//end of namespace SaveLoadSystem