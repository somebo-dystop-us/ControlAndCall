/// dystop.us | 08.02.2023
using System;
using System.Collections.Generic;
using System.Linq;

using CnC.Dev;

using UnityEngine;


#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CnC.GameData
{
    public class DataManagerBaseSO<SOType, EnumID, EnumType> : ScriptableObject where SOType : FishingEquipmentBaseSO<EnumID, EnumType>
    {
        #region Public const strings

        public const string ManagerFileName = "DataManager";
        public const string FileExtension = ".asset";

        #endregion

        #region Serialized fields

        [SerializeField] protected List<SOType> _existingDataFiles = null;
        [SerializeField] protected Dictionary<EnumID, SOType> _gameDataDictionary = null;

        //[SerializeField] protected ResourcePathsSO _resourcePaths;

        #endregion

        #region Accessors

        public int GameDataSOCount { get => _existingDataFiles.Count; } // TODO: improve?

        private string PathInResources { get => "GameData/" + typeof(EnumID).Name + "/"; }
        private string PathToPlaceDataSO { get => "Assets/Resources/" + PathInResources; }
        private string FileNamePrefix { get => typeof(EnumID).Name + "Data_"; }

        #endregion

        #region Constructor

        public DataManagerBaseSO()
        {
            // Debug.Log("GameDataManagerSO | Constructor!");
            if (_existingDataFiles == null)
            {
                _existingDataFiles = new List<SOType>();
                // Debug.Log(" GameDataManagerSO | New List!");
            }

            if (_gameDataDictionary == null)
            {
                _gameDataDictionary = new Dictionary<EnumID, SOType>();
                // Debug.Log(" GameDataManagerSO | New Dictionary!");
            }
        }

        #endregion

        #region Creating / Modifying SO with GameData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idToCheck"></param>
        /// <returns>true if there is registred SO to store data of given by idToCheck</returns>

        public bool CheckIfDataSOExists(EnumID idToCheck)
        {
            return _gameDataDictionary.ContainsKey(idToCheck);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SOType</returns>
        public SOType GetOrCreateSO(EnumID id)
        {
            return CheckIfDataSOExists(id) ? _gameDataDictionary[id] : CreateSO(id);
            //return CreateSO(id);
        }


        public SOType CreateSO(EnumID id)
        {
            SOType newSO = ScriptableObject.CreateInstance<SOType>();

            newSO.SetId(id);

#if UNITY_EDITOR
            AssetDatabase.CreateAsset(newSO, GenerateFullPath(id));
            AssetDatabase.SaveAssets();

            //AssetDatabase.Refresh();
#endif

            _existingDataFiles.Add(newSO);
            _gameDataDictionary.Add(id, newSO);

            return newSO;
        }

        #endregion

        #region Public methods

        public SOType[] GetGameDataArray()
        {
            return _gameDataDictionary.Values.ToArray();
        }

        public SOType GetSingleGameDataSO(EnumID id)
        {
            // Debug.Log(name + " |  _gameDataDictionary ContainsKey: " + id + " >> " + _gameDataDictionary.ContainsKey(id));
            return _gameDataDictionary[(EnumID)id];
        }

        #endregion

        #region Public - Buttons OnClick listeners
        public void LoadDataToDictionary()
        {
            //this.DevLog(name + " | BEFORE gameDataDictionary Count: " + _gameDataDictionary.Count);

            _gameDataDictionary.Clear();

            foreach (var dataFromList in _existingDataFiles)
            {
               _gameDataDictionary.Add(dataFromList.enumID, dataFromList);
            }

            //this.DevLog(name + " | AFTER gameDataDictionary Count: " + _gameDataDictionary.Count);
        }

        public void LoadDataFromResources()
        {
            //Debug.Log(name + " | BEFORE gameDataDictionary Count: " + _gameDataDictionary.Count);

            //_gameDataDictionary.Clear();

            // SOType[] gameDataArray = Resources.FindObjectsOfTypeAll<SOType>();
            //UnityEngine.Object[] dataObjects = Resources.LoadAll<SOType>(PathInResources
            SOType[] dataObjects = Resources.LoadAll<SOType>(PathInResources);
            //dataObjects[0]
            //this.DevLog(name + " | loaded from Resources Count: " + dataObjects.Length);

            _existingDataFiles = dataObjects.ToList();

            ApplyToAsset();

            //this.DevLog(name + " | loaded from Resources Count: " + gameDataArray.Length);


            /*
            foreach (var dataFromList in _createdDataFiles)
            {
                //_gameDataDictionary.Add(dataFromList.ID, dataFromList);
            }
            */

            // Debug.Log(name + " | AFTER gameDataDictionary Count: " + _gameDataDictionary.Count);
        }

        /// <summary>
        /// Loads data SOs FROM Resources and also TO Dictionary if currently there is no any loaded yet
        /// </summary>
        public void InitIfNeeded()
        {
            //this.DevLog(name + " | Inits - BEFORE | Count: " + _existingDataFiles.Count);

            if (_existingDataFiles.Count == 0)
            {
                LoadDataFromResources();

            }

            LoadDataToDictionary();

            //this.DevLog(name + " | Inits - AFTER | Count: " + _existingDataFiles.Count);
        }

        /*
        public void ReloadListFromDictionary()
        {
           Debug.Log(name + " | ReloadListFromDictionary, list Count: " + _createdDataFiles.Count);
           //Debug.Log(name + " | ReloadListFromDictionary, dictionary Count: " + _registeredDataPairs.Count);
           Debug.Log(name + " | ReloadListFromDictionary, gameDataDictionary Count: " + _gameDataDictionary.Count);


           _createdDataFiles.Clear();
           foreach (var keyValuePair in _registeredDataPairs)
           {
               _createdDataFiles.Add(keyValuePair.Value);
           }
          
        }
        */
        #endregion

        #region Protected methods

        protected string GenerateFullPath(EnumID id)
        {
            return PathToPlaceDataSO + FileNamePrefix + id + FileExtension;
        }

        protected void ApplyToAsset()
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }

        #endregion
    }
}
