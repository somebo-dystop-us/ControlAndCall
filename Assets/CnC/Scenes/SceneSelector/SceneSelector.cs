/// dystop.us | 08.02.2023

using UnityEngine;
using UnityEngine.SceneManagement;

using CnC.Dev;

namespace CnC.AppManagement
{
    public class SceneSelector : MonoBehaviour
    {
        #region Serialized fields

        [SerializeField]
        private Scene[] _scenesArray;

        #endregion

        #region MonoBehaviour's overrides methods

        private void Start()
        {
            LaunchScene(AppSceneID.SubrealEnvironment);
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
