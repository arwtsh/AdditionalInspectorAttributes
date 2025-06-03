using UnityEngine.UIElements;

namespace AdditionalInspectorAttributes
{
    public class HelpBoxAttribute : InspectorAttribute
    {
        public string text;
        public HelpBoxMessageType type;
        public bool after;

        /// <summary>
        /// Places informational text next to this property
        /// </summary>
        /// <param name="_text">The content of the text box</param>
        /// <param name="after">The text box is placed below if true, above otherwide.</param>
        /// <param name="_type">The design of the text box.</param>
        public HelpBoxAttribute(string _text, bool _after = true, HelpBoxMessageType _type = HelpBoxMessageType.Info) 
        { 
            text = _text;
            type = _type;
            after = _after;
        }
    }
}
