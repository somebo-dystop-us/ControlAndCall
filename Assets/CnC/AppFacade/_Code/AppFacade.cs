
using UnityEngine;
using UnityEngine.SceneManagement;

using CnC.Dev;
using CnC.Utils;


namespace CnC.App
{
    /// <summary>
    /// dystop.us | 08.02.2023 03:34
    /// </summary>
    public class AppFacade : MonoSingleton<SceneSelector>
    {
        #region Serialized fields

        [SerializeField]
        private SceneSelector _sceneSelector;

        [Header("References array")]
        [SerializeField]
        private MonoBehaviour[] _referencesArray = null;

        #endregion

        #region Public getters



        #endregion

        #region MonoBehaviour's overrides methods

        private void Start()
        {
           InitFacade();
        }

        #endregion

        #region Private methods

        private void InitFacade()
        {
            foreach (var reference in _referencesArray)
            {
                this.DevLog("InitFacade() | reference.GetType().Name | " + reference.GetType().Name);
            }
        }

        #endregion
    }
}
