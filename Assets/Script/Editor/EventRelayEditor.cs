using UnityEngine;
using UnityEditor;

namespace Grubo
{
    [CustomEditor(typeof(EventRelay)), CanEditMultipleObjects]
    public sealed class EventRelayEditor : Editor
    {
        SerializedProperty _probability;
        SerializedProperty _divisor;
        SerializedProperty _event;

        void OnEnable()
        {
            _probability = serializedObject.FindProperty("_probability");
            _divisor = serializedObject.FindProperty("_divisor");
            _event = serializedObject.FindProperty("_event");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_probability);
            EditorGUILayout.PropertyField(_divisor);
            EditorGUILayout.PropertyField(_event);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
