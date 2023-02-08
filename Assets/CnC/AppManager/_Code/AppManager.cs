using _dystopus.Utils;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CnC.App
{
    public class AppManager : MonoSingleton<AppManager>
    {
        #region Serialized fields

       // [SerializeField]
        //private string _sceneToLoadName = "SubrealEnvironment";

        #endregion

        #region MonoBehaviour's overrides methods

        private void Start()
        {
           // SceneManager.LoadScene(_sceneToLoadName, LoadSceneMode.Single);
        }

        #endregion


    }
}
