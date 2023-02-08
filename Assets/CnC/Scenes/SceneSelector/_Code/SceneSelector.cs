
using UnityEngine;
using UnityEngine.SceneManagement;

using CnC.Dev;
using CnC.Utils;

namespace CnC.App
{
    /// <summary>
    /// dystop.us | 08.02.2023 03:14
    /// </summary>
    public class SceneSelector : MonoSingleton<SceneSelector>
    {
        #region Serialized fields

        [SerializeField]
        private Scene[] _scenesArray;

        #endregion

        #region MonoBehaviour's overrides methods

        private void Start()
        {
            LaunchScene(AppSceneID.CnC_SubrealEnvironment);
            LaunchScene(AppSceneID.CnC_UI);
        }

        #endregion

        #region Private methods

        private void LaunchScene(AppSceneID sceneID, LoadSceneMode loadMode = LoadSceneMode.Additive)
        {
            var sceneName = sceneID.ToString();
            this.DevLog("LaunchScene() | " + sceneName);

            SceneManager.LoadScene(sceneName, loadMode);
        }

        #endregion
    }
}
