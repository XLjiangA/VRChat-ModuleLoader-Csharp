using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace VRCTans.Utility
{
    public static class GameObjectUtility
    {
        public static Text GetTextComponent(this GameObject @object)
        {
            if (@object == null)
            {
                return null;
            }
            return @object.GetComponent<Text>();
        }
        public static TextMeshProUGUI GetTextMeshProComponent(this GameObject @object)
        {
            if (@object == null)
            {
                return null;
            }
            return @object.GetComponent<TextMeshProUGUI>();
        }
        public static void SetText(this Text @component, string text)
        {
            if (@component == null)
            {
                return;
            }
            @component.text = text;
        }
        public static void SetText(this TextMeshProUGUI @component, string text)
        {
            if (@component == null)
            {
                return;
            }
            @component.text = text;
        }
    }
}
