/// <summary>
/// ISObjectCatergoryDetails.cs
/// 3/26/2016
/// Mike Norton - Corcra Studio
/// 
/// The partial class file that holds the code for displaying the Details of the current item that we have active
/// 
/// </summary>

using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        string strItemType = "Armor";

        public void ItemDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));


            GUILayout.EndVertical();

            GUILayout.Space(50);
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            DisplayButtons();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();


        }


        void DisplayButtons()
        {
            if (showDetails)
            {
                SaveButton();
                CancelButton();
            }
            else
            {
                CreateItemButton();
            }
        }
        void CreateItemButton()
        {
            if (GUILayout.Button("Create " + strItemType))
            {
                tempArmor = new ISArmor();
                showDetails = true;
                createNewArmor = true;
            }
        }


        void SaveButton()
        {
            GUI.SetNextControlName("SaveButton");
            if (GUILayout.Button("Save"))
            {
                showDetails = false;
                createNewArmor = false;
                _selectedIndex = -1;

                //save item
                tempArmor = null;
            }
        }


        void CancelButton()
        {
            if (GUILayout.Button("Cancel"))
            {
                tempArmor = null;
                showDetails = false;
                createNewArmor = false;
                _selectedIndex = -1;
                GUI.FocusControl("SaveButton");
            }
        }


        void DeleteButton()
        {

        }
    }
}
