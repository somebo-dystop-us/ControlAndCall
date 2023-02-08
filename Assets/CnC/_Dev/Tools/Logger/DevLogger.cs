using System.Collections.Generic;

using CnC.Utils;
using CnC.Dev;

using UnityEngine;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevLogger
    {
        #region Public static getters

        /// <summary>
        /// 
        /// </summary>
        public static DevLogEntry[] LoggedMessages { get => _loggedMessages.ToArray(); }

        #endregion

        #region Private static properties

        private static List<DevLogEntry> _loggedMessages = new List<DevLogEntry>();

        #endregion


        #region Public static methods

        /// <summary>
        /// Replacement of the Debug.Log calls providing custom sender name.
        /// </summary>
        /// <param name="textMessage"></param>
        /// <param name="additionalData"></param>
        public static void DevLog(string senderName, string textMessage, params object[] additionalData)
        {
            BroadcastLog(senderName, textMessage, additionalData);
        }

        #endregion

        #region Public static methods

        public static void BroadcastLog(string senderName, string textMessage, params object[] additionalData)
        {
            string compiledMessageText = CompileMessage(senderName, textMessage);

            _loggedMessages.Add(new DevLogEntry(senderName, compiledMessageText)); //, additionalData));

#if UNITY_EDITOR
            Debug.Log(compiledMessageText);
#endif
        }

        #endregion

        #region Private static methods

        private static string CompileMessage(string senderName, string messageToInclude)
        {
            return senderName + " | " + messageToInclude;
        }

        #endregion
    }
}
