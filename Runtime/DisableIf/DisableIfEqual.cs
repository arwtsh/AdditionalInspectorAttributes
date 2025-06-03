namespace AdditionalInspectorAttributes
{
    /// <summary>
    /// Enables this property in the inspector if the object reference passed in is equal to the value, otherwise it disables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class EnableInInspectorIfEqualAttribute : ShowInInspectorIfEqualAttribute
    {
        public EnableInInspectorIfEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Enables this property in the inspector if the object reference passed in is not equal to the value, otherwise it disables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class EnableInInspectorIfNotEqualAttribute : ShowInInspectorIfNotEqualAttribute
    {
        public EnableInInspectorIfNotEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Disables this property in the inspector if the object reference passed in is equal to the value, otherwise it enables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class DisableInInspectorIfEqualAttribute : HideInInspectorIfEqualAttribute
    {
        public DisableInInspectorIfEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Disables this property in the inspector if the object reference passed in is not equal to the value, otherwise it enables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class DisableInInspectorIfNotEqualAttribute : HideInInspectorIfEqualAttribute
    {
        public DisableInInspectorIfNotEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            shouldDisable = true;
        }
    }
}
