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
    public class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject
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



        void LoadDatabase()
        {
            string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

            //load the database
            database = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(D)) as D;


            //if we could not load the database, create one
            if (database == null)
                CreateDatabase(dbFullPath);
        }


        void CreateDatabase(string dbFullPath)
        {
            //check to see if the folder exists, if not create it
            if (!AssetDatabase.IsValidFolder("Assets/" + dbPath))
                AssetDatabase.CreateFolder("Assets", dbPath);

            //create the database and refresh the AssetsDatabase
            database = ScriptableObject.CreateInstance<D>() as D;
            AssetDatabase.CreateAsset(database, dbFullPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}