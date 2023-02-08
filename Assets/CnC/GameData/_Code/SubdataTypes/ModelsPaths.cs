/// dystop.us | 08.02.2023
using System;

using UnityEngine;

namespace CnC.GameData
{
    [Serializable]
    public class ModelsPaths
    {
        #region Inspector / Private fields 

        [SerializeField] private string _modelPath = ""; // "Icons/Lines/";
        [SerializeField] private string _model3dViewPath = ""; // "Models/Lines/";
      
        #endregion

        #region Public accessors - for a legacy purposes mostly

        public string modelPath { get => _modelPath; }
        public string model3dViewPath { get => _model3dViewPath; }
       
        #endregion

        #region Constructors

        /// <summary>
        /// Use to store data without optional materials
        /// </summary>
        /// <param name="modelPath"></param>
        /// <param name="model3dViewPath"></param>
        public ModelsPaths(string modelPath, string model3dViewPath)
        {
            _modelPath = modelPath;
            _model3dViewPath = model3dViewPath;
        }

        #endregion

        #region Public methods - mostly legacy ones 
        public GameObject GetModelPrefab()
        {
            return (Resources.Load(GameDataUtils.ResourcesItemsPrefabs + modelPath)) as GameObject;
        }

        public GameObject Get3DModelViewPrefab()
        {
            return (Resources.Load(GameDataUtils.ResourcesItemsPrefabs + model3dViewPath)) as GameObject;
        }

        #endregion
    }
}
