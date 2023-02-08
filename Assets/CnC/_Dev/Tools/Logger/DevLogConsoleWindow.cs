using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevLogConsoleWindow : DevToolUIWindowBase
    {

        #region MonoBehaviours

        private void Awake()
        {
            InitWindow();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion

        #region Protected methods | overrides

        protected override void InitWindow()
        {
            SetupWindow(DevToolUIWindowEnum.DevLogConsole, "UFS2 | Dev Log Console");
        }

        #endregion
    }
}
