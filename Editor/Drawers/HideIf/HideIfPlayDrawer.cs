using System.ComponentModel;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AdditionalInspectorAttributes.Editor
{
    [CustomPropertyDrawer(typeof(HideIfPlayAttribute), true)]
    internal class HideIfPlayDrawer : HideIfDrawer
    {
        //Instead of calling IsVisible every few frames, use a callback system (because that's possible for this attribute)
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            HideIfPlayAttribute inverter = (HideIfPlayAttribute)attribute;
            HideOnPlayPropertyField content = new HideOnPlayPropertyField(property, inverter);

            if (inverter.shouldDisable)
            {
                content.SetEnabled(inverter.ApplyInvert(!Application.isPlaying));
            }
            else
            {
                content.style.display = inverter.ApplyInvert(!Application.isPlaying) ? DisplayStyle.Flex : DisplayStyle.None;
            }

            content.RegisterCallback<AttachToPanelEvent>(args => EditorApplication.playModeStateChanged += content.TogglePlayMode);
            content.RegisterCallback<DetachFromPanelEvent>(args => EditorApplication.playModeStateChanged -= content.TogglePlayMode);
            return content;
        }

        private class HideOnPlayPropertyField : PropertyField
        {
            HideIfPlayAttribute inverter;

            public HideOnPlayPropertyField(SerializedProperty property, HideIfPlayAttribute invertHandler) : base(property) { inverter = invertHandler;}

            internal void TogglePlayMode(PlayModeStateChange args)
            {
                if (inverter.shouldDisable)
                {
                    SetEnabled(inverter.ApplyInvert(!Application.isPlaying));
                }
                else
                {
                    style.display = inverter.ApplyInvert(!Application.isPlaying) ? DisplayStyle.Flex : DisplayStyle.None;
                }
            }
        }
    }
}
