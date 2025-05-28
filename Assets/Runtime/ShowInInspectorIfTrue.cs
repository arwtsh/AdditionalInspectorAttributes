namespace ConditionalInspector
{
    /// <summary>
    /// Shows this property in the inspector if the boolean passed in is true, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfTrueAttribute : HideInInspectorIfAttribute
    {
        public string boolPropertyName;

        public ShowInInspectorIfTrueAttribute(string _boolPropertyName)
        {
            boolPropertyName = _boolPropertyName;
        }
    }
}
