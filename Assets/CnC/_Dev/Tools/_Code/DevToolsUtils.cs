/// dystop.us | 08.02.2023
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using CnC.Dev;

namespace CnC.Dev
{
    /// <summary>
    /// Note: These are the <b>tools for developers</b>, so there is no any details about how it works etc provided.
    /// </summary>
    public class DevToolsUtils : MonoBehaviour
    {
        #region Keyboard shortcuts with old Input system

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortcutToCheck"></param>
        /// <returns></returns>
        public static bool CheckKeyboardShortcut(KeyCode[] shortcutToCheck)
        {
            foreach (KeyCode keyCode in shortcutToCheck)
            {
                if (!Input.GetKey(keyCode))
                {
                    return false;
                }
            }
            DevLogger.DevLog("DevToolsUtils", "Check keyboard shortcut: true");
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shortcutToCheck"></param>
        /// <returns></returns>
        public static string GetKeyboardShortcutString(KeyCode[] shortcutToCheck)
        {
            string outputString = " ";
            foreach (KeyCode keyCode in shortcutToCheck)
            {
                outputString += "[ " + keyCode.ToString().ToUpperInvariant() + " ]";
            }
            return outputString; 
        }

        #endregion

    }
}
