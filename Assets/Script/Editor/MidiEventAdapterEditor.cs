using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace Grubo
{
    [CustomEditor(typeof(MidiEventAdapter))]
    sealed class MidiEventAdapterEditor : Editor
    {
        #region Note/octave selector

        static readonly string [] _noteNames =
            { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        static readonly int [] _noteIndices =
            { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

        static readonly string [] _octaveNames =
            { "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static readonly int [] _octaveIndices =
            { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        void LayoutNoteOctaveSelector(string label, SerializedProperty prop)
        {
            var note = prop.intValue % 12;
            var octave = prop.intValue / 12;

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.BeginHorizontal();

            EditorGUI.indentLevel++;
            EditorGUILayout.PrefixLabel(label);
            EditorGUI.indentLevel--;

            note = EditorGUILayout.IntPopup(note, _noteNames, _noteIndices);
            octave = EditorGUILayout.IntPopup(octave, _octaveNames, _octaveIndices);

            EditorGUILayout.EndHorizontal();

            if (EditorGUI.EndChangeCheck()) prop.intValue = note + octave * 12;
        }

        #endregion

        #region Custom reorderable list implementation

        ReorderableList _vfxTargetList;
        ReorderableList _noteNumberList;

        void DrawVfxTargetListElement(Rect rect, int index, bool active, bool focused)
        {
            var prop = _vfxTargetList.serializedProperty.GetArrayElementAtIndex(index);

            rect.yMin++;
            rect.yMax--;

            EditorGUI.PropertyField(rect, prop, GUIContent.none);
        }

        void DrawNoteNumberListElement(Rect rect, int index, bool active, bool focused)
        {
            var prop = _noteNumberList.serializedProperty.GetArrayElementAtIndex(index);

            var note = prop.intValue % 12;
            var octave = prop.intValue / 12;

            rect.yMin++;
            rect.yMax--;

            EditorGUI.BeginChangeCheck();

            rect.width = rect.width / 2 - 2;
            note = EditorGUI.IntPopup(rect, note, _noteNames, _noteIndices);

            rect.x += rect.width + 2;
            octave = EditorGUI.IntPopup(rect, octave, _octaveNames, _octaveIndices);

            if (EditorGUI.EndChangeCheck()) prop.intValue = note + octave * 12;
        }

        void PrefixedReorderableList(ReorderableList list, GUIContent label)
        {
            list.DoList(
                EditorGUI.PrefixLabel(
                    EditorGUILayout.GetControlRect(true, list.GetHeight()),
                    label
                )
            );
        }

        #endregion

        #region Inspector implementation

        static class Styles
        {
            public static readonly GUIContent Empty = new GUIContent(" ");
            public static readonly GUIContent VfxTargets = new GUIContent("VFX Targets");
        }

        SerializedProperty _noteOnEvent;
        SerializedProperty _channel;
        SerializedProperty _source;
        SerializedProperty _lowestNote;
        SerializedProperty _highestNote;

        void OnEnable()
        {
            _vfxTargetList = new ReorderableList
            (
                serializedObject, serializedObject.FindProperty("_vfxTargets"),
                true, false, true, true
            )
            { drawElementCallback = DrawVfxTargetListElement, headerHeight = 3 };

            _noteNumberList = new ReorderableList
            (
                serializedObject, serializedObject.FindProperty("_noteNumbers"),
                true, false, true, true
            )
            { drawElementCallback = DrawNoteNumberListElement, headerHeight = 3 };

            _noteOnEvent = serializedObject.FindProperty("_noteOnEvent");
            _channel = serializedObject.FindProperty("_channel");
            _source = serializedObject.FindProperty("_source");
            _lowestNote = serializedObject.FindProperty("_lowestNote");
            _highestNote = serializedObject.FindProperty("_highestNote");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_noteOnEvent);

            PrefixedReorderableList(_vfxTargetList, Styles.VfxTargets);

            EditorGUILayout.PropertyField(_channel);
            EditorGUILayout.PropertyField(_source);

            var source = (MidiEventAdapter.Source)_source.enumValueIndex;

            switch (source)
            {
            case MidiEventAdapter.Source.NoteNumbers:
                PrefixedReorderableList(_noteNumberList, Styles.Empty);
                break;
            case MidiEventAdapter.Source.NoteRange:
                LayoutNoteOctaveSelector("Lowest Note", _lowestNote);
                LayoutNoteOctaveSelector("Highest Note", _highestNote);
                break;
            }

            serializedObject.ApplyModifiedProperties();
        }

        #endregion
    }
}
