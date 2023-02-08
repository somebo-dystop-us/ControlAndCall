using System;
using CnC.Legacy;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CnC.GameData
{
    public class FishingEquipmentBaseSO<GenericEnumID, GenericEnumType> : ScriptableObject 
    {
        #region Protected / inspector fields

        [Header("OLD: GameManager.ItemType")]
        [SerializeField] protected EquipmentItemType _equipmentItemType;

        [Header("*")]
        [SerializeField] protected string _name;

        [Header("*")]
        [SerializeField] protected GenericEnumID _id;

        [Header("*")]
        [SerializeField] protected LocalizedName _localizedName;

        [Header("*")]
        [SerializeField] protected LocalizedDescription _localizedDescription;

        [Header("*")]
        [SerializeField] protected ModelsPaths _modelPaths;

        [Header("*")]
        [SerializeField] protected ImagesPaths _imagesPaths;

        [Header("*")]
        [SerializeField] protected GenericEnumType _type;

        [Header("*")]
        [SerializeField] protected int _requiredLevel;

        /// <summary>
        /// Information as isInShop, isNew, PriceNormal and SaleOff, also amount (mostly = 1)
        /// </summary>
        [SerializeField] protected StoreItemInfo _storeItemInfo;

        #endregion

        #region Public getters for legacy purposes mostly

        /// <summary>
        /// Replacement of GameManager.ItemType
        /// </summary>
        public EquipmentItemType equipmentItemType { get => _equipmentItemType; }

        /// <summary>
        /// LEGACY: public string name;
        /// </summary>
        public new string name { get => _name; }

        /// <summary>
        /// LEGACY: public int id = 0;
        /// </summary>
        public int id { get => Convert.ToInt32(_id); }

        /// <summary>
        /// ID is not just a number but an enum
        /// </summary>
        public GenericEnumID enumID { get => _id; }

        /// <summary>
        /// LEGACY: public string name_language_key = "";
        /// </summary>
        public string name_language_key { get => _localizedName.NameLanguageKey; }

        /// <summary>
        /// LEGACY: public Type type = Type.Universal;
        /// NOTES: generic enum type differs generic enum ID
        /// </summary>
        public GenericEnumType type { get => _type; }

        /// <summary>
        /// LEGACY:  public int Level = 1;
        /// </summary>
        public int Level { get => _requiredLevel; }

        /// <summary>
        /// LEGACY: public string modelPath = "Models/Rods/"; //sciezka do modelu w Resources
        /// </summary>
        public string modelPath { get => _modelPaths.modelPath; }

        /// <summary>
        /// LEGACY: public string model3dViewPath = "Models/Rods/"; //sciezka do modelu w Resources
        /// </summary>
        public string model3dViewPath { get => _modelPaths.model3dViewPath; }

        /// <summary>
        /// LEGACY: public string imagePath = "Icons/Rods/"; //sciezka do ikony w Resources
        /// </summary>
        public string imagePath { get => _imagesPaths.imagePath; }

        /// <summary>
        /// LEGACY: public string logoBrandImagePath = ""; //sciezka do loga firmowego
        /// </summary>
        public string logoBrandImagePath { get => _imagesPaths.logoBrandImagePath; }

        /// <summary>
        /// LEGACY: public string[] imageRendersPath; //sciezka do renderów w Resources
        /// </summary>
        public string[] imageRendersPath { get => _imagesPaths.imageRendersPath; }

        /// <summary>
        /// LEGACY:  public bool isComimngSooon = true;
        /// </summary>
        public bool isComingSoon { get => _storeItemInfo.IsComingSoon; }

        /// <summary>
        /// LEGACY: public bool isInShop = true;
        /// </summary>
        public bool isInShop { get => _storeItemInfo.IsInShop; }

        /// <summary>
        /// LEGACY: public bool isNew = false; //nowoœæ
        /// </summary>
        public bool isNew { get => _storeItemInfo.IsNew; }

        /// <summary>
        /// LEGACY: public int PriceNormal;
        /// </summary>
        public int PriceNormal { get => _storeItemInfo.PriceNormal; }

        /// <summary>
        /// LEGACY: public int SaleOff = 0; //promocja, procent obni¿ki
        /// </summary>
        public int SaleOff { get => _storeItemInfo.SaleOff; }

        /// <summary>
        /// LEGACY: public int amount = 1; // ilosc w pakiecie
        /// </summary>
        public float amount { get => _storeItemInfo.Amount; }

        #endregion

        #region Protected/public "setters" for subdata types - EQUIPMENT ITEM TYPE & NAME & ID

        protected void SetEquipmentItemType(EquipmentItemType equipmentItemType)
        {
            _equipmentItemType = equipmentItemType;
        }

        protected void SetName(string name)
        {
            _name = name;
        }

        /// <summary>
        /// This one is public because of using be DataManagerBaseSO method
        /// </summary>
        /// <param name="id"></param>
        public void SetId(GenericEnumID id)
        {
           _id = id;
        }

        #endregion

        #region Protected "setter" for subdata types - TYPE

        protected void SetType(GenericEnumType enumType)
        {
            _type = enumType;
        }

        #endregion

        #region Protected "setters" for subdata types - LOCALIZED NAME & DESCRIPTION
        protected void SetupNameKey(string nameKey)
        {
            _localizedName = new LocalizedName(nameKey);
        }

        protected void SetupDescriptionKey(string descriptionKey)
        {
            _localizedDescription = new LocalizedDescription(descriptionKey);
        }

        protected void SetupDescriptionKeysPair(string descriptionKeyShort, string descriptionKeyFull)
        {
            _localizedDescription = new LocalizedDescription(descriptionKeyShort, descriptionKeyFull);
        }

        protected void SetupNameEnglishAndPolish(string nameEnglish, string namePolish)
        {
            _localizedName = new LocalizedName(nameEnglish, namePolish);
        }

        #endregion

        #region Protected "setters" for subdata types - MODELS & IMAGES PATHS

        protected void SetupModelsPaths(string modelPath, string model3dViewPath)
        {
            _modelPaths = new ModelsPaths(modelPath, model3dViewPath);
        }

        protected void SetupImagesPaths(string imagePath, string logobrandImagePath, string[] imageRendersPath)
        {
            _imagesPaths = new ImagesPaths(imagePath, logobrandImagePath, imageRendersPath);
        }

        #endregion

        #region Protected "setters" for subdata types - STORE INFO

        /// <summary>
        /// Creates new instance of StoreItemInfo (to store information like "isNew" or "saleOff" values)
        /// </summary>
        /// <param name="isInShop"></param>
        /// <param name="isNew"></param>
        /// <param name="priceNormal"></param>
        /// <param name="saleOff"></param>
        /// <param name="amount">optional - if not provided then set to 1</param>
        protected void SetupStoreInfo(bool isInShop, bool isNew, int priceNormal, int saleOff, float amount = 1)
        {
            _storeItemInfo = new StoreItemInfo(isInShop, isNew, priceNormal, saleOff, amount);
        }

        #endregion

        #region Public methods

       

        /// <summary>
        /// LEGACY: public string GetGameItemName(EquipmentItemType itemType, int itemID)
        /// </summary>
        /// <returns></returns>
        public string GetItemName()
        {
            return name; //return name_language_key != "" ? LanguageManager.Instance.GetText(name_language_key) : name;
        }

        /// <summary>
        /// LEGACY: //pobiera prefab z resources
        /// public GameObject GetModelPrefab()
        /// </summary>
        /// <returns></returns>
        public GameObject GetModelPrefab()
        {
            return _modelPaths.GetModelPrefab();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public GameObject Get3DModelViewPrefab()
        {
            return _modelPaths.Get3DModelViewPrefab();
        }


        /// <summary>
        /// LEGACY
        /// </summary>
        /// <returns></returns>
        public Sprite GetIconImage()
        {
            return _imagesPaths.GetIconImage();
        }

        public Sprite GetLogoBrandImage()
        {
            return _imagesPaths.GetLogoBrandImage();
        }

        /// <summary>
        /// LEGACY
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Sprite GetRenderImage(int index)
        {
            return _imagesPaths.GetRenderImage(index);
        }

        /// <summary>
        /// LEGACY: public float GetPrice()
        /// </summary>
        /// <returns></returns>
        public float GetPrice()
        {
            return _storeItemInfo.GetPrice();
        }


        #endregion

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
