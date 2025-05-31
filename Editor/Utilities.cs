using UnityEngine;

namespace AdditionalInspectorAttributes.Editor
{
    internal sealed class Utilities
    {
        internal static bool IsTypeNullable(System.Type type)
        {
            return System.Nullable.GetUnderlyingType(type) != null || !type.IsValueType;
        }

        // Checks for Unity Object null in additional to null references.
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
