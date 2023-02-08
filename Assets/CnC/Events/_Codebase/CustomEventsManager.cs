using System;
using System.Collections.Generic;

using UnityEngine;

using CnC.Dev;

namespace CnC.Events
{
    /// <summary>
    /// Implementation of <b>Observer Pattern</b>.
    /// </summary>
    /// <typeparam name="CustomEvent"></typeparam>
    /// <typeparam name="CustomListenerInterface"></typeparam>
    public class CustomEventsManager<CustomEvent, CustomListenerInterface> : MonoBehaviour
    {
        #region Protected static | GETTERS

        /// <summary>
        /// Getter for a cached reference to currently registered listeners - Interface
        /// </summary>
        protected static CustomListenerInterface CurrentListeners { get => currentListeners; }

        protected static CustomListenerInterface currentListeners;

        #endregion

        #region Private static | FIELDS

        private static Dictionary<CustomEvent, List<Action<object[]>>> listenersDictionary = new Dictionary<CustomEvent, List<Action<object[]>>>();

        #endregion

        #region Public static | Dispatch Event

        /// <summary>
        /// Callbacks all of registered listeners about occurrence of an event given in the first parameter
        /// </summary>
        /// <param name="eventType">One of a GamepadEvents defined in GamepadEvent enum</param>
        /// <param name="dataValues"> dynamic values list of type int. Using by some of an eventTypes</param>
        public static void DispatchEvent(CustomEvent eventType, params object[] dataValues)
        {
            DevLogger.DevLog(typeof(CustomEventsManager<CustomEvent, CustomListenerInterface>).Name,"CustomEventsManager | Dispatch event: " + eventType + " | params " + dataValues);

            if (!listenersDictionary.ContainsKey(eventType))
            {
                return;
            }

            List<Action<object[]>> actionsList = listenersDictionary[eventType];

            for (int i = 0; i < actionsList.Count; i++)
            {

                actionsList[i].Invoke(dataValues);
            }

        }

        #endregion

        #region Protected static | Register / Unregister listeners

        /// <summary>
        /// Registers listener for an event of type given in parameter
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="callbackFunction"></param>
        protected static void RegisterListener(CustomEvent eventType, Action<object[]> callbackFunction)
        {
            if (!listenersDictionary.ContainsKey(eventType))
            {
                listenersDictionary.Add(eventType, new List<Action<object[]>>());
            }

            listenersDictionary[eventType].Add(callbackFunction);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="callbackFunction"></param>
        protected static void UnregisterListener(CustomEvent eventType, Action<object[]> callbackFunction)
        {
            if (!listenersDictionary.ContainsKey(eventType))
            {
                return;
            }

            if (!listenersDictionary[eventType].Contains(callbackFunction))
            {
                return;
            }

            listenersDictionary[eventType].Remove(callbackFunction);
        }

        #endregion
    }
}