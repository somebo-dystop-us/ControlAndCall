/// dystop.us | 08.02.2023

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CnC.GameData
{
    public class GameDataBaseSO<EnumID, EnumType> : ScriptableObject
    {

        [SerializeField] protected EnumID _enumID;
        [SerializeField] protected EnumType _type;

        [SerializeField] protected LocalizedName _localizedName;// = new LocalizedName();
        [SerializeField] protected LocalizedDescription _localizedDescription;// = new LocalizedDescription();


        public EnumID ID
        {
            get { return _enumID; }
        }

        public EnumType type // TODO: rename to TypeOfFish
        {
            get { return _type; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void SetupId(EnumID id)
        {
           _enumID = id;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        public void SetupType(EnumType enumType)
        {
            _type = enumType;
        }

        public void SetNameKey(string nameKey)
        {
            _localizedName = new LocalizedName(nameKey);
        }

        public void SetDescriptionKey(string descriptionKey)
        {
            _localizedDescription = new LocalizedDescription(descriptionKey);
        }

        public void SetNameEnglishAndPolish(string nameEnglish, string namePolish)
        {
            _localizedName = new LocalizedName(nameEnglish, namePolish);
        }

        /// <summary>
        /// TODO: editors only - protect from be used from build 
        /// </summary>
        protected void ApplyToAsset()
        {
#if UNITY_EDITOR
            EditorUtility.SetDirty(this);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
#endif
        }
    }
}
