/// dystop.us | 08.02.2023
using System;

using UnityEngine;
using UnityEngine.UI;

using TMPro;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevUISelectorEntry : DevBehaviour
    {
        #region Serialized private fields | Tool windows references

        [SerializeField] private TextMeshProUGUI _entryLabel;
        [SerializeField] private Toggle _visibilityToggle;

        [SerializeField] private DevToolUIWindowBase _toolWindow;

        #endregion

        #region Public getters

        public DevToolUIWindowBase ToolWindow { get { return _toolWindow; } }

        #endregion

        #region MonoBehaviours

        private void Awake()
        {
            if (_toolWindow != null)
            {
                _entryLabel.text = _toolWindow.WindowTitle;
            }
        }


        #endregion

        #region Public methods | Setup

        /// <summary>
        /// 
        /// </summary>
        /// <param name="devWindowReference"></param>
        /// <param name="isVisible"></param>
        public void SetupEntry(string optionName, DevToolUIWindowBase devWindowReference, bool isVisible)
        {
            if (_entryLabel != null)
            {
                _entryLabel.text = optionName;
            }

            _toolWindow = devWindowReference;

            if (_visibilityToggle != null)
            {
                _visibilityToggle.isOn = isVisible;
            }
        }

        #endregion

        #region Public methods | On Toggle ValueChanged

        public void OnToggleValueChanged()
        {
            this.DevLog("Toggle value changed | isOn: " + _visibilityToggle.isOn);

            if (_toolWindow != null)
            {
                DevUISelector.ShowToolWindow(_toolWindow.WindowID, _visibilityToggle.isOn);
                _toolWindow.ShowIfAvailable();
            }

        }

        #endregion
    }
}
