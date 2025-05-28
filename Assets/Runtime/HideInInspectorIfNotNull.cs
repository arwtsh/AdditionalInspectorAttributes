namespace ConditionalInspector
{
    /// <summary>
    /// Hides this property in the inspector if the object passed in is not null, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfNotNullAttribute : HideInInspectorIfAttribute
    {
        public string propertyName;

        public HideInInspectorIfNotNullAttribute(string _propertyName)
        {
            propertyName = _propertyName;
        }
    }
}
