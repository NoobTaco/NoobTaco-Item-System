using UnityEditor;
using UnityEngine;
using System.Collections;

namespace CorcraStudio.ItemSystem.Editor
{
    public partial class ISObjectEditor : EditorWindow
    {
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

        }


        void OnGUI()
        {
            TopTabBar();

            GUILayout.BeginHorizontal();
            ListView();
            ItemDetails();
            GUILayout.EndHorizontal();

            BottomStatusBar();
        }
    }
}