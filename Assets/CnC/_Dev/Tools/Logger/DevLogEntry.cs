
namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevLogEntry
    {
        #region Public/private properties

        public MessageType TypeOfMessage { get; private set; }
        public string SenderName { get; private set; }
        public string MessageText { get; private set; }
        public object[] AdditionalData { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
        /// </summary>
        /// <param name="senderName"></param>
        /// <param name="textMessage"></param>
        /// <param name="additionalData"></param>
        public DevLogEntry(string senderName, string textMessage, params object[] additionalData)
        {
            SenderName = senderName;
            MessageText = textMessage;
            AdditionalData = additionalData;
        }

        #endregion
    }
}
