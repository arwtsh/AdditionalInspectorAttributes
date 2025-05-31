namespace AdditionalInspectorAttributes
{
    // Base class for all attributes used in this package
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public abstract class InspectorAttribute : UnityEngine.PropertyAttribute
    {

    }
}
