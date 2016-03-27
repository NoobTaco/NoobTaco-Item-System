/// <summary>
/// ISObjectCatergoryDetails.cs
/// 3/26/2016
/// Mike Norton - Corcra Studio
/// 
/// The partial class file that holds the code for displaying the Details of the current item that we have active
/// 
/// </summary>

using UnityEngine;
using UnityEditor;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectDatabaseType<D, T> where D : ScriptableObjectDatabase<T> where T : ISObject, new()
    {
        /// <summary>
        /// Display the details of the selected Item
        /// </summary>
        public void ItemDetails()
        {
            GUILayout.BeginVertical("Box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));
            GUILayout.BeginVertical(GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(true));

            if (showDetails)
                tItem.OnGUI();

            GUILayout.EndVertical();

            GUILayout.Space(50);
            GUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
            DisplayButtons();
            GUILayout.EndHorizontal();
            GUILayout.EndVertical();
        }



        /// <summary>
        /// Displays the buttons at the bottom of the panel
        /// </summary>
        void DisplayButtons()
        {
            if (showDetails)
            {
                ButtonSave();

                if (_selectedIndex > -1)
                    ButtonDelete();

                ButtonCancel();
            }
            else
            {
                ButtonCreate();
            }
        }



        /// <summary>
        /// Button for Creating an item
        /// </summary>
        void ButtonCreate()
        {
            if (GUILayout.Button("Create " + strItemType))
            {
                tItem = new T();
                showDetails = true;
            }
        }



        /// <summary>
        /// Button for Saving an item
        /// </summary>
        void ButtonSave()
        {
            GUI.SetNextControlName("SaveButton");
            if (GUILayout.Button("Save"))
            {
                //save item
                if (_selectedIndex == -1)
                    Add(tItem);
                else
                    Replace(_selectedIndex, tItem);

                showDetails = false;
                _selectedIndex = -1;
                tItem = null;
                GUI.FocusControl("SaveButton");
            }
        }



        /// <summary>
        /// Button to cancel the item edit or save
        /// </summary>
        void ButtonCancel()
        {
            if (GUILayout.Button("Cancel"))
            {
                tItem = null;
                showDetails = false;
                _selectedIndex = -1;
                GUI.FocusControl("SaveButton");
            }
        }



        /// <summary>
        /// Button to delete the item from the database
        /// </summary>
        void ButtonDelete()
        {
            if (GUILayout.Button("Delete"))
            {
                if (EditorUtility.DisplayDialog("Delete " + tItem.Name, "Are you sure that you want to delete this item from the database?", "Delete", "Cancel"))
                {
                    Remove(_selectedIndex);

                    showDetails = false;
                    tItem = null;
                    _selectedIndex = -1;
                    GUI.FocusControl("SaveButton");
                }
            }
        }
    }
}
