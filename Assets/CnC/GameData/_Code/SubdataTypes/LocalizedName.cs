/// dystop.us | 08.02.2023
using System;
using UnityEngine;

namespace CnC.GameData
{
    [Serializable]
    public class LocalizedName 
    {
        [SerializeField] private string _nameLanguageKey = "";

        [SerializeField] private string _nameLanguageEnglish = "";
        [SerializeField] private string _nameLanguagePolish = "";
        
        /// <summary>
        /// OLD: name_language_key
        /// </summary>
        public string NameLanguageKey{ get => _nameLanguageKey; }

        /// <summary>
        /// OLD: name_language_key
        /// </summary>
        public string NameLanguageEnglish { get => _nameLanguageEnglish; }

        public string NameLanguagePolish { get => _nameLanguagePolish; }

        #region Constructors

        public LocalizedName(string nameLanguageKey)
        {
            _nameLanguageKey = nameLanguageKey;
        }

        public LocalizedName(string nameLanguageEnglish, string nameLanguagePolish)
        {
            _nameLanguageEnglish = nameLanguageEnglish;
            _nameLanguagePolish = nameLanguagePolish;
        }

        #endregion

        /// <summary>
        /// Uses _nameLanguageKey and LanguageManager
        /// </summary>
        /// <returns></returns>
        public string GetLocalizedName()
        {
            //Debug.Log("LOCALIZED NAME | language_key:" + _nameLanguageKey + "\tfish name: " + LanguageManager.Instance.GetText(_nameLanguageKey));
            return _nameLanguageKey; // LanguageManager.Instance.GetText(_nameLanguageKey);
        }

        /*
        public string GetName()
        {
            string ret = name;

            switch (I2.Loc.LocalizationManager.CurrentLanguage)
            {
                case "English":
                    if (!string.IsNullOrEmpty(name_language_EN)) ret = name_language_EN;
                    break;

                case "Polish":
                    if (!string.IsNullOrEmpty(name_language_PL)) ret = name_language_PL;
                    break;
            }

            return ret;
        }
        */
    }
}
