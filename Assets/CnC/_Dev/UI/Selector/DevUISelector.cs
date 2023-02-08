/// dystop.us | 08.02.2023
using System.Collections.Generic;

using UnityEngine;

using CnC.Utils;
using CnC.Dev;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevUISelector : DevBehaviour
    { 
        #region Public static properties

        /// <summary>
        /// Default: array of truth
        /// </summary>
        public static bool[] IsToolVisible { get => _isToolVisible; }

        #endregion

        #region Private static fields

        private static bool[] _isToolVisible = new bool[] { false, false, false };

        #endregion

        #region Public static methods

        public static void ShowToolWindow(DevToolUIWindowEnum windowID, bool isVisible = true)
        {
            _isToolVisible[(int)windowID] = isVisible;   
        }

        #endregion

        #region Serialized private fields | References

        [Header("Dev Tools selection")]
        [SerializeField]
        private DevUISelectorEntrySerializable[] _options;

        [Space]

        [Header("References")]

        [SerializeField] 
        private RectTransform _optionsContainer;

        [Space]

        [SerializeField] private DevUISelectorEntry _optionEntryPrefab;

        #endregion

        #region MonoBehaviours callbacks


        #endregion

        #region Public methods | InitSelector

        public void InitSelector()
        {
            this.DevLog("Inits Selector | AreDevToolsAvailable: " + DevTools.AreDevToolsAvailable);

            if (!DevTools.AreDevToolsAvailable)
            {
                return;
            }

            FullfillOptionsList();

        }

        #endregion

        #region Private methods


        private void FullfillOptionsList()
        {
            //_optionsContainer.DestroyChildren();

            List<DevToolUIWindowBase> windowsList = new List<DevToolUIWindowBase>();

            foreach (var option in _options)
            {
                this.DevLog("Setups entry: " + option.OptionName);

                var newEntry = Instantiate(_optionEntryPrefab, _optionsContainer);

                newEntry.SetupEntry(option.OptionName, option.ToolWindowReference, option.IsOn);
                windowsList.Add(option.ToolWindowReference);
            }

            DevFacade.Instance.SetupDevWindowsReferences(windowsList.ToArray());

        }

        private void ApplyToolWindowVisibility(int windowIndex)
        {
            _options[windowIndex].ToolWindowReference.ShowIfAvailable();
        }

        #endregion
    }
}