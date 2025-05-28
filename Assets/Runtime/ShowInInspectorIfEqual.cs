namespace ConditionalInspector
{
    /// <summary>
    /// Shows this property in the inspector if the object reference passed in is equal to the value, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfEqualAttribute : HideInInspectorIfAttribute
    {
        public string propertyName;
        public object value;

        public ShowInInspectorIfEqualAttribute(string _propertyName, object _value)
        {
            propertyName = _propertyName;
            value = _value;
        }
    }
}
