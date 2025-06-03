using UnityEngine;

namespace AdditionalInspectorAttributes
{
    /// <summary>
    /// Disables this property in the inspector if the boolean passed in is true, otherwise it enables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class DisableInInspectorIfTrueAttribute : HideInInspectorIfTrueAttribute
    {
        public DisableInInspectorIfTrueAttribute(string _boolPropertyName) : base(_boolPropertyName) 
        { 
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Enables this property in the inspector if the boolean passed in is true, otherwise it disables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class EnableInInspectorIfTrueAttribute : ShowInInspectorIfTrueAttribute
    {
        public EnableInInspectorIfTrueAttribute(string _boolPropertyName) : base(_boolPropertyName)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Disables this property in the inspector if the boolean passed in is false, otherwise it enables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class DisableInInspectorIfFalseAttribute : HideInInspectorIfFalseAttribute
    {
        public DisableInInspectorIfFalseAttribute(string _boolPropertyName) : base(_boolPropertyName)
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Enables this property in the inspector if the boolean passed in is false, otherwise it disables it.
    /// IMPORTANT: You pass in the NAME of the variable. You can pass in a field, property, or method. They don't have to be serialized.
    /// </summary>
    public class EnableInInspectorIfFalseAttribute : ShowInInspectorIfFalseAttribute
    {
        public EnableInInspectorIfFalseAttribute(string _boolPropertyName) : base(_boolPropertyName)
        {
            shouldDisable = true;
        }
    }
}
