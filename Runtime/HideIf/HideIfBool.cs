namespace AdditionalInspectorAttributes
{
    public abstract class HideIfBoolAttribute : HideIfAttribute
    {
        public string boolPropertyName;

        public HideIfBoolAttribute(string _boolPropertyName)
        {
            boolPropertyName = _boolPropertyName;
        }
    }

    /// <summary>
    /// Hides this property in the inspector if the boolean passed in is true, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfTrueAttribute : HideIfBoolAttribute
    {
        public HideInInspectorIfTrueAttribute(string _boolPropertyName) : base(_boolPropertyName) 
        { 
            invert = true;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the boolean passed in is true, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfTrueAttribute : HideIfBoolAttribute
    {
        public ShowInInspectorIfTrueAttribute(string _boolPropertyName) : base(_boolPropertyName)
        {
            invert = false;
        }
    }

    /// <summary>
    /// Hides this property in the inspector if the boolean passed in is false, otherwise it shows it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class HideInInspectorIfFalseAttribute : HideIfBoolAttribute
    {
        public HideInInspectorIfFalseAttribute(string _boolPropertyName) : base(_boolPropertyName)
        {
            invert = false;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the boolean passed in is false, otherwise it hides it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class ShowInInspectorIfFalseAttribute : HideIfBoolAttribute
    {
        public ShowInInspectorIfFalseAttribute(string _boolPropertyName) : base(_boolPropertyName)
        {
            invert = true;
        }
    }
}
