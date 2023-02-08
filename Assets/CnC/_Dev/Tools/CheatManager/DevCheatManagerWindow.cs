/// dystop.us | 08.02.2023
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevCheatManagerWindow : DevToolUIWindowBase
    {
        #region Serialized private fields | References



        #endregion

        #region MonoBehaviours



        #endregion

        #region Public methods

        protected override void InitWindow()
        {
            SetupWindow(DevToolUIWindowEnum.CheatManager, "UFS2 | Cheat Manager");
        }

        #endregion


        #region Private methods

        private void FullfillCheatList()
        {

        }

        #endregion
    }
}
