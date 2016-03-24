using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem
{
    public interface IISEquipable
    {
        ISEquipmentSlot EquipmentSlot { get; }
        bool Equip();
    }
}