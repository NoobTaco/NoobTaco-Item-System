/// <summary>
/// ISObjectDatabaseType.cs
/// March 27, 2016
/// Mike Norton - Corcra Studio
/// 
/// </summary>
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : IISDatabaseObject, new()
    {
        [SerializeField]
        D database;
        [SerializeField]
        string dbName;
        [SerializeField]
        string dbPath = @"Database";
        public string strItemType = "Item";



        public ISObjectDatabaseType(string n)
        {
            dbName = n;
        }



        public void OnEnable(string itemType)
        {
            strItemType = itemType;

            if (database == null)
                LoadDatabase();
        }



        public void OnGUI(Vector2 buttonSize, int _listViewWidth)
        {
            ListView(buttonSize, _listViewWidth);
            ItemDetails();
        }
    }
}