/// dystop.us | 08.02.2023
#if UNITY_EDITOR

using System;

using UnityEngine;
using UnityEditor;

using CnC.Utils;

namespace CnC.GameData
{
    public abstract class CustomSOManagerEditor<TargetType, GenericEnumID, SOType> : DevEditor<TargetType> where TargetType : ScriptableObject
    {
        #region Public getters

        /// <summary>
        /// The type of returning object implements the IGameDataManager<> generic interface
        /// </summary>
        public IGameDataManager<GenericEnumID, SOType> DataManager { get => (IGameDataManager<GenericEnumID, SOType>)Target; }

        #endregion

        #region Protected Methods to inherit

        /// <summary>
        /// Adds Button for Loading GameData TO DICTIONARY due to interface IGameDataManager
        /// </summary>
        protected void AddLoadGameDataToDictionaryButton()
        {
            AddButtonForLoadGameData(DataManager.LoadDataToDictionary, typeof(GenericEnumID).Name, "to Dictionary");
        }

        /// <summary>
        /// Adds Button for Loading GameData FROM RESOURCES due to interface IGameDataManager
        /// </summary>
        protected void AddLoadGameDataFromResourcesButton()
        {
            AddButtonForLoadGameData(DataManager.LoadDataFromResources, typeof(GenericEnumID).Name, "from Resources");
        }

        #endregion

       

        /*
         * OLD version of code. TODO: remove 
        /// <summary>
        /// Adds Button for Loading GameData TO DICTIONARY due to interface IGameDataManager
        /// </summary>
        /// <param name="dataManager"></param>
        protected void AddLoadGameDataToDictionaryButton(IGameDataManager<GenericEnumID, SOType> dataManager)
        {
            if (GUILayout.Button("Load [ " + typeof(GenericEnumID).Name + " ] Data to Dictionary"))
            {
                dataManager.LoadDataToDictionary();
            }
        }

        /// Adds Button for Loading GameData FROM RESOURCES due to interface IGameDataManager
        protected void AddLoadGameDataFromResourcesButton(IGameDataManager<GenericEnumID, SOType> dataManager)
        {
            if (GUILayout.Button("Load [ " + typeof(GenericEnumID).Name + " ] Data from Resources"))
            {
                dataManager.LoadDataFromResources();
            }
        }
        */
    }
}

#endif