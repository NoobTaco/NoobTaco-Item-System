/// <summary>
/// ISObjectCategory.cs
/// Mar 27, 2016
/// Mike Norton - Corcra Studio
/// 
/// The partial class file that holds all of the generic variables and methods for the rest of the class.
/// 
/// </summary>
using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        protected ISArmorDatabase Database { get; set; }            // the database we are going to work with
        protected string DatabaseName { get; set; }                 // the name of the database

        const string DATABASE_PATH = @"Database";                   //The path to the databases


        /// <summary>
        /// Initializes a new instance of the <see cref="CorcraStudio.ItemSystem.Editor.ISObjectCategory"/> class.
        /// </summary>
        public ISObjectCategory()
        {
            DatabaseName = @"csArmorDatabase.asset";
        }



        /// <summary>
        /// Gets the full path to the database.
        /// </summary>
        /// <value> The database full path. </value>
        public string DatabaseFullPath
        {
            get { return @"Assets/" + DATABASE_PATH + "/" + DatabaseName; }
        }


        /// <summary>
        /// Raises the enable event
        /// Call this from a Unity OnEnable() method so this class is ready to go.
        /// </summary>
        public void OnEnable()
        {
            if (Database == null)
                Database = ISArmorDatabase.GetDatabase<ISArmorDatabase>(DATABASE_PATH, DatabaseName);
        }



        public void OnGUI(Vector2 buttonSize, int _listViewWidth)
        {
            ListView(buttonSize, _listViewWidth);
            ItemDetails();
        }
    }
}
