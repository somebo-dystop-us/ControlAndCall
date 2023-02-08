/// dystop.us | 08.02.2023
using System;

using UnityEngine;

namespace CnC.GameData
{
    [Serializable]
    public class MaterialPath 
    {
        #region Static members

        public const string PrefabsPathPrefix = "GameItemsPrefabs/";

        #endregion

        #region Inspector / Private fields 

        [SerializeField] private string _materialPath = ""; //"Materials/Lines/";

        #endregion

        #region Public accessors
        public string materialPath { get => _materialPath;  }

        #endregion

        #region Constructors

        /// <summary>
        /// Use with "GameLines", because of storing additional information about materials
        /// </summary>
        /// <param name="modelPath"></param>
        /// <param name="model3dViewPath"></param>
        /// <param name="materialPath"></param>
        /// <param name="materialSzpulaPath"></param>

        public MaterialPath(string materialPath)
        {
            _materialPath = materialPath;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// //pobiera material z resources
        /// </summary>
        /// <returns></returns>
        public Material GetMaterial()
        {
            return (Resources.Load(PrefabsPathPrefix + materialPath)) as Material;
        }

        #endregion

    }
}
