/// dystop.us | 08.02.2023
using System.Collections;
using System.Collections.Generic;

using CnC.Dev;
using CnC.Utils;

using UnityEngine;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevFacade : MonoSingleton<DevFacade>
    {
        #region Public static getters

        public static Canvas DevUICanvas { get => Instance._devUICanvasReference; }

        #endregion

        #region Public static methods

        public static WindowType GetDevToolWindow<WindowType>() where WindowType : DevToolUIWindowBase
        {
            string windowKey = typeof(WindowType).Name;
            if (!Instance._windowsDictionary.ContainsKey(windowKey))
            {
                Instance._windowsDictionary.Add(windowKey, DevUICanvas.GetComponentInChildren<WindowType>());
            }
            return (WindowType)Instance._windowsDictionary[windowKey];
        }

        #endregion

        #region Serialized private fields | References | Canvas

        [SerializeField] private Canvas _devUICanvasReference;

        #endregion

        #region Serialized private fields | References | Dev Tools windows

        [SerializeField] private DevToolUIWindowBase[] _devToolsWindowsReferences;

        #endregion

        #region Private fields

        private Dictionary<string, object> _windowsDictionary = new Dictionary<string, object>();

        #endregion

        #region Public methods

        public void SetupDevWindowsReferences(DevToolUIWindowBase[] windowsReferences)
        {
            _devToolsWindowsReferences = windowsReferences;
        }

        #endregion
    }
}
