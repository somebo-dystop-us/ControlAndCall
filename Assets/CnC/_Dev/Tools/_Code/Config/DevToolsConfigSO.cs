/// dystop.us | 08.02.2023
using System;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using CnC.GameData;

namespace CnC.Dev
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = GameDataUtils.DevToolsConfigSOFileName,
       menuName = GameDataUtils.CAMRoot + GameDataUtils.CAMDevToolsRoot + GameDataUtils.CAMNewDataFile)]
#endif

    public class DevToolsConfigSO : ScriptableObject
    {
        #region Serialized private fields

        [Header("Dev Tools | Release Date")]
        [SerializeField] private string _releaseDateString;

        #endregion

        #region Public/private properties

        /// <summary>
        /// The date of Dev Tools release
        /// </summary>
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            private set 
            { 
                _releaseDate = value;
                _releaseDateString = _releaseDate.ToString();
            }
        }

        /// <summary>
        /// The date of Dev Tools release, but returned as string
        /// </summary>
        public string ReleaseDateString { get => _releaseDateString; private set => _releaseDateString = value; }

        #endregion

        #region Private fields

        [SerializeField] private DateTime _releaseDate;

        #endregion

        #region Scriptable Objects Behaviours

        private void Awake()
        {
            this.DevLog("Release Date-Time | " + _releaseDate); 
        }

        #endregion

        #region Public methods 

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The release date of the Dev Tools </returns>
        public DateTime UpdateReleaseDate()
        {
            return ReleaseDate = DateTime.Now;
        }

        #endregion

    }
}
