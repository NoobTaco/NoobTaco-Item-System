﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;
using System;

namespace CorcraStudio.ItemSystem
{
    [System.Serializable]
    public class ISWeapon : ISObject, IISWeapon, IISDestructable, IISGameObject
    {
        [SerializeField]
        int _minDamage;
        [SerializeField]
        int _durability;
        [SerializeField]
        int _maxDurability;
        [SerializeField]
        GameObject _prefab;

        public EquipmentSlot equipmentSlot;


        //Default values for new items
        public ISWeapon()
        {
            _minDamage = 0;
            _durability = 1;
            _maxDurability = 1;
            equipmentSlot = EquipmentSlot.Hands;
        }

        public ISWeapon(ISWeapon weapon)
        {
            Clone(weapon);
        }


        public void Clone(ISWeapon weapon )
        {
            base.Clone(weapon);
            _minDamage = weapon.MinDamage;
            _durability = weapon.Durability;
            _maxDurability = weapon.MaxDurability;
            equipmentSlot = weapon.equipmentSlot;
            _prefab = weapon.Prefab;
        }


        public int Durability
        {
            get { return _durability; }
        }

        public int MaxDurability
        {
            get { return _maxDurability; }
        }

        public int MinDamage
        {
            get { return _minDamage; }
            set { _minDamage = value; }
        }


        public GameObject Prefab
        {
            get
            {
                return _prefab;
            }
        }

        public int Attack()
        {
            throw new NotImplementedException();
        }



        //reduce the durability to 0;
        //not sure what to do with method
        public void Break()
        {
            _durability = 0;
        }



        public void Repair()
        {
            _maxDurability--;

            if (_maxDurability > 0)
                _durability = _maxDurability;
        }



        public void TakeDamage(int amount)
        {
            _durability -= amount;

            if (_durability < 0)
                _durability = 0;

            if (_durability == 0)
                Break();
        }




        //this code will go in to a new script later
#if UNITY_EDITOR
        public override void OnGUI()
        {
            base.OnGUI();

            _minDamage = EditorGUILayout.IntField("Damage", _minDamage);
            _durability = EditorGUILayout.IntField("Min Durability", _durability);
            _maxDurability = EditorGUILayout.IntField("Max Durability", _maxDurability);

            DisplayEquipmentSlot();
            DisplayPrefab();

        }

        public void DisplayEquipmentSlot()
        {
           equipmentSlot= (EquipmentSlot)EditorGUILayout.EnumPopup("Equipment Slot", equipmentSlot);
            GUILayout.Label("Equipment Slot");

        }

 //       public void DisplayIcon()
 //       {
 //           _icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(GameObject), false) as GameObject;
 //       }



        public void DisplayPrefab()
        {
           _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
        }
#endif
    }
}
