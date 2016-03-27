using UnityEngine;
using UnityEditor;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectEditor
    {
        Vector2 _scrollPos = Vector2.zero;
        int _listViewWidth = 200;
        int _listViewButtonWidth = 190;
        int _listViewButtonHeight = 25;

        int _selectedIndex = -1;

        // new vars for new system
        Vector2 buttonSize = new Vector2(190,25);




        void ListView()
        {
            // Turn on to hide the item list on the left

//            if (state != DisplayState.NONE)
//               return;

            _scrollPos = GUILayout.BeginScrollView(_scrollPos, "Box", GUILayout.ExpandHeight(true), GUILayout.Width(_listViewWidth));

            for (int cnt = 0; cnt < database.Count; cnt++)
            {
                if (GUILayout.Button(database.Get(cnt).Name, "box", GUILayout.Width(_listViewButtonWidth), GUILayout.Height(_listViewButtonHeight)))
                {
                    _selectedIndex = cnt;
                    tempWeapon = new ISWeapon(database.Get(cnt));

                    showNewWeaponDetails = true;
                    state = DisplayState.DETAILS;
                }

            }

            GUILayout.EndScrollView();
        }
    }
}
