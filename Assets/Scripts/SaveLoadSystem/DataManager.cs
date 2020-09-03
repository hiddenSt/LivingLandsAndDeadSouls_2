using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SaveLoadSystem
{
    public abstract class DataManager
    {
        public abstract void Load();
        public abstract void Save();

        public abstract void DeleteSaves();
    }
}//end of namespace SaveLoadSystem
