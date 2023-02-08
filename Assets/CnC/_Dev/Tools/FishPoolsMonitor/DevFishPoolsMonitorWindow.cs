/// dystop.us | 08.02.2023
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

namespace CnC.Dev
{
    public class DevFishPoolsMonitorWindow : DevToolUIWindowBase
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
            SetupWindow(DevToolUIWindowEnum.FishPoolsMonitor, "UFS2 | Fish Pools Monitor");
        }

        #endregion
    }
}
