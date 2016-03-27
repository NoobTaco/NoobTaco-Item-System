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
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
    {
        [SerializeField]
        D database;
        [SerializeField]
        string dbName;
        [SerializeField]
        string dbPath = @"Database";



        public ISObjectDatabaseType(string n)
        {
            dbName = n;
        }



        public void OnEnable()
        {
            if (database == null)
                LoadDatabase();
        }



        public void OnGUI()
        {

        }
    }
}