using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace AdditionalInspectorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(HideIfEqualAttribute), true)]
    internal class HideIfEqualDrawer : HideIfDrawer
    {
        protected override bool IsVisible(SerializedObject serializedObject)
        {
            HideIfEqualAttribute conditional = (HideIfEqualAttribute)attribute;

            if (System.String.IsNullOrEmpty(conditional.propertyName))
            {
                Debug.LogWarning("The string passed into " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was null or empty.");
                return true;
            }

            if (conditional.value == null)
            {
                Debug.LogWarning("The value passed into " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was null. Use a null check instead.");
                return true;
            }

            PropertyInfo propertyReference = serializedObject.targetObject.GetType().GetProperty(conditional.propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (propertyReference != null)
            {
                if (propertyReference.PropertyType != conditional.value.GetType())
                {
                    Debug.LogWarning("The property " + propertyReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + propertyReference.PropertyType.Name + " but the value to compare with was of type " + conditional.value.GetType().Name + ". " +
                        "The " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return conditional.ApplyInvert(propertyReference.GetValue(serializedObject.targetObject).Equals(conditional.value));
            }

            FieldInfo fieldReference = serializedObject.targetObject.GetType().GetField(conditional.propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldReference != null)
            {
                if (fieldReference.FieldType != conditional.value.GetType())
                {
                    Debug.LogWarning("The field " + fieldReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + fieldReference.FieldType.Name + " but the value to compare with was of type " + conditional.value.GetType().Name + ". " +
                        "The " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return conditional.ApplyInvert(fieldReference.GetValue(serializedObject.targetObject).Equals(conditional.value));
            }

            MethodInfo methodReference = serializedObject.targetObject.GetType().GetMethod(conditional.propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (methodReference != null)
            {
                if (methodReference.ReturnType != conditional.value.GetType())
                {
                    Debug.LogWarning("The method " + methodReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + methodReference.ReturnType.Name + " but the value to compare with was of type " + conditional.value.GetType().Name + ". " +
                        "The " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return conditional.ApplyInvert(methodReference.Invoke(serializedObject.targetObject, null).Equals(conditional.value));
            }

            //Failed to find the property, field, or method. Default to visible.
            Debug.LogWarning("The string passed into " + conditional.GetType().Name + " on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " does not match any property, field, or method.");
            return true;
        }
    }
}
