using System.Reflection;
using UnityEditor.VersionControl;
using UnityEngine;

namespace ConditionalInspector
{
    internal sealed class Utilities
    {
        internal static bool IsTypeNullable(System.Type type)
        {
            return System.Nullable.GetUnderlyingType(type) != null || !type.IsValueType;
        }

        internal static bool IsNull(object obj)
        {
            if(obj == null)
            {
                return true;
            }
            else
            {
                if(typeof(Object).IsAssignableFrom(obj.GetType()))
                {
                    return (obj as Object) == null;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
