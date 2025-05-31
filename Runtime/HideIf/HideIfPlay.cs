namespace AdditionalInspectorAttributes
{
    public class HideIfPlayAttribute : HideIfAttribute
    {
        public HideIfPlayAttribute()
        {

        }
    }

    /// <summary>
    /// Hides this property in the inspector if the editor is in play mode, otherwise it shows it.
    /// </summary>
    public class HideInInspectorWhilePlayingAttribute : HideIfPlayAttribute
    {
        public HideInInspectorWhilePlayingAttribute()
        {
            invert = false;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the editor is in play mode, otherwise it hides it.
    /// </summary>
    public class ShowInInspectorWhilePlayingAttribute : HideIfPlayAttribute
    {
        public ShowInInspectorWhilePlayingAttribute()
        {
            invert = true;
        }
    }

    /// <summary>
    /// Hides this property in the inspector if the editor is not in play mode, otherwise it shows it.
    /// </summary>
    public class HideInInspectorWhileEditingAttribute : HideIfPlayAttribute
    {
        public HideInInspectorWhileEditingAttribute()
        {
            invert = true;
        }
    }

    /// <summary>
    /// Shows this property in the inspector if the editor is not in play mode, otherwise it hides it.
    /// </summary>
    public class ShowInInspectorWhileEditingAttribute : HideIfPlayAttribute
    {
        public ShowInInspectorWhileEditingAttribute()
        {
            invert = false;
        }
    }
}
