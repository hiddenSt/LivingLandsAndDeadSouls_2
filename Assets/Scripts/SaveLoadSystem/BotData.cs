using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;


namespace SaveLoadSystem
{
    [System.Serializable]
    public class BotData
    {
        public BotData(float xBegin, float xEnd, float yBegin, float yEnd, int enemyCount_, int animalsCount_)
        {
            xAxisBeginOfRange = xBegin;
            xAxisEndOfRange = xEnd;
            yAxisBeginOfRange = yBegin;
            yAxisEndOfRange = yEnd;
            enemyCount = enemyCount_;
            animalsCount = animalsCount_;
        }
        
        //data members
        public float xAxisBeginOfRange;
        public float xAxisEndOfRange;
        public float yAxisBeginOfRange;
        public float yAxisEndOfRange;
        public int enemyCount;
        public int animalsCount;
    }
}//end of namespace SaveLoadSystem
