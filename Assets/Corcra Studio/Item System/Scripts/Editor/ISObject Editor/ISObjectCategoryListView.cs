/// <summary>
/// ISObjectCategoryListView.cs
/// 3/26/2016
/// Mike Norton - Corcra Studio
/// 
/// The partial class file that holds the code to poplulate and display the ListView for the given database
/// 
/// </summary>
using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectCategory
    {
        int _selectedIndex = -1;                // -1 means we have nothing selected
        ISArmor tempArmor;                      // a temp holder for the item we are working on
        bool createNewArmor = false;            // flag to show that we are working on a new item
        bool showDetails = false;               // flag to show that we should be showing the item details
        Vector2 _scrollPos = Vector2.zero;      // the pos of the scrollbar for the ListView


        /// <summary>
        /// Lists the view.
        /// </summary>
        /// <param name="buttonSize">Button size.</param>
        /// <param name="_listViewWidth">_list view width.</param>
        public void ListView(Vector2 buttonSize, int _listViewWidth)
        {
            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int cnt = 0; cnt < Database.Count; cnt++)
            {
                if (GUILayout.Button(Database.Get(cnt).Name, "box", GUILayout.Width(buttonSize.x), GUILayout.Height(buttonSize.y)))
                {
                    _selectedIndex = cnt;
                    tempArmor = new ISArmor(Database.Get(cnt));
                    createNewArmor = true;
                    showDetails = true;
                }
            }
            GUILayout.EndScrollView();
        }

    }
}
