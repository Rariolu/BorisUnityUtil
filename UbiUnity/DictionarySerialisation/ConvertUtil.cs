using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UbiUnity.DictionarySerialisation
{
    /// <summary>
    /// A class which contains methods for converting Unity
    /// colours to and from Int32. This is an excerpt of the
    /// full class found here https://github.com/lordofduct/spacepuppy-unity-framework/blob/master/SpacepuppyBase/Utils/ConvertUtil.cs#L43
    /// </summary>
    public static class ConvertUtil
    {
        public static int ToInt(Color color)
        {
            return (Mathf.RoundToInt(color.a * 255) << 24) +
                   (Mathf.RoundToInt(color.r * 255) << 16) +
                   (Mathf.RoundToInt(color.g * 255) << 8) +
                   Mathf.RoundToInt(color.b * 255);
        }
        public static Color ToColor(int value)
        {
            var a = (value >> 24 & 0xFF) / 255f;
            var r = (value >> 16 & 0xFF) / 255f;
            var g = (value >> 8 & 0xFF) / 255f;
            var b = (value & 0xFF) / 255f;
            return new Color(r, g, b, a);
        }
    }
}