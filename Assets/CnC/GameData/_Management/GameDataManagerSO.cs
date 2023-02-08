/// dystop.us | 08.02.2023
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using CnC.Dev;

namespace CnC.GameData
{
    public class GameDataManagerSO<SOType, EnumID, EnumType> : ScriptableObject where SOType : GameDataBaseSO<EnumID, EnumType>
    {
        public const string ManagerFileName = "DataManager";
        public const string FileExtension = ".asset";

        private string PathInResources { get => "GameData/" + typeof(EnumID).Name + "/"; }
        private string PathToPlaceDataSO { get => "Assets/Resources/" + PathInResources; }
        private string FileNamePrefix { get => typeof(EnumID).Name + "Data_"; }

        [SerializeField] protected List<SOType> _existingDataFiles = null;
        [SerializeField] protected Dictionary<EnumID, SOType> _gameDataDictionary = null;
        
        public int GameDataSOCount
        {
            get { return _existingDataFiles.Count; } // TODO: improve?
        }
        
        
        public GameDataManagerSO( )
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SOType CreateSO(EnumID id)
        {
            SOType newSO = ScriptableObject.CreateInstance<SOType>();

            newSO.SetupId(id);

#if UNITY_EDITOR
            AssetDatabase.CreateAsset(newSO, GenerateFullPath(id));
            AssetDatabase.SaveAssets();
#endif

            //AssetDatabase.Refresh();

            _existingDataFiles.Add(newSO);
            _gameDataDictionary.Add(id, newSO);

            return newSO;
        }

        #endregion
        #region Public methods

        /// <summary>
        /// Implements method of IGameDataManager<GenericEnumID, SOType> interface
        /// </summary>
        /// <returns></returns>
        public SOType[] GetGameDataArray()
        {
            return _gameDataDictionary.Values.ToArray();
        }

        /// <summary>
        /// Implements method of IGameDataManager<GenericEnumID, SOType> interface
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SOType GetSingleGameDataSO(EnumID id)
        {
            // Debug.Log(name + " | GetSingleGameDataSO " + id);
            //Debug.Log(name + " |  _gameDataDictionary ContainsKey: " + id + " >> " + _gameDataDictionary.ContainsKey(id));
            //return _gameDataDictionary[(EnumID)id];
            return _gameDataDictionary[id];
        }
        
        #endregion
        #region Buttons OnClick listeners

        public void LoadDataToDictionary()
        {
            this.DevLog("BEFORE gameDataDictionary Count: " + _gameDataDictionary.Count);

            _gameDataDictionary.Clear();

            foreach(var dataFromList in _existingDataFiles)
            {
                _gameDataDictionary.Add(dataFromList.ID, dataFromList);
            }

            this.DevLog("AFTER gameDataDictionary Count: " + _gameDataDictionary.Count);
        }

        public void LoadDataFromResources()
        {
            this.DevLog("BEFORE gameDataDictionary Count: " + _gameDataDictionary.Count);

            //_gameDataDictionary.Clear();

            // SOType[] gameDataArray = Resources.FindObjectsOfTypeAll<SOType>();
            //UnityEngine.Object[] dataObjects = Resources.LoadAll<SOType>(PathInResources
            SOType[] dataObjects = Resources.LoadAll<SOType>(PathInResources);
            //dataObjects[0]
            this.DevLog("loaded from Resources Count: " + dataObjects.Length);

            _existingDataFiles = dataObjects.ToList();

            ApplyToAsset();

            // Debug.Log(name + " | loaded from Resources Count: " + gameDataArray.Length);


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
            Debug.Log(name + " | Inits - BEFORE Count: " + _existingDataFiles.Count);

            if (_existingDataFiles.Count == 0)
            {
                LoadDataFromResources();
               
            }

            LoadDataToDictionary();

            Debug.Log(name + " | Inits - AFTER Count: " + _existingDataFiles.Count);
        }

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
