using System;

namespace AdditionalInspectorAttributes
{
    /// <summary>
    /// Enables this property in the inspector if the object passed in is null, otherwise it disables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class EnableInInspectorIfNullAttribute : ShowInInspectorIfNullAttribute
    {
        public EnableInInspectorIfNullAttribute(string _propertyName) : base(_propertyName)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Enables this property in the inspector if the object passed in is not null, otherwise it disables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class EnableInInspectorIfNotNullAttribute : ShowInInspectorIfNotNullAttribute
    {
        public EnableInInspectorIfNotNullAttribute(string _propertyName) : base(_propertyName)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Disables this property in the inspector if the object passed in is null, otherwise it enables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class DisableInInspectorIfNullAttribute : HideInInspectorIfNullAttribute
    {
        public DisableInInspectorIfNullAttribute(string _propertyName) : base(_propertyName)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Disables this property in the inspector if the object passed in is not null, otherwise it enables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class DisableInInspectorIfNotNullAttribute : HideInInspectorIfNotNullAttribute
    {
        public DisableInInspectorIfNotNullAttribute(string _propertyName) : base(_propertyName)
        {
            shouldDisable = true;
        }
    }
}
