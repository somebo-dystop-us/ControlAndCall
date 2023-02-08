/// dystop.us | 08.02.2023
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using CnC.Pools;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevUIUtils// : MonoBehaviour
    {
        /// <summary>
        /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
        /// </summary>
       // public static void CreateDevToolSelectorLabel(DevWindow toolWindow)
       // {
            /*
            bool isToolVisible = DevTools.IsToolVisible[toolWindow.ID];

            string labelText = "[ " + toolWindow.WindowTitle + " ]\t| ";
            labelText   += isToolVisible
                        ? "To hide: " + DevTools.Instance.ShortcutsToHideToolWindow[toolWindow.ID]
                        : "To show: " + DevTools.Instance.ShortcutsToShowToolWindow[toolWindow.ID];

            CreateLabel(labelText, isToolVisible ? Color.red : Color.green);
            */
       // }

        /// <summary>
        /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
        /// </summary>
        public static void CreateFishPoolStatsLabel(int variantIndex, Vector2 weightExtremes, PoolStats variantPoolStats)
        {
            Color labelColor = (variantPoolStats.NumberOfAllPooledItems == 0 
                ? Color.red : (variantPoolStats.NumberOfActiveItems > 0 
                ? (variantPoolStats.NumberOfActiveItems == variantPoolStats.NumberOfAllPooledItems 
                ? Color.yellow : Color.green) : Color.black));

            CreateLabel(
                "#" + variantIndex + " | \t\t|\t"

                + weightExtremes.x.ToString("n2")
                + " - "
                + (!float.IsInfinity(weightExtremes.y) ? weightExtremes.y.ToString("n2") : "?.??") + " [kg]\t|\t"

                + variantPoolStats.NumberOfActiveItems
                + " / "
                + variantPoolStats.NumberOfAllPooledItems,
                labelColor
            );
        }

        /// <summary>
        /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
        /// </summary>
        public static void CreateLabel(string labelText, Color labelColor)
        {
            GUI.contentColor = labelColor;

            GUILayout.Label(labelText);
        }

       
    }
}


/* OLD GUI Code
 * 
 *  
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevGUI : MonoSingleton<DevGUI>
    {
        #region Subclasses

        [Serializable]
        public class LabelEntry
        {
            public string text = "";
            public bool mine = true;
        }

        #endregion

        #region Serialized private fields | Dev Tools Windows

        [Header(" Array of provided Dev Tools")]
        [SerializeField]
        private DevWindow[] _devToolWindows;

        #endregion

        #region Public properties

        /// <summary>
        ///  Public reference | Provided Dev Tools
        /// </summary>
       // public DevWindow[] DevToolWindows { get => DevTools.IsAuthorized ? _devToolWindows : null; }

        #endregion

        #region MonoBehaviour callbacks

        private void Awake()
        {
            InitProvidedToolWindows();
        }

        private void Update()
        {
            
            if (!DevTools.IsAuthorized)
            {
                enabled = false;
                return;
            }
            
        }

        #endregion

        #region OnGUI

        void OnGUI()
        {
            if (!DevTools.AreDevToolsAvailable)
            {
                return;
            }

            foreach (var toolWindow in _devToolWindows)
            {
                //if (DevTools.IsToolVisible[toolWindow.ID])
                {
                    toolWindow.Show();
                }
            }
        }

        #endregion

        #region Private methods | Dev Tools Windows

        private void InitProvidedToolWindows()
        {
            for (var iWindow = 0; iWindow < _devToolWindows.Length; iWindow++)
            {
                _devToolWindows[iWindow].Init((DevToolWindowEnum)iWindow);
            }
        }

        #endregion
    }
    */