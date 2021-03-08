using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Knowledge))]
public class KnowledgeEditor : Editor
{
    private ReorderableList list;

    public void OnEnable()
    {
        // Create Inspector List
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("entries"), true, true, true, true);

        // Title
        list.drawHeaderCallback = (Rect rect) => {
            EditorGUI.LabelField(rect, "Custom Knowledge");
        };

        // Place elements
        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, 180, EditorGUIUtility.singleLineHeight), element, GUIContent.none);
            //EditorGUI.PropertyField(new Rect(rect.x + 70, rect.y, 160, EditorGUIUtility.singleLineHeight),
            //    element.FindPropertyRelative("type"), GUIContent.none);
        };

        list.onAddCallback = (ReorderableList list) =>
        {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;

            // Important! When adding a new element to the list (and dictionary),
            // the newly created key must be unique.
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            element/*.FindPropertyRelative("key")*/.stringValue = System.Guid.NewGuid().ToString();
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}
