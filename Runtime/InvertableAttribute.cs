namespace AdditionalInspectorAttributes
{
    // For any Conditional attributs (ShowIfTrue, DisableDuringPlay, etc) allow the opposite to happen (HideIfTrue/ShowIfFalse, DisableDuringEditing/EnableOnlyInPlay, etc)
    public abstract class InvertableAttribute : InspectorAttribute
    {
        protected bool invert;

        protected InvertableAttribute(bool shouldInvert)
        {
            invert = shouldInvert;
        }

        protected InvertableAttribute()
        {
            invert = false;
        }

        /// <summary>
        /// Inverts the value passed in if this attribute was told to invert its results.
        /// </summary>
        public bool ApplyInvert(bool value)
        {
            //
            //  if(invert)
            //  {
            //      return !value;
            //  }
            //  else
            //  {
            //      return value;
            //  }
            //

            return value != invert; //XOR operation
        }
    }
}
