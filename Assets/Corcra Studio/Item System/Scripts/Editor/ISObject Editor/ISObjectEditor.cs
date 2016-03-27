using UnityEditor;
using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
        ISWeaponDatabase database;
 //       ISObjectCategory armorDatabase = new ISObjectCategory();

        //ISObjectDatabaseType<ISWeaponDatabase, ISWeapon> weapondbt = new ISObjectDatabaseType<ISWeaponDatabase, ISWeapon>("weaponTest.asset");
        //ISObjectDatabaseType<ISArmorDatabase, ISArmor> armordbt = new ISObjectDatabaseType<ISArmorDatabase, ISArmor>("armorTest.asset");

        const string DATABASE_NAME = @"csWeaponDatabase.asset";
        const string DATABASE_PATH = @"Database";
        const string DATABASE_FULL_PATH = @"Assets/" + DATABASE_PATH + "/" + DATABASE_NAME;


        [MenuItem("Corcra Studio/Database/Item System Editor %#i")]
        public static void Init()
        {
            ISObjectEditor window = EditorWindow.GetWindow<ISObjectEditor>();
            window.minSize = new Vector2(800, 600);
            window.titleContent.text = ("Item System");
            window.Show();
        }


        void OnEnable()
        {
            if (database == null)
                database = ISWeaponDatabase.GetDatabase<ISWeaponDatabase>(DATABASE_PATH, DATABASE_NAME);

    //        armorDatabase.OnEnable();

            //weapondbt.OnEnable();
            //armordbt.OnEnable();

            tabState = TabState.WEAPON;

        }


        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();

            switch (tabState)
            {
                case TabState.WEAPON:
                    ListView();
                    ItemDetails();
                    break;
                case TabState.ARMOR:
 //                   armorDatabase.OnGUI(buttonSize, _listViewWidth);
                    break;
                case TabState.POTION:
                    GUILayout.Label("Potion");
                    break;
                default:
                    GUILayout.Label("Default State About");
                    break;

            }


            GUILayout.EndHorizontal();

            BottomStatusBar();
        }
    }
}