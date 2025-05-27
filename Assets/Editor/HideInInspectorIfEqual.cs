using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ConditionalInspector
{
    /// <summary>
    /// Hides this property in the inspector if the object reference passed in is equal to the value, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfEqualAttribute : PropertyAttribute
    {
        public string propertyName;
        public object value;

        public HideInInspectorIfEqualAttribute(string _propertyName, object _value)
        {
            propertyName = _propertyName;
            value = _value;
        }
    }

    [CustomPropertyDrawer(typeof(HideInInspectorIfEqualAttribute))]
    internal class HideInInspectorIfEqualDrawer : HideInInspectorIfDrawer
    {
        protected override bool IsVisible(SerializedObject serializedObject)
        {
            HideInInspectorIfEqualAttribute conditional = (HideInInspectorIfEqualAttribute)attribute;

            if (System.String.IsNullOrEmpty(conditional.propertyName))
            {
                Debug.LogWarning("The string passed into attribute HideInInspectorIfEqual on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was null or empty.");
                return true;
            }

            if (conditional.value == null)
            {
                Debug.LogWarning("The value passed into attribute HideInInspectorIfEqual on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was null. Use HideInInspectorIfNull instead.");
                return true;
            }

            PropertyInfo propertyReference = serializedObject.targetObject.GetType().GetProperty(conditional.propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (propertyReference != null)
            {
                if (propertyReference.PropertyType != conditional.value.GetType())
                {
                    Debug.LogWarning("The property " + propertyReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + propertyReference.PropertyType.Name + " but the value to compare with was of type " + conditional.value.GetType().Name + ". " +
                        "The HideInInspectorIfEqual attribute on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return !propertyReference.GetValue(serializedObject.targetObject).Equals(conditional.value);
            }

            FieldInfo fieldReference = serializedObject.targetObject.GetType().GetField(conditional.propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldReference != null)
            {
                if (fieldReference.FieldType != conditional.value.GetType())
                {
                    Debug.LogWarning("The field " + fieldReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + fieldReference.FieldType.Name + " but the value to compare with was of type " + conditional.value.GetType().Name + ". " +
                        "The HideInInspectorIfEqual attribute on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return !fieldReference.GetValue(serializedObject.targetObject).Equals(conditional.value);
            }

            MethodInfo methodReference = serializedObject.targetObject.GetType().GetMethod(conditional.propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (methodReference != null)
            {
                if (methodReference.ReturnType != conditional.value.GetType())
                {
                    Debug.LogWarning("The method " + methodReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + methodReference.ReturnType.Name + " but the value to compare with was of type " + conditional.value.GetType().Name + ". " +
                        "The HideInInspectorIfEqual attribute on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return !methodReference.Invoke(serializedObject.targetObject, null).Equals(conditional.value);
            }

            //Failed to find the property, field, or method. Default to visible.
            Debug.LogWarning("The string passed into attribute HideInInspectorIfEqual on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " does not match any property, field, or method.");
            return true;
        }
    }
}
