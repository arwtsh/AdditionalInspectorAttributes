namespace ConditionalInspector
{
    /// <summary>
    /// Hides this property in the inspector if the object passed in is null, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfNullAttribute : HideInInspectorIfAttribute
    {
        public string propertyName;

        public HideInInspectorIfNullAttribute(string _propertyName)
        {
            propertyName = _propertyName;
        }
    }
}
