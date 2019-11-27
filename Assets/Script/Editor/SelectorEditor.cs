using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace Grubo
{
    [CustomEditor(typeof(Selector))]
    sealed class SelectorEditor : Editor
    {
        ReorderableList _pairList;
        SerializedProperty _randomizeKey;

        void DrawPairListHeader(Rect rect)
        {
            rect.x += ReorderableList.Defaults.dragHandleWidth;
            rect.width -= ReorderableList.Defaults.dragHandleWidth;

            rect.width = rect.width / 2 - 2;
            EditorGUI.LabelField(rect, "Target");

            rect.x += rect.width + 2;
            EditorGUI.LabelField(rect, "Key");
        }

        void DrawPairListElement(Rect rect, int index, bool active, bool focused)
        {
            var prop = _pairList.serializedProperty.GetArrayElementAtIndex(index);

            rect.yMin++;
            rect.yMax--;

            rect.width = rect.width / 2 - 2;
            EditorGUI.PropertyField(rect, prop.FindPropertyRelative("target"), GUIContent.none);

            rect.x += rect.width + 2;
            EditorGUI.PropertyField(rect, prop.FindPropertyRelative("key"), GUIContent.none);
        }

        void OnEnable()
        {
            _pairList = new ReorderableList
            (
                serializedObject, serializedObject.FindProperty("_pairs"),
                true, false, true, true
            )
            {
                drawHeaderCallback = DrawPairListHeader,
                drawElementCallback = DrawPairListElement
            };

            _randomizeKey = serializedObject.FindProperty("_randomizeKey");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            _pairList.DoLayoutList();
            EditorGUILayout.PropertyField(_randomizeKey);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
