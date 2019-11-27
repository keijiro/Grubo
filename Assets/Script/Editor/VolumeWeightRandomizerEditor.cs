using UnityEngine;
using UnityEditor;

namespace Grubo
{
    [CustomEditor(typeof(VolumeWeightRandomizer)), CanEditMultipleObjects]
    public sealed class VolumeWeightRandomizerEditor : Editor
    {
        SerializedProperty _randomizeKey;
        SerializedProperty _resetKey;

        void OnEnable()
        {
            _randomizeKey = serializedObject.FindProperty("_randomizeKey");
            _resetKey = serializedObject.FindProperty("_resetKey");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_randomizeKey);
            EditorGUILayout.PropertyField(_resetKey);

            if (EditorApplication.isPlaying && GUILayout.Button("Randomize"))
                ((VolumeWeightRandomizer)target).Randomize();

            if (EditorApplication.isPlaying && GUILayout.Button("Reset"))
                ((VolumeWeightRandomizer)target).SetWeight(0);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
