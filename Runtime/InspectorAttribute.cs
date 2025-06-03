namespace AdditionalInspectorAttributes
{
    // Base class for all attributes used in this package
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public abstract class InspectorAttribute : UnityEngine.PropertyAttribute
    {
        //Lets the attributes in this package apply to lists. Otherwise, lists would look weird.
        public InspectorAttribute() : base(applyToCollection: true) { }
    }
}
