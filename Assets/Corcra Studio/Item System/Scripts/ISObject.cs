using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

namespace CorcraStudio.ItemSystem
{
    [System.Serializable]
    public class ISObject : IISObject
    {
        [SerializeField]
        Sprite _icon;
        [SerializeField]
        string _name;
        [SerializeField]
        int _value;
        [SerializeField]
        int _burden;
        [SerializeField]
        ISQuality _quality;

        public int Burden
        {
            get { return _burden; }
            set { _burden = value; }
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

        public ISQuality Quality
        {
            get { return _quality; }
            set { _quality = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }



        //This code is going to be placed in a new class later on


        public virtual void OnGUI()
        {
            GUILayout.BeginVertical();
            _name = EditorGUILayout.TextField("Name", _name);
            _value = System.Convert.ToInt32(EditorGUILayout.TextField("Value", _value.ToString()));
            _burden = System.Convert.ToInt32(EditorGUILayout.TextField("Burden", _burden.ToString()));
            DisplayIcon();
            DisplayQuality();
            GUILayout.EndVertical();

        }


        public void DisplayIcon()
        {
            GUILayout.Label("Icon");
        }


        public void DisplayQuality()
        {
            GUILayout.Label("Quality");
        }
    }
}