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
        string _name;
        [SerializeField]
        Sprite _icon;
        [SerializeField]
        int _value;
        [SerializeField]
        int _burden;
        [SerializeField]
        ISQuality _quality;


        public ISObject(ISObject item)
        {
            Clone(item);
        }

        public void Clone(ISObject item)
        {
            _name = item.Name;
            _icon = item.Icon;
            _value = item.Value;
            _burden = item.Burden;
            _quality = item.Quality;
        }


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

        ISQualityDatabase qdb;
        int qualitySelectedIndex = 0;
        string[] option;

        public virtual void OnGUI()
        {
            GUILayout.BeginVertical();
            _name = EditorGUILayout.TextField("Name", _name);
            _value = EditorGUILayout.IntField("Value", _value);
            _burden = EditorGUILayout.IntField("Burden", _burden);
            DisplayIcon();
            DisplayQuality();
            GUILayout.EndVertical();

        }


        public void DisplayIcon()
        {
            _icon = EditorGUILayout.ObjectField("Icon", _icon, typeof(Sprite), false) as Sprite;
        }

        public int SelectedQualityID
        {
            get { return qualitySelectedIndex; }
        }
        public ISObject()
        {
            string DATABASE_NAME = @"csQualityDatabase.asset";
            string DATABASE_PATH = @"Database";
            qdb = ISQualityDatabase.GetDatabase<ISQualityDatabase>(DATABASE_PATH, DATABASE_NAME);

            option = new string[qdb.Count];
            for (int cnt = 0; cnt < qdb.Count; cnt++)
                option[cnt] = qdb.Get(cnt).Name;
        }



        public void DisplayQuality()
        {
      int itemIndex = 0;

            if ( _quality != null)
                itemIndex = qdb.GetIndex(_quality.Name);

            if (itemIndex == -1)
                itemIndex = 0;

            qualitySelectedIndex = EditorGUILayout.Popup("Quality", itemIndex, option);
            _quality = qdb.Get(SelectedQualityID);
        }

        //To be moved to a editor version of this class


    }
}