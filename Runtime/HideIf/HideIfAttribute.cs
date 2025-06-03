namespace AdditionalInspectorAttributes
{
    public abstract class HideIfAttribute : InvertableAttribute
    {
        //Whether or not the attribute is hide/show or disable/enable
        public bool shouldDisable;
    }
}
