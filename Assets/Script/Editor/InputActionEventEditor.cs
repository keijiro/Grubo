using UnityEngine;
using UnityEditor;

namespace Grubo
{
    [CustomEditor(typeof(InputActionEvent)), CanEditMultipleObjects]
    public sealed class InputActionEventEditor : Editor
    {
        SerializedProperty _action;
        SerializedProperty _event;

        void OnEnable()
        {
            _action = serializedObject.FindProperty("_action");
            _event = serializedObject.FindProperty("_event");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_action);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(_event);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
