namespace ConditionalInspector
{
    /// <summary>
    /// Shows this property in the inspector if the object passed in is null, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfNullAttribute : HideInInspectorIfAttribute
    {
        public string propertyName;

        public ShowInInspectorIfNullAttribute(string _propertyName)
        {
            propertyName = _propertyName;
        }
    }
}
