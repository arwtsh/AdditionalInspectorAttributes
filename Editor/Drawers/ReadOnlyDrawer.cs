using UnityEditor;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace AdditionalInspectorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    internal class ReadOnlyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement element = new PropertyField(property);

            //Permanently set the element to disabled.
            element.SetEnabled(false);

            return element;
        }
    }
}
