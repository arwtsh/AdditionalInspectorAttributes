namespace ConditionalInspector
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public abstract class HideInInspectorIfAttribute : UnityEngine.PropertyAttribute
    {
    
    }
}
