/// dystop.us | 08.02.2023
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using CnC.Utils;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    [Serializable]
    public class DevCheatEntrySerializable<EventType> where EventType : struct
    {
        private const string CheatNamePrefix = "Cheat";

        #region Serialized private fields 

        [Header("Keyboard shortcut to Invoke cheat-dependent Event")]
        [SerializeField] private KeyboardShortcut _shortcutToInvokeEvent = new KeyboardShortcut(KeyCode.CapsLock, KeyCode.D);

        [SerializeField] private EventType _eventToInvoke;

        [SerializeField] private bool _isOn;

        #endregion

        #region Public getters

        public KeyboardShortcut ShortcutToInvokeEvent { get { return _shortcutToInvokeEvent; } }

        public bool IsOn { get { return _isOn; } }

        public EventType EventToInvoke { get { return _eventToInvoke; } }

        #endregion

        #region Public methods

        

        #endregion

        #region Private methods



        #endregion
    }
}
