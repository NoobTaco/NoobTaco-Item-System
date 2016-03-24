using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem
{
    public interface IISStacable
    {
        int Stack(int amount); //default value of 0
        int MaxStack { get; }

                
    }
}
