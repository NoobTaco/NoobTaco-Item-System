using UnityEngine;
using UnityEditor;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        /// <summary>
        /// Add an item to the database
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            database.Item.Add(item);
            EditorUtility.SetDirty(database);
        }



        /// <summary>
        /// Insert an Item at the specified index
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Insert(int index, T item)
        {
            database.Item.Insert(index, item);
            EditorUtility.SetDirty(database);

        }



        /// <summary>
        /// Remove an Item.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Remove(T item)
        {
            database.Item.Remove(item);
            EditorUtility.SetDirty(database);

        }



        /// <summary>
        /// Remove the Item at a specified index.
        /// </summary>
        /// <param name="index">Item.</param>
        public void Remove(int index)
        {
            database.Item.RemoveAt(index);
            EditorUtility.SetDirty(database);

        }




        /// <summary>
        /// Replace the item at the specified index with this new one.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Replace(int index, T item)
        {
            database.Item[index] = item;
            EditorUtility.SetDirty(database);
        }


        public static U GetDatabase<U>(string dbPath, string dbName) where U : ScriptableObject
        {
            string dbFullPath = @"Assets/" + dbPath + "/" + dbName;

            U db = AssetDatabase.LoadAssetAtPath(dbFullPath, typeof(U)) as U;

            if (db == null)
            {
                //check to see if the folder exists
                if (!AssetDatabase.IsValidFolder("Assets/" + dbPath))
                    AssetDatabase.CreateFolder("Assets", dbPath);

                //create the database and refresh the AssetsDatabase
                db = ScriptableObject.CreateInstance<U>() as U;
                AssetDatabase.CreateAsset(db, dbFullPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }

            return db;
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
