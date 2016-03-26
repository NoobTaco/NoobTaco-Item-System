using UnityEngine;
using System.Linq; //needed for Elementat
using System.Collections;
using System.Collections.Generic;

namespace CorcraStudio.ItemSystem
{
    public class ISQualityDatabase : ScriptableObjectDatabase<ISQuality>
    {
        public int GetIndex( string name)
        {
            return database.FindIndex(a => a.Name == name);
        }
    }

}
