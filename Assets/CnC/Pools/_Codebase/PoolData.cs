using System;

using CnC.Dev;

using UnityEngine;

namespace CnC.Pools
{
    /// <summary>
    /// Used by UFS2.Pools.ObjectPooler
    /// </summary>
    [Serializable]
    public class PoolData<ItemType, PoolEnumID> where ItemType : PoolBase<PoolEnumID>
    {
        #region Private serialized fields

        [Header("Cosmetic name")]
        [SerializeField] private string _convinientName;

        [Header("Prefab containing Component which extends the PoolBase class.")]
        [SerializeField] private ItemType _prefab;

        [Header("Transform to place a new instances of the pool prefab.")]
        [SerializeField] private Transform _targetContainer = null;

        [Space]
        [Header("Initial number of an instances of the prefab in the pool. Minimum: 1")]
        [Range(1, 4096)]
        [SerializeField] private int _initialNumberOfItems = 1;

        [SerializeField] private int _additionalSizeCounter = 0;

        [Space]
        [Header("Auto generated Pool Key to use by GenericPooler")]
        [SerializeField] private string _poolKey = "";

        #endregion

        #region Public getters

        /// <summary>
        /// ReadOnly | getter | returns pattern extending PoolBase provided for this Pool
        /// </summary>
        public ItemType Prefab { get => _prefab; }

        /// <summary>
        /// ReadOnly | getter | returns Transform to setup as parent of fresh instances in the pool provided for this Pool
        /// </summary>
        public Transform TargetContainer { get => _targetContainer; }

        /// <summary>
        /// ReadOnly | getter | returns number of instances in the pool provided for this Pool
        /// </summary>
        public int NumberOfItems { get => _initialNumberOfItems + _additionalSizeCounter; }

        /// <summary>
        /// Read only | getter => key given due using parametric constructor
        /// </summary>
        public string PoolKey { get => _poolKey; }

        #endregion

        #region Public/private properties 

        /// <summary>
        /// 
        /// </summary>
        public PoolEnumID EnumID { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int VariantIndex { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Generic constructor to be using by Unity Editor inspector
        /// </summary>
        public PoolData()
        {
            
        }

        /// <summary>
        /// Designed for using by Gameplay Fish Pool
        /// </summary>
        /// <param name="poolKey"></param>
        /// <param name="initialSize"></param>
        /// <param name="defaultParentContainer"></param>
        public PoolData(PoolEnumID enumID, int variantIndex, string poolKey, int initialSize, Transform defaultParentContainer, GameObject prefab)
        {
            EnumID = enumID;
            VariantIndex = variantIndex;

            _convinientName = typeof(ItemType).Name + " | " + typeof(PoolEnumID).Name + " | " + poolKey;
            _poolKey = poolKey;
            _initialNumberOfItems = initialSize;
            _targetContainer = defaultParentContainer;
            _prefab = prefab.GetComponent<ItemType>(); // TODO: test
        }

        #endregion

        #region Public methods | Changing pool size

        /// <summary>
        /// Updates additional pool size depending on integer parameter
        /// </summary>
        /// <param name="newSize"> integer</param>
        public void ChangePoolSize(int newSize)
        {
            this.DevLog( PoolKey + " wwww  | new size: " + newSize);
            _initialNumberOfItems = newSize;
        }

        /// <summary>
        /// Adds "numberToAdd" value to the additionalSizeCounter
        /// </summary>
        /// <param name="numberToAdd"></param>
        public void AddToPoolSize(int numberToAdd)
        {
            this.DevLog( PoolKey + " wwww | numberToAdd: " + numberToAdd);
            _additionalSizeCounter += numberToAdd;
        }

        /// <summary>
        /// Sets additionalSizeCounter to 0
        /// </summary>
        public void ResetAdditionalPoolSize()
        {

            this.DevLog( PoolKey + " | ResetAdditionalPoolSize | wwww ");
            _additionalSizeCounter = 0;
        }

        #endregion
    }
}