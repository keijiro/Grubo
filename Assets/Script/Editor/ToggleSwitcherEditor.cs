using UnityEngine;
using UnityEditor;

namespace Grubo
{
    [CustomEditor(typeof(ToggleSwitcher)), CanEditMultipleObjects]
    public sealed class ToggleSwitcherEditor : Editor
    {
        SerializedProperty _target;
        SerializedProperty _key;

        void OnEnable()
        {
            _target = serializedObject.FindProperty("_target");
            _key = serializedObject.FindProperty("_key");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_target);
            EditorGUILayout.PropertyField(_key);

            if (EditorApplication.isPlaying && GUILayout.Button("Toggle"))
                ((ToggleSwitcher)target).Toggle();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
