using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(MyButton))]
    public class MyUIButtonEditor : ButtonEditor
    {
        public override void OnInspectorGUI()
        {
            MyButton targetMyButton = (MyButton)target;

            //targetMyButton.buttonIsPressed = (bool)EditorGUILayout.ObjectField("Button is pressed:", targetMyButton.buttonIsPressed, typeof(bool), true);

            base.OnInspectorGUI();
        }
    }
}
