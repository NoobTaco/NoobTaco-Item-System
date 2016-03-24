using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem
{
    public interface IISWeapon 
    {
        int MinDamage { get; set; }
        int Attack();

    }
}