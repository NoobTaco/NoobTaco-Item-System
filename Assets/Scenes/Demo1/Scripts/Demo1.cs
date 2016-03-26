//connect to the database
//spawn item from the database


using UnityEngine;
using System.Collections;
using CorcraStudio.ItemSystem;

[DisallowMultipleComponent]
public class Demo1 : MonoBehaviour
{

    public ISWeaponDatabase database;

    void OnGUI()
    {
        for(int cnt = 0;  cnt < database.Count; cnt++)
        if (GUILayout.Button("Spawn: " + database.Get(cnt).Name))
            Spawn(cnt);
    }



    void Spawn(int index)
    {
        ISWeapon isw = database.Get(index);
        GameObject weapon = Instantiate(isw.Prefab);
        weapon.name = isw.Name;

        Weapon myWeapon = weapon.AddComponent<Weapon>();

        myWeapon.Icon = isw.Icon;
        myWeapon.Value = isw.Value;
        myWeapon.Burden = isw.Burden;
        myWeapon.Quality = isw.Quality.Icon;
        myWeapon.Min_Damage = isw.MinDamage;
        myWeapon.Durability = isw.Durability;
        myWeapon.Max_Durability = isw.MaxDurability;
        myWeapon.Equipment_Slot = isw.equipmentSlot;


    }

}
