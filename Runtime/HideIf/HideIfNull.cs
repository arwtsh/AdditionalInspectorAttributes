using System;

namespace AdditionalInspectorAttributes
{
    public abstract class HideIfNullAttribute : HideIfAttribute
    {
        public string propertyName;

        public HideIfNullAttribute(string _propertyName)
        {
            propertyName = _propertyName;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the object passed in is null, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfNullAttribute : HideIfNullAttribute
    {
        public ShowInInspectorIfNullAttribute(string _propertyName) : base(_propertyName)
        {
            invert = false;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the object passed in is not null, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfNotNullAttribute : HideIfNullAttribute
    {
        public ShowInInspectorIfNotNullAttribute(string _propertyName) : base(_propertyName)
        {
            invert = true;
        }
    }

    /// <summary>
    /// Hides this property in the inspector if the object passed in is null, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfNullAttribute : HideIfNullAttribute
    {
        public HideInInspectorIfNullAttribute(string _propertyName) : base(_propertyName)
        {
            invert = true;
        }
    }

    /// <summary>
    /// Hides this property in the inspector if the object passed in is not null, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfNotNullAttribute : HideIfNullAttribute
    {
        public HideInInspectorIfNotNullAttribute(string _propertyName) : base(_propertyName)
        {
            invert = false;
        }
    }
}
