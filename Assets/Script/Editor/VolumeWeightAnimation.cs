using UnityEngine;
using UnityEditor;

namespace Grubo
{
    [CustomEditor(typeof(VolumeWeightAnimation)), CanEditMultipleObjects]
    public sealed class VolumeWeightAnimationEditor : Editor
    {
        SerializedProperty _curve;
        SerializedProperty _speed;
        SerializedProperty _playKey;

        void OnEnable()
        {
            _curve = serializedObject.FindProperty("_curve");
            _speed = serializedObject.FindProperty("_speed");
            _playKey = serializedObject.FindProperty("_playKey");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_curve);
            EditorGUILayout.PropertyField(_speed);
            EditorGUILayout.PropertyField(_playKey);

            if (EditorApplication.isPlaying && GUILayout.Button("Play"))
                ((VolumeWeightAnimation)target).Play();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
