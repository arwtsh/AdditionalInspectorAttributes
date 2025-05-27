using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ConditionalInspector
{
    /// <summary>
    /// Hides this property in the inspector if the boolean passed in is false, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfFalseAttribute : PropertyAttribute
    {
        public string boolPropertyName;

        public HideInInspectorIfFalseAttribute(string _boolPropertyName)
        {
            boolPropertyName = _boolPropertyName;
        }
    }

    [CustomPropertyDrawer(typeof(HideInInspectorIfFalseAttribute))]
    internal class HideInInspectorIfFalseDrawer : HideInInspectorIfDrawer
    {
        protected override bool IsVisible(SerializedObject serializedObject)
        {
            HideInInspectorIfFalseAttribute conditional = (HideInInspectorIfFalseAttribute)attribute;

            if (System.String.IsNullOrEmpty(conditional.boolPropertyName))
            {
                Debug.LogWarning("The string passed into attribute HideInInspectorIfFalse on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was null or empty.");
                return true;
            }

            PropertyInfo propertyReference = serializedObject.targetObject.GetType().GetProperty(conditional.boolPropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (propertyReference != null)
            {
                if (propertyReference.PropertyType != typeof(bool))
                {
                    Debug.LogWarning("The property " + propertyReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + propertyReference.PropertyType.Name + " instead of bool. " +
                        "The HideInInspectorIfFalse attribute on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return (bool)propertyReference.GetValue(serializedObject.targetObject);
            }

            FieldInfo fieldReference = serializedObject.targetObject.GetType().GetField(conditional.boolPropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldReference != null)
            {
                if(fieldReference.FieldType != typeof(bool))
                {
                    Debug.LogWarning("The field " + fieldReference.Name + " in type " + fieldInfo.DeclaringType + " is type " + fieldReference.FieldType.Name + " instead of bool. " +
                        "The HideInInspectorIfFalse attribute on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return (bool)fieldReference.GetValue(serializedObject.targetObject);
            }

            MethodInfo methodReference = serializedObject.targetObject.GetType().GetMethod(conditional.boolPropertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (methodReference != null)
            {
                if (methodReference.ReturnType != typeof(bool))
                {
                    Debug.LogWarning("The method " + methodReference.Name + " in type " + fieldInfo.DeclaringType + " has a return value of type " + methodReference.ReturnType.Name + " instead of bool. " +
                        "The HideInInspectorIfFalse attribute on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " was unable to be parsed.");
                    return true;
                }

                return (bool)methodReference.Invoke(serializedObject.targetObject, null);
            }

            //Failed to find the property, field, or method. Default to visible.
            Debug.LogWarning("The string passed into attribute HideInInspectorIfFalse on property " + fieldInfo.Name + " in type " + fieldInfo.DeclaringType + " does not match any property, field, or method.");
            return true;
        }
    }
}
