/// dystop.us | 08.02.2023
using System.Collections.Generic;
using UnityEngine;

namespace CnC.Utils
{
    /// <summary>
    /// Thread-safe implementation of <b>Singleton Pattern for MonoBehaviour</b>.
    /// <para>Note: Based on dictionary instead of using FindObjectsOfType or creating GameObject during the game, which are very inefficient</para>
    /// </summary>
    /// <typeparam name="T">The type we want to make a singleton</typeparam>

    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        #region Static fields

        private static readonly object Lock = new object();
        private static Dictionary<System.Type, MonoSingleton<T>> instancesDictionary;

        #endregion

        #region Static instance getter

        public static T Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instancesDictionary == null)
                    {
                        instancesDictionary = new Dictionary<System.Type, MonoSingleton<T>>();
                    }

                    if (instancesDictionary.ContainsKey(typeof(T)))
                    {
                        return (T)instancesDictionary[typeof(T)];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        #endregion

        #region MonoBehaviour's inherited methods

        private void OnEnable()
        {
            lock (Lock)
            {
                if (instancesDictionary == null)
                {
                    instancesDictionary = new Dictionary<System.Type, MonoSingleton<T>>();
                }

                if (instancesDictionary.ContainsKey(this.GetType()))
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    instancesDictionary.Add(this.GetType(), this);

                    DontDestroyOnLoad(gameObject);
                }
            }
        }

        #endregion
    }
}