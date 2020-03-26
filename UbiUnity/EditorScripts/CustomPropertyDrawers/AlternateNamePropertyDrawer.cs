using UnityEngine;
using UnityEditor;
using System.Collections;

/// <summary>
/// A class that replaces the name of a property (e.g. "element X" if
/// it's in an array) with a custom one. Override the "GetName" method
/// to set the way in which the name is determined.
/// </summary>
public abstract class AlternateNamePropertyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label);
    }
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(rect, label, property);

        string name = GetName(property);
        EditorGUI.PropertyField(rect, property, new GUIContent(name), true);

        EditorGUI.EndProperty();
    }
    protected abstract string GetName(SerializedProperty property);
}