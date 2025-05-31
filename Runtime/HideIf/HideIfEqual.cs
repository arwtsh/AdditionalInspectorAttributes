namespace AdditionalInspectorAttributes
{
    public class HideIfEqualAttribute : HideIfAttribute
    {
        public string propertyName;
        public object value;

        public HideIfEqualAttribute(string _propertyName, object _value)
        {
            propertyName = _propertyName;
            value = _value;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the object reference passed in is equal to the value, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfEqualAttribute : HideIfEqualAttribute
    {
        public ShowInInspectorIfEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            invert = false;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the object reference passed in is not equal to the value, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfNotEqualAttribute : HideIfEqualAttribute
    {
        public ShowInInspectorIfNotEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            invert = true;
        }
    }

    /// <summary>
    /// Hides this property in the inspector if the object reference passed in is equal to the value, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfEqualAttribute : HideIfEqualAttribute
    {
        public HideInInspectorIfEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            invert = true;
        }
    }

    /// <summary>
    /// Hides this property in the inspector if the object reference passed in is not equal to the value, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfNotEqualAttribute : HideIfEqualAttribute
    {
        public HideInInspectorIfNotEqualAttribute(string _propertyName, object _value) : base(_propertyName, _value)
        {
            invert = false;
        }
    }
}
