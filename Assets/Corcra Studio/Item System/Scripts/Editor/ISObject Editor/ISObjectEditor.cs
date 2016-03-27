/// <summary>
/// ISObjectEditor.cs
/// March 27, 2016
/// Mike Norton - Corcra Studio
/// 
/// Editor Script for interacting with the various databases created in the RPG Item System Code-A-Long Series
/// 
/// </summary>
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        //the databases that we will be using
        ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weaponDB = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>("weaponTest.asset");
        ISObjectDatabaseType<ISArmorDatabase, ISArmor> armorDB = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>("armorTest.asset");
        ISObjectDatabaseType<ISQualityDatabase, ISQuality> qualityDB = new ISObjectDatabaseType<ISQualityDatabase, ISQuality>("QualityDatabase.asset");

        Vector2 buttonSize = new Vector2(190, 25);          //Size of the buttons
        int _listViewWidth = 200;                           //Width of the listview


        /// <summary>
        /// Static method called everime the Editor Window is openned.
        /// </summary>
        [MenuItem("Corcra Studio/Database/Item System Editor %#i")]
        public static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent.text = ("Item System");
            window.Show();
        }



        /// <summary>
        /// Make sure that things are setup as soon as this Edit starts up
        /// </summary>
        void OnEnable()
        {
            weaponDB.OnEnable("Weapon");
            armorDB.OnEnable("Armor");

            tabState = TabState.QUALITY;
        }



        /// <summary>
        /// Display the GUI for the user to interact with
        /// </summary>
        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();

            switch (tabState)
            {
                case TabState.WEAPON:
                    weaponDB.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.ARMOR:
                    armorDB.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.POTION:
                    GUILayout.Label("Potion");
                    break;
                default:
                    GUILayout.Label("Quality");
                    break;
            }

            GUILayout.EndHorizontal();

            BottomStatusBar();
        }
    }
}