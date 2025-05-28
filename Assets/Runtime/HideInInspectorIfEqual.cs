namespace ConditionalInspector
{
    /// <summary>
    /// Hides this property in the inspector if the object reference passed in is equal to the value, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfEqualAttribute : HideInInspectorIfAttribute
    {
        public string propertyName;
        public object value;

        public HideInInspectorIfEqualAttribute(string _propertyName, object _value)
        {
            propertyName = _propertyName;
            value = _value;
        }
    }
}
