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
    }
}