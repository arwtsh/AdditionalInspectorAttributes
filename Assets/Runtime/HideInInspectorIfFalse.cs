namespace ConditionalInspector
{
    /// <summary>
    /// Hides this property in the inspector if the boolean passed in is false, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfFalseAttribute : HideInInspectorIfAttribute
    {
        public string boolPropertyName;

        public HideInInspectorIfFalseAttribute(string _boolPropertyName)
        {
            boolPropertyName = _boolPropertyName;
        }
    }
}
