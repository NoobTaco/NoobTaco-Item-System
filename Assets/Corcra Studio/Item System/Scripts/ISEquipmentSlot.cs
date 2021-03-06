﻿using UnityEngine;
using System.Collections;
using System;

namespace CorcraStudio.ItemSystem
{
    public class ISEquipmentSlot : IISEquipmentSlot
    {
        [SerializeField]
        string _name;
        [SerializeField]
        Sprite _icon;

        public ISEquipmentSlot()
        {
            _name = "Name Me";
            _icon = new Sprite();
        }

        public Sprite Icon
        {
            get { return _icon; }
            set { _icon = value; }

        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }

        }
    }
}