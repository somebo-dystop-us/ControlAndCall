/// dystop.us | 08.02.2023
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CnC.Events
{
    public class GameplayEventsManager : CustomEventsManager<GameplayEvent, IGameplayEventsListener>
    {
        #region Public static methods

        /// <summary>
        /// Implementation of Observer Pattern
        /// </summary>
        /// <param name="listeners"></param>
        public static void SetupListeners(IGameplayEventsListener listeners)
        {
            //RemoveListeners();

            currentListeners = listeners;

            RegisterListener(GameplayEvent.InstantFishCatch, listeners.OnInstantFishCatch);
            
        }

        /// <summary>
        /// 
        /// </summary>
        public static void RemoveListeners()
        {
            if (CurrentListeners == null)
            {
                return;
            }

            UnregisterListener(GameplayEvent.InstantFishCatch, CurrentListeners.OnInstantFishCatch);
        }

        #endregion

    }
}
