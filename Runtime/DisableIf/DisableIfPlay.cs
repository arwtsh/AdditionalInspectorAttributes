namespace AdditionalInspectorAttributes
{
    /// <summary>
    /// Disables this property in the inspector if the editor is in play mode, otherwise it enables it.
    /// </summary>
    public class DisableInInspectorWhilePlayingAttribute : HideInInspectorWhilePlayingAttribute
    {
        public DisableInInspectorWhilePlayingAttribute()
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Enables this property in the inspector if the editor is in play mode, otherwise it disables it.
    /// </summary>
    public class EnableInInspectorWhilePlayingAttribute : ShowInInspectorWhilePlayingAttribute
    {
        public EnableInInspectorWhilePlayingAttribute()
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Disables this property in the inspector if the editor is not in play mode, otherwise it enables it.
    /// </summary>
    public class DisableInInspectorWhileEditingAttribute : HideInInspectorWhileEditingAttribute
    {
        public DisableInInspectorWhileEditingAttribute()
        {
            shouldDisable = true;
        }
    }

    /// <summary>
    /// Enables this property in the inspector if the editor is not in play mode, otherwise it disables it.
    /// </summary>
    public class EnableInInspectorWhileEditingAttribute : ShowInInspectorWhileEditingAttribute
    {
        public EnableInInspectorWhileEditingAttribute()
        {
            shouldDisable = true;
        }
    }
}
