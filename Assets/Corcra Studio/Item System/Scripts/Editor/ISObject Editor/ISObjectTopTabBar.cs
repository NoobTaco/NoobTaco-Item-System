/// <summary>
/// ISObjectTopTabBar.cs
/// March 27, 2016
/// Mike Norton - Corcra Studio
/// 
/// The top nav bar for our editor
/// 
/// </summary>
using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        //list of different tabs for our editor window
        enum TabState
        {
            WEAPON,
            ARMOR,
            POTION,
            QUALITY
        }


        TabState tabState;  //track what tab we have selected



        /// <summary>
        /// The display format for the tab bar
        /// </summary>
        void TopTabBar()
        {
            GUILayout.BeginHorizontal("Box", GUILayout.ExpandWidth(true));
            WeaponTab();
            ArmorTab();
            PotionTab();
            QualityTab();
            GUILayout.EndHorizontal();
        }



        /// <summary>
        /// Weapons Tab
        /// </summary>
        void WeaponTab()
        {
            if (GUILayout.Button("Weapons"))
                tabState = TabState.WEAPON;
           
        }



        /// <summary>
        /// Armor Tab
        /// </summary>
        void ArmorTab()
        {
            if (GUILayout.Button("Armors"))
                tabState = TabState.ARMOR;
        }


        /// <summary>
        /// Potions Tab
        /// </summary>
        void PotionTab()
        {
            if (GUILayout.Button("Potions"))
                tabState = TabState.POTION;
        }



        /// <summary>
        /// Quality Tab
        /// </summary>
        void QualityTab()
        {
            if (GUILayout.Button("Quality"))
                tabState = TabState.QUALITY;
        }
    }
}