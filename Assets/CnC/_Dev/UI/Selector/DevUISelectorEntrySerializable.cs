/// dystop.us | 08.02.2023
using System;

using UnityEngine;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    [Serializable]
    public class DevUISelectorEntrySerializable
    {
        #region Serialized private fields 

        [SerializeField] private string _optionName;
        [SerializeField] private bool _isOn;

        [SerializeField] private DevToolUIWindowBase _toolWindowReference;

        #endregion

        #region Public getters

        public string OptionName {  get { return _optionName; } }

        public bool IsOn { get { return _isOn; } }

        public DevToolUIWindowBase ToolWindowReference { get { return _toolWindowReference; } }

        #endregion 

        #region Public methods

  
        #endregion
    }
}
