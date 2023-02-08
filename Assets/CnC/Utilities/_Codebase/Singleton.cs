/// dystop.us | 08.02.2023
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CnC.Utils
{
    /// <summary>
    /// Simple implementation of Singleton Pattern for MonoBehaviour.
    /// </summary>
    public class Singleton : MonoBehaviour
    {
        #region Public static | Instance
        public static Singleton Instance { get; private set; }

       // public static T Current { get; private set; }

        /*
         * Facade | work in progress
        public AudioManager AudioManager { get; private set; }
        public UIManager UIManager { get; private set; }
        */
        #endregion

        #region MonoBehaviour | Awake()

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            //Current = 

            /*
            * Facade | work in progress
            AudioManager = GetComponentInChildren<AudioManager>();
            UIManager = GetComponentInChildren<UIManager>();
             */
        }

        #endregion
    }
}