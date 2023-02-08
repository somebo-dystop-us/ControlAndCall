/// dystop.us | 08.02.2023
using CnC.Utils;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevSingleton<SingletonType> : MonoSingleton<DevSingleton<SingletonType>>
    {
        #region Public/private properties

        public bool IsAuthorized { get => enabled = DevTools.AreDevToolsAvailable; }

        #endregion

        #region MonoBehaviours

        private void OnEnable()
        {
           
            this.DevLog("IsAuthorized: " + IsAuthorized);
        }

        #endregion
    }
}
