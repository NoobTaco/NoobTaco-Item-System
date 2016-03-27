/// <summary>
/// ScriptableObjectDatabase.cs
/// March 27, 2016
/// Mike Norton - Corcra Studio
/// 
/// Generic database that will store items to a ScriptableObject. ScriptibalObjects can be read from at runtime,
/// but not writen or added too. They are immutable
/// 
/// This class will be split in two at a later date. The new class will be ScriptableObjectDatabaseEditor<T>.
/// This new class will be responsible for all of the editor functions so that the base class is lean and clean
/// for runtime.
/// 
/// </summary>
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace CorcraStudio
{
    public class ScriptableObjectDatabase<T> : ScriptableObject where T : class
    {
        [SerializeField]
        protected List<T> database = new List<T>();

#if UNITY_EDITOR
        /// <summary>
        /// Add an item to the database
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            database.Add(item);
            EditorUtility.SetDirty(this);
        }



        /// <summary>
        /// Insert an Item at the specified index
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Insert(int index, T item)
        {
            database.Insert(index, item);
            EditorUtility.SetDirty(this);

        }
        


        /// <summary>
        /// Remove an Item.
        /// </summary>
        /// <param name="item">Item.</param>
        public void Remove(T item)
        {
            database.Remove(item);
            EditorUtility.SetDirty(this);

        }



        /// <summary>
        /// Remove the Item at a specified index.
        /// </summary>
        /// <param name="index">Item.</param>
        public void Remove(int index)
        {
            database.RemoveAt(index);
            EditorUtility.SetDirty(this);

        }
#endif



        /// <summary>
        /// Get the number of items in the database
        /// </summary>
        /// <value>The count.</value>
        public int Count
        {
            get { return database.Count; }
        }



        /// <summary>
        /// Get the item at the specified index
        /// </summary>
        /// <param name="index">Index.</param>
        public T Get(int index)
        {
            return database.ElementAt(index);
        }



#if UNITY_EDITOR
        /// <summary>
        /// Replace the item at the specified index with this new one.
        /// </summary>
        /// <param name="index">Index.</param>
        /// <param name="item">Item.</param>
        public void Replace(int index, T item)
        {
            database[index] = item;
            EditorUtility.SetDirty(this);
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
#endif

    }
}