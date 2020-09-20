using System.Collections;
using System.Collections.Generic;
using Characteristics;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class CharacteristicsData 
    {
        public CharacteristicsData(AllParameters characteristics)
        {
            level = characteristics.Level;
            experience = characteristics.Experience;
            toNextLevelExp = characteristics.ToNextLevelExp;
            strength = characteristics.Strength;
            health = characteristics.Health;
            sniper = characteristics.Skill;
            freePoints = characteristics.FreePoints;
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