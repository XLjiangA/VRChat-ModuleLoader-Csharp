using UnityEngine;
using UnityEngine.UI;
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
        public static void SetText(this Text @component, string text)
        {
            if (@component == null)
            {
                return;
            }
            @component.text = text;
        }
    }
}
