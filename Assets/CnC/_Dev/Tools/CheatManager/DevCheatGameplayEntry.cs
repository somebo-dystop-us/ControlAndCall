/// dystop.us | 08.02.2023
using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using CnC.Utils;
using CnC.Events;
using CnC.Dev;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevCheatGameplayEntry :  DevCheatEntry<GameplayEvent>
    {

        #region MonoBehaviours

        private void OnEnable()
        {
            List<string> eventNames = new List<string>();
            for (GameplayEvent iEvent = 0; iEvent < GameplayEvent.Count; iEvent++)
            {
                eventNames.Add(iEvent.ToString());
            }
            FillEventsDropdown(eventNames);
        }

        #endregion

        #region Public methods | Setup

        #endregion

        #region Public methods | On Toggle ValueChanged

        public override void OnInvokeButton()
        {
            GameplayEventsManager.DispatchEvent(_eventToInvoke);
        }

        #endregion

        #region Private methods



        #endregion
    }
}
