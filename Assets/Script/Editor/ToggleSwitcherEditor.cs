using UnityEngine;
using UnityEditor;

namespace Grubo
{
    [CustomEditor(typeof(ToggleSwitcher)), CanEditMultipleObjects]
    public sealed class ToggleSwitcherEditor : Editor
    {
        SerializedProperty _targetType;
        SerializedProperty _targetGameObject;
        SerializedProperty _targetBehaviour;
        SerializedProperty _toggleKey;

        static class Styles
        {
            public readonly static GUIContent Target = new GUIContent("Target");
        }

        void OnEnable()
        {
            _targetType = serializedObject.FindProperty("_targetType");
            _targetGameObject = serializedObject.FindProperty("_targetGameObject");
            _targetBehaviour = serializedObject.FindProperty("_targetBehaviour");
            _toggleKey = serializedObject.FindProperty("_toggleKey");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_targetType);

            var showAll = _targetType.hasMultipleDifferentValues;
            var type = (ToggleSwitcher.TargetType)_targetType.enumValueIndex;

            if (showAll || type == ToggleSwitcher.TargetType.GameObject)
                EditorGUILayout.PropertyField(_targetGameObject, Styles.Target);

            if (showAll || type == ToggleSwitcher.TargetType.Behaviour)
                EditorGUILayout.PropertyField(_targetBehaviour, Styles.Target);

            EditorGUILayout.PropertyField(_toggleKey);

            if (EditorApplication.isPlaying && GUILayout.Button("Toggle"))
                ((ToggleSwitcher)target).Toggle();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
