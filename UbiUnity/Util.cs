using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace UbiUnity
{
    public static class Util
    {
        /// <summary>
        /// Attempts to parse a given string to find an enum value of a given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <param name="value">Either a valid match value or the default value of T.</param>
        /// <returns>True if a valid match is found, false if not</returns>
        public static bool EnumTryParse<T>(this string text, out T value) where T : struct
        {
            value = default(T);
            Type type = typeof(T);
            if (!type.IsEnum || text == null)
            {
                return false;
            }
            foreach (T eVal in GetEnumValues<T>())
            {
                if (eVal.NormaliseString() == text.NormaliseString())
                {
                    value = eVal;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Return an array of the given enum type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T[] GetEnumValues<T>() where T : struct
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                return new T[0];
            }
            return Enum.GetValues(type).Cast<T>().ToArray();
        }

        /// <summary>
        /// Close the game: stops the playthrough if
        /// running in the editor and stops the executable
        /// file if the build is running.
        /// </summary>
        public static void Quit()
        {
            //Uses preprocessor logic.
            //If program is running in the Unity Editor.
#if UNITY_EDITOR
            //Stop the editor (set isPlaying to false which terminates play).
            UnityEditor.EditorApplication.isPlaying = false;
        //Otherwise (i.e. if program in running inside an executable in our case).
#else
            //Close the executable.
            Application.Quit();
#endif
        }

        /// <summary>
        /// Trims text and sets it to a uniform case for easy comparison.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string NormaliseString(this object obj)
        {
            return obj.ToString().Trim().ToLower();
        }
    }
}