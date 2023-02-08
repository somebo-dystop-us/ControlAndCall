using System;

using UnityEngine;

namespace CnC.GameData
{
    [Serializable]
    public class LocalizedDescription
    {
        [SerializeField] private string _descriptionLangKey = "";
        [SerializeField] private string _descriptionLangKeyShort = "";
        [SerializeField] private string _descriptionLangKeyFull = "";

        public string DescriptionLangKey
        {
            get => _descriptionLangKey;
        }

        public string DescriptionLangKeyShort
        {
            get => _descriptionLangKeyShort;
        }

        public string DescriptionLangKeyFull
        {
            get => _descriptionLangKeyFull;
        }

        #region Constructors

        public LocalizedDescription(string descriptionLangKey, string descriptionLangKeyShort = "", string descriptionLangKeyFull = "")
        {
            _descriptionLangKey = descriptionLangKey;
            _descriptionLangKeyShort = descriptionLangKeyShort;
            _descriptionLangKeyFull = descriptionLangKeyFull;
        }

        public LocalizedDescription(string descriptionLangKeyShort, string descriptionLangKeyFull)
        {
            _descriptionLangKeyShort = descriptionLangKeyShort;
            _descriptionLangKeyFull = descriptionLangKeyFull;
        }

        #endregion

        /// <summary>
        /// Used by:
        /// * 
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return "Foo";// LanguageManager.Instance.GetText(DescriptionLangKey);
        }

        /// <summary>
        /// Used by:
        /// * FishingRodSO
        /// </summary>
        /// <param name="descriptionType"></param>
        /// <returns></returns>
        public string GetDescription(DescriptionType descriptionType = DescriptionType.SHORT)
        {
            /*
            if (descriptionType == DescriptionType.SHORT)
            {
                if (string.IsNullOrEmpty(DescriptionLangKeyShort)) return "";
                return LanguageManager.Instance.GetText(DescriptionLangKeyShort);
            }

            if (descriptionType == DescriptionType.FULL)
            {
                if (string.IsNullOrEmpty(DescriptionLangKeyFull)) return "";
                return LanguageManager.Instance.GetText(DescriptionLangKeyFull);
            }
            */
            return "desription incorect type";

        }

        /// <summary>
        /// Embedded enum
        /// </summary>
        public enum DescriptionType
        {
            SHORT,
            FULL,
            FISHATRACTIVE
        }
    }
}
