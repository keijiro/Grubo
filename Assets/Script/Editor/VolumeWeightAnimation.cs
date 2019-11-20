using UnityEngine;
using UnityEditor;

namespace Grubo
{
    [CustomEditor(typeof(VolumeWeightAnimation)), CanEditMultipleObjects]
    public sealed class VolumeWeightAnimationEditor : Editor
    {
        SerializedProperty _curve;
        SerializedProperty _speed;

        void OnEnable()
        {
            _curve = serializedObject.FindProperty("_curve");
            _speed = serializedObject.FindProperty("_speed");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_curve);
            EditorGUILayout.PropertyField(_speed);

            if (EditorApplication.isPlaying && GUILayout.Button("Play"))
                ((VolumeWeightAnimation)target).Play();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
