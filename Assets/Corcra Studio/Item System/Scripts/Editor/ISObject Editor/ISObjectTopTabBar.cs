using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        enum TabState
        {
            WEAPON,
            ARMOR,
            POTION,
            ABOUT
        }


        TabState tabState;

        void TopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));

            WeaponTab();
            ArmorTab();
            PotionTab();
            AboutTab();

            GUILayout.EndHorizontal();

        }

        void WeaponTab()
        {
            if (GUILayout.Button("Weapons"))
                tabState = TabState.WEAPON;
           
        }


        void ArmorTab()
        {
            if (GUILayout.Button("Armors"))
                tabState = TabState.ARMOR;
        }


        void PotionTab()
        {
            if (GUILayout.Button("Potions"))
                tabState = TabState.POTION;
        }


        void AboutTab()
        {
            if (GUILayout.Button("About"))
                tabState = TabState.ABOUT;
        }
    }
}