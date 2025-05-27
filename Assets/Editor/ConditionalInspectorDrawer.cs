using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace ConditionalInspector
{
    internal abstract class HideInInspectorIfDrawer : PropertyDrawer
    {
        protected abstract bool IsVisible(SerializedObject serializedObject);

        //Not called every frame. OnGUI's PropertyFields are not aligned properly
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement container = new VisualElement();
            PropertyField element = new PropertyField(property);
            container.Add(element);

            //Make an update loop so the inspector is dynamic.
            //OnGUI's updates would be best, but it doesn't get called when this method returns something.
            container.schedule.Execute(() =>
            {
                Debug.Log("Updating");
                container.style.display = IsVisible(property.serializedObject) ? DisplayStyle.Flex : DisplayStyle.None;
            }).Every(100); //~10 FPS I decided to go for more optimization since it's just the editor. 16 is ~60 FPS if you want to increase it.

            return container;
        }
    }
}
