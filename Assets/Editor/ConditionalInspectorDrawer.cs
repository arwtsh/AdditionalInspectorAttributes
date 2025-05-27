using System.Reflection;
using System;
using UnityEditor;
using UnityEngine;

namespace ConditionalInspector
{
    public abstract class HideInInspectorIfDrawer : PropertyDrawer
    {
        protected abstract bool IsVisible(SerializedObject serializedObject);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (IsVisible(property.serializedObject))
            {
                EditorGUI.PropertyField(position, property, label, true);
            }
            else
            {
                GUI.enabled = false;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (IsVisible(property.serializedObject))
            {
                return base.GetPropertyHeight(property, label);
            }
            else
            {
                return 0;
            }
        }
    }
}
