using System.ComponentModel;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AdditionalInspectorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(HideIfPlayAttribute), true)]
    internal class HideIfPlayDrawer : HideIfDrawer
    {
        //Instead of calling IsVisible every few frames, use a callback system (because that's possible for this attribute)
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            HideIfPlayAttribute inverter = (HideIfPlayAttribute)attribute;
            HideOnPlayPropertyField content = new HideOnPlayPropertyField(property, inverter);

            content.style.display = inverter.ApplyInvert(!Application.isPlaying) ? DisplayStyle.Flex : DisplayStyle.None;

            content.RegisterCallback<AttachToPanelEvent>(args => EditorApplication.playModeStateChanged += content.TogglePlayMode);
            content.RegisterCallback<DetachFromPanelEvent>(args => EditorApplication.playModeStateChanged -= content.TogglePlayMode);
            return content;
        }

        private class HideOnPlayPropertyField : PropertyField
        {
            HideIfPlayAttribute inverter;

            public HideOnPlayPropertyField(SerializedProperty property, HideIfPlayAttribute invertHandler) : base(property) { inverter = invertHandler;}

            internal void TogglePlayMode(PlayModeStateChange args)
            {
                style.display = inverter.ApplyInvert(args == PlayModeStateChange.EnteredEditMode) ? DisplayStyle.Flex : DisplayStyle.None;
            }
        }

        //protected override bool IsVisible(SerializedObject serializedObject)
        //{
        //    HideIfBoolAttribute conditional = (HideIfBoolAttribute)attribute;

        //    if (System.String.IsNullOrEmpty(conditional.boolPropertyName))
        //    {
        //        Debug.LogWarning("The string passed into " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was null or empty.");
        //        return true;
        //    }

        //    PropertyInfo propertyReference = serializedObject.targetObject.GetType().GetProperty(conditional.boolPropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        //    if (propertyReference != null)
        //    {
        //        if (propertyReference.PropertyType != typeof(bool))
        //        {
        //            Debug.LogWarning("The property " + propertyReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + propertyReference.PropertyType.Name + " instead of bool. " +
        //                "The " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
        //            return true;
        //        }

        //        return conditional.ApplyInvert((bool)propertyReference.GetValue(serializedObject.targetObject));
        //    }

        //    FieldInfo fieldReference = serializedObject.targetObject.GetType().GetField(conditional.boolPropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        //    if (fieldReference != null)
        //    {
        //        if (fieldReference.FieldType != typeof(bool))
        //        {
        //            Debug.LogWarning("The field " + fieldReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + fieldReference.FieldType.Name + " instead of bool. " +
        //                "The " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
        //            return true;
        //        }

        //        return conditional.ApplyInvert((bool)fieldReference.GetValue(serializedObject.targetObject));
        //    }

        //    MethodInfo methodReference = serializedObject.targetObject.GetType().GetMethod(conditional.boolPropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        //    if (methodReference != null)
        //    {
        //        if (methodReference.ReturnType != typeof(bool))
        //        {
        //            Debug.LogWarning("The method " + methodReference.Name + " in type " + fieldInfo.DeclaringType + " has a return value of type " + methodReference.ReturnType.Name + " instead of bool. " +
        //                "The " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
        //            return true;
        //        }

        //        return conditional.ApplyInvert((bool)methodReference.Invoke(serializedObject.targetObject, null));
        //    }

        //    //Failed to find the property, field, or method. Default to visible.
        //    Debug.LogWarning("The string passed into " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " does not match any property, field, or method.");
        //    return true;
        //}
    }
}
