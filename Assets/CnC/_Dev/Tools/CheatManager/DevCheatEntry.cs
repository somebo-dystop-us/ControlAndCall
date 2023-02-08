/// dystop.us | 08.02.2023
using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using CnC.Utils;
using CnC.Events;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public abstract class DevCheatEntry<GenericEventType> : DevBehaviour where GenericEventType : struct
    {
        #region Serialized protected fields | References

        [SerializeField] protected TextMeshProUGUI _shortcutLabel;

        [SerializeField] protected Toggle _avaibilityToggle;

        [SerializeField] protected TMP_Dropdown _eventDropdown;

        [SerializeField] protected Button _invokeButton;

        #endregion

        #region Protected fields

        protected GenericEventType _eventToInvoke;

        #endregion

        #region Public methods | Setup

        public void SetupEntry(KeyboardShortcut shortcut, bool isAvailable, GenericEventType eventToInvoke) 
        {
            if (_shortcutLabel != null)
            {
                _shortcutLabel.text = shortcut.ToString();
            }

            if (_avaibilityToggle != null)
            {
                _avaibilityToggle.isOn = isAvailable;
            }

          

            _eventToInvoke = eventToInvoke;
        }

       

        #endregion

        #region Public methods | On Toggle ValueChanged

        public void OnToggleValueChanged()
        {
            this.DevLog("Toggle value changed | isOn: " + _avaibilityToggle.isOn);

        }

        public abstract void OnInvokeButton();


        #endregion

        #region Protected methods

        protected void FillEventsDropdown(List<string> options)
        {
            if (_eventDropdown == null)
            {
                return;
            }
            _eventDropdown = GetComponentInChildren<TMP_Dropdown>();
            _eventDropdown.ClearOptions();
            _eventDropdown.AddOptions(options);
        }

        #endregion
    }
}
