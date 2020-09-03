using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class AudioData
    {
        public AudioData(float masterVolume, float musicVolume)
        {
            this.masterVolume = masterVolume;
            this.musicVolume = musicVolume;
        }
        
        //data members
        public float masterVolume;
        public float musicVolume;
    }
}//end of namespace SaveLoadSystem
