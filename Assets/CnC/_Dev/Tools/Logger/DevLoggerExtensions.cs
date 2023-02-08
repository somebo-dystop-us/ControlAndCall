using System.Collections.Generic;

using UnityEngine;

using CnC.Utils;
using CnC.Dev;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public static class DevLoggerExtensions
    {

        #region Public static methods

        /// <summary>
        /// <para>Extension method | Replacement of the Debug.Log calls for a <b>GameObjects</b>.</para>
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="additionalData"></param>
        public static void DevLog(this GameObject sender, string textMessage, params object[] additionalData)
        {
            DevLogger.BroadcastLog(sender.name, textMessage, additionalData);
        }

        /// <summary>
        /// Extension method | Replacement of the Debug.Log calls for <b>objects</b>.
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="additionalData"></param>
        public static void DevLog(this object sender, string textMessage, params object[] additionalData)
        {
            DevLogger.BroadcastLog(sender.GetType().Name, textMessage, additionalData);
        }

        #endregion 
    }
}



