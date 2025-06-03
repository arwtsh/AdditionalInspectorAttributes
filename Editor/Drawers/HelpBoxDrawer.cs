using UnityEditor;
using UnityEngine.Assertions;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.ComponentModel;

namespace AdditionalInspectorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(HelpBoxAttribute))]
    internal class HelpBoxDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            HelpBoxAttribute helpBoxAttribute = attribute as HelpBoxAttribute;
            Assert.IsNotNull(helpBoxAttribute, "The HelpBoxDrawer should be attached to attributes of type HelpBoxAttribute, but the attribute was of type " + attribute.GetType().Name + " instead.");

            VisualElement container = new();
            VisualElement element = new PropertyField(property);

            HelpBox infoBox = new HelpBox(helpBoxAttribute.text, helpBoxAttribute.type);

            //Either have the help box appear before or after the property
            if(helpBoxAttribute.after)
            {
                container.Add(element);
                container.Add(infoBox);
            }
            else
            {
                container.Add(infoBox);
                container.Add(element);
            }

            return container;
        }
    }
}
