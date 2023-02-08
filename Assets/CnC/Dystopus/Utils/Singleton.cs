using UnityEngine;

namespace _dystopus.Utils
{
    /// <summary>
    /// Simple implementation of Singleton Pattern for MonoBehaviour.
    /// </summary>
    public class Singleton : MonoBehaviour
    {
        #region Public static | Instance

        public static Singleton Instance { get; private set; }

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
           
        }

        #endregion
    }
}