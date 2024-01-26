using UnityEditor;
using UnityEngine;
using Wanderer.NSUtilities;

namespace Wanderer
{
    namespace NSEditor
    {
        [CustomEditor(typeof(StaticInstanceBootstrapper))]
        public class BootstrapperCustomDrawer : Editor
        {
            public override void OnInspectorGUI()
            {
                DrawDefaultInspector();

                if (GUILayout.Button("Settings"))
                {
                    var window = EditorWindow.GetWindow<BootstrappingOrderWindow>();
                    window.Show();
                }
            }
        }
    }
}