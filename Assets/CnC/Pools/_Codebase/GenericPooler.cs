/// dystop.us | 08.02.2023
using System;
using System.Collections.Generic;
using System.Linq;

using CnC.Dev;
using CnC.GameData;
using CnC.Utils;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace CnC.Pools
{

    /// <summary>
    /// Universal object pooler. Implements Pool Pattern. 
    /// <para>Calls OnSpawn method of IPooledObject interface.</para>
    /// <para>Listens for Pause event to disable all pooled objects.</para>
    /// </summary>
    [Serializable]
    public class GenericPooler<ItemType, EnumType> : MonoBehaviour //MonoSingleton<GenericPooler<ItemType, EnumType>>
        where ItemType : PoolBase<EnumType>
    {

        #region Public static Utilities

        /// <summary>
        /// Converts <b>GenericType</b> with values of <b>EnumType</b> and <b>int</b> into the generic key string
        /// <para>NOTE: Related with PoolBase for PoolEnumID</para>
        /// <para>public string Key { get => GetType().Name + '_' + PoolEnumIDValue + '_' + PoolVariantIndexValue; }</para>
        /// </summary>
        /// <typeparam name="GenericType"></typeparam>
        /// <param name="enumTypeValue"></param>
        /// <param name="variantIndexValue"></param>
        /// <returns></returns>
        public static string GetKeyByType<GenericType>(EnumType enumTypeValue, int variantIndexValue = 0)
        {
            //Debug.Log("POOL KEY test >>> " + typeof(GenericType).Name + '_' + enumTypeValue + '_' + variantIndexValue);
            return typeof(GenericType).Name + '_' + enumTypeValue + '_' + variantIndexValue;
        }

        #endregion

        #region Protected | Serialized fields

        [Header("Pool Bases to being pooled")]
        [SerializeField] protected List<PoolData<ItemType, EnumType>> _poolsList;

        [Space]
        [SerializeField] protected Transform _poolRoot;

        [Space]
        [Header("Developer mode")]
        [SerializeField] protected bool _isDebug = false;

        #endregion

        #region Public getters

        /// <summary>
        /// Pooled GameObjects will be spawned as a children of this Transform at game loading
        /// </summary>
        public Transform PoolRoot { get { return _poolRoot; } }

        public List<PoolData<ItemType, EnumType>> PoolsList { get => _poolsList; }

        public Dictionary<string, Queue<ItemType>> PoolDictionary { get => _poolDictionary; }

        #endregion

        #region Public/protected properties

        /// <summary>
        /// 
        /// </summary>
        public bool IsReady { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public bool HavePoolsStatsChanged { get; protected set; }

        #endregion

        #region Protected fields | Pool Dictionary

        protected Dictionary<string, Queue<ItemType>> _poolDictionary;

        #endregion

        #region MonoBehaviour callbacks



        #endregion

        #region Public methods | Init() & SpawnFromPool() & ReturnToPool()

        /// <summary>
        /// <para>* Checks if there is provided any pool root transform.</para>
        /// <para>* Fills pools with PoolBase instances</para>
        /// </summary>
        public void Init()
        {
            InitPooler();
            InitPools();
        }


        /// <summary>
        /// Checks if there is provided pool for <b>GenericType</b> types. 
        /// <para>If there is any then returns another single instance of the GenericType from the pool.</para>
        /// <para>Calls <b>OnSpawn(targetContainer)</b> method.</para>
        /// </summary>
        /// <param name="targetContainter"></param>
        /// <returns>The returning value can be null if there is no any existing pool provided for <b>GenericType</b></returns>
        public GenericType SpawnFromPool<GenericType>(EnumType poolEnum, int poolVariantIndex, params object[] initParameters) where GenericType : ItemType
        {
            //gameObject.DevLog(name + " | SPAWN TEST | >> enum " + poolEnum + " | int " + poolVariantIndex);

            if (!CheckPoolByType<GenericType>(poolEnum, poolVariantIndex))
            {
                return null;
            }

            var selectedPoolKey = GetKeyByType<GenericType>(poolEnum, poolVariantIndex);

            //gameObject.DevLog(name + " | BEFORE >>  SPAWN | Pool key: " + selectedPoolKey + " | Count: " + _poolDictionary[selectedPoolKey].Count + " | >> ");

            if (_poolDictionary[selectedPoolKey].All(genericObject => genericObject.isActiveAndEnabled))
            {
               // gameObject.DevLog(name + " | AddNewInstanceToPool | " + selectedPoolKey + " | >> ");

                AddNewInstanceToPool(_poolsList.Find(p => p.Prefab.Key == selectedPoolKey), _poolDictionary[selectedPoolKey]);
            }

            ItemType genericFromPool = RemoveFromQueue(_poolDictionary[selectedPoolKey]); //poolDictionary[selectedPoolKey].Dequeue(); // - DEQUEUE
            genericFromPool.OnSpawn(poolEnum, poolVariantIndex, initParameters); 

            AddToQueue(genericFromPool, _poolDictionary[selectedPoolKey]); //poolDictionary[selectedPoolKey].Enqueue(genericFromPool); // + ENQUEUE

          //  gameObject.DevLog(name + " | AFTER >>  SPAWN | Pool key: " + selectedPoolKey + " | Count: " + _poolDictionary[selectedPoolKey].Count + " | >> ");

            return (GenericType)genericFromPool;
        }
        
        /// <summary>
        /// <para>* Checks if pool with assigned key exists.</para>
        /// <para>* Calls <b>OnReturnToPool()</b></para>
        /// <para>* Calls <b>AddToQueue()</b></para>
        /// </summary>
        /// <param name="returningPoolBase"></param>
        public void ReturnToPoolBase(ItemType returningPoolBase)
        {
            if (!CheckPoolByKey(returningPoolBase.Key))
            {
                return;
            }

            returningPoolBase.OnReturnToPool();

            AddToQueue(returningPoolBase, _poolDictionary[returningPoolBase.Key]); //poolDictionary[returningPoolBase.Key].Enqueue(returningPoolBase);
        }
        
        #endregion

        #region Public methods | SwitchActivityStateOfAllPooledObjects & GetCurrentPoolCount

        /// <summary>
        /// Deactivates/activates all of pooled objects by iterating <b>dictionary</b> first and then <b>queue</b> of a GameObjects
        /// </summary>
        /// <typeparam name="GenericType"></typeparam>
        /// <param name="isActive"></param>
        /// <param name="poolEnumIDValue"></param>
        /// <param name="poolVariantIndexValue">optional | default : 0</param>
        public void SwitchActivityStateOfAllPooledObjects<GenericType>(bool isActive, EnumType poolEnumIDValue, int poolVariantIndexValue = 0)
        {
            if (CheckPoolByType<GenericType>(poolEnumIDValue, poolVariantIndexValue))
            {
                return;
            }

            Queue<ItemType>.Enumerator enumerator = _poolDictionary[GetKeyByType<GenericType>(poolEnumIDValue, poolVariantIndexValue)].GetEnumerator();

            while (enumerator.MoveNext())
            {
                enumerator.Current.gameObject.SetActive(isActive);
            }
        }

        #endregion

        #region Public/protected methods | GetCurrentPoolSize() & GetNumberOfActiveItems() & GetPoolSize()

        /// <summary>
        /// Public getter | Returns current queue Count property value
        /// </summary>
        /// <param name="poolKey"></param>
        /// <returns>Value of current queue <b>Count</b> property</returns>
        public int GetCurrentPoolSize(string poolKey)
        {
            //this.DevLog("test xxx | poolKey: " + poolKey + " | in dictionary? " + _poolDictionary.ContainsKey(poolKey));
            //return (poolDictionary != null && poolDictionary.TryGetValue(poolKey, out testValue)) ? poolDictionary[poolKey].Count : 0;
            return _poolDictionary[poolKey].Count;
        }

        /// <summary>
        /// Version for an internal usege. // Returns current queue Count property value
        /// </summary>
        /// <typeparam name="GenericType"></typeparam>
        /// <param name="poolEnumIDValue"></param>
        /// <param name="poolVariantIndexValue"></param>
        /// <returns>Number of currently existing items in the given pool.</returns>
        protected int GetCurrentPoolSize<GenericType>(EnumType poolEnumIDValue, int poolVariantIndexValue)
        {
            var poolKey = GetKeyByType<GenericType>(poolEnumIDValue, poolVariantIndexValue);
            return GetCurrentPoolSize(poolKey);
        }

        /// <summary>
        /// Public getter | Calculates how many items in the pool are ACTIVE and ENABLED
        /// </summary>
        /// <param name="poolKey"></param>
        /// <returns>Number of currently existing items in the pool given BY KEY.</returns>
        public int GetNumberOfActivePooledItems(string poolKey)
        {
            return (_poolDictionary != null && _poolDictionary.ContainsKey(poolKey)) ? _poolDictionary[poolKey].Where(item => item.isActiveAndEnabled).Count() : 0;
        }

        /// <summary>
        /// Version for an internal usege. | Calculates how many items in the pool are ACTIVE and ENABLED
        /// </summary>
        /// <typeparam name="GenericType"></typeparam>
        /// <param name="poolEnumIDValue"></param>
        /// <param name="poolVariantIndexValue"></param>
        /// <returns>Number of currently existing items in the pool.</returns>
        protected int GetNumberOfActivePooledItems<GenericType>(EnumType poolEnumIDValue, int poolVariantIndexValue)
        {
            var poolKey = GetKeyByType<GenericType>(poolEnumIDValue, poolVariantIndexValue);
            return GetNumberOfActivePooledItems(poolKey);
        }

        /// <summary>
        /// <para>* Generates pool <b>key</b> depending on provided Generic Type, <b>enum ID</b> value and variant index (optional).</para>
        /// <para>* Gets current pool size and a number of an active items in the pool.</para>
        /// <para>* Creates and returns instance of PoolStats for the above data.</para>
        /// </summary>
        /// <typeparam name="GenericType"></typeparam>
        /// <param name="poolEnumIDValue"></param>
        /// <param name="poolVariantIndexValue"></param>
        /// <returns> Instance of PoolStats for the current pool size and a number of an active items in the pool.</returns>
        public PoolStats GetPoolStats<GenericType>(EnumType poolEnumIDValue, int poolVariantIndexValue = 0 )
        {
            var poolKey = GetKeyByType<GenericType>(poolEnumIDValue, poolVariantIndexValue);
            return GetCurrentPoolStatsForKey(poolKey);
        }

        public PoolStats GetCurrentPoolStatsForKey(string poolKey)
        {
            int currentPoolSize = GetCurrentPoolSize(poolKey);
            int numberOfActiveItems = GetNumberOfActivePooledItems(poolKey);
            return new PoolStats(currentPoolSize, numberOfActiveItems);
        }

        /// <summary>
        /// Debug helper
        /// </summary>
        public void LogGenericKeys()
        {
            this.DevLog("LogGenericKeys()");

            foreach (var poolEntry in _poolDictionary)
            {
                this.DevLog("Pool Dictionary | key:" + poolEntry.Key);
            }

            foreach (var pool in _poolsList)
            {
                this.DevLog("Pool List | key:" + pool.PoolKey);
            }
        }

        #endregion

        #region Protected methods - Initialisation 

        protected void InitPooler()
        {
            if (_poolRoot == null)
            {
                _poolRoot = transform;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumID"></param>
        /// <param name="variantIndex"></param>
        /// <param name="initialPoolSize"></param>
        /// <param name="defaultContainer"></param>
        protected PoolData<ItemType, EnumType> AddPoolForIDAndIndex(EnumType enumID, int variantIndex, short initialPoolSize, Transform defaultContainer, GameObject poolPrefab)
        {
            var poolKey = GetKeyByType<ItemType>(enumID, variantIndex);

            PoolData<ItemType, EnumType> freshPool = new PoolData<ItemType, EnumType>(enumID, variantIndex, poolKey, initialPoolSize, defaultContainer, poolPrefab);

            _poolsList.Add(freshPool);
             
            return freshPool;
        }

        protected void InitPools()
        {
            //this.DevLog("Init Pools test ");

            _poolDictionary = new Dictionary<string, Queue<ItemType>>();

            // For each Pool listed in the prefab at component's serializable list
            foreach (var poolFromList in _poolsList)
            {
                _poolDictionary.Add(poolFromList.PoolKey, new Queue<ItemType>());
            }

            ApplyAllQueueSizes();
        }

        protected void ChangePoolSize(string poolKey, int newSize)
        {
            
        }

        #endregion
         
        #region Protected methods | Apply All Queue Sizes

        /// <summary>
        /// <para>* Compares Pool.NumberOfItems with number of the currently pooled items for each queue in dictionary.</para> 
        /// <para>* Adds/removes items from each queue depending on the result of the previous comparison. </para> 
        /// </summary>
        protected void ApplyAllQueueSizes()
        {
            //int currentNumberOfInstances;

            foreach (var poolFromList in _poolsList)
            {
                int currentNumberOfInstances = _poolDictionary[poolFromList.PoolKey].Count;
                int differenceToTargetNumber = poolFromList.NumberOfItems - currentNumberOfInstances;

                /*
                this.DevLog("test "
                        + " | key: " + poolFromList.Prefab.Key
                        + " | Number of items: " + poolFromList.NumberOfItems 
                        + " | currentNumberOfInstances: " + currentNumberOfInstances
                        + " | difference: " + differenceToTargetNumber);
                */
                if (differenceToTargetNumber != 0) // if there has been a change in the size of the current pool
                {

                    //this.DevLog("qqq ApplyAllQueueSizes() | difference: " + differenceToTargetNumber);

                    if (differenceToTargetNumber > 0) // if there are fewer items than there should be in the current pool
                    {
                        AddNumberOfInstances(poolFromList, _poolDictionary[poolFromList.PoolKey], differenceToTargetNumber);
                    }
                    else // if there are too many items in the current pool
                    {
                        RemoveFromQueue(_poolDictionary[poolFromList.PoolKey]);
                    }
                }

            }
        }

        /// <summary>
        /// For each PoolData existing PoolsList sets additionalSizeCounter to 0
        /// </summary>
        protected void ResetAdditionalPoolSizes()
        {
            foreach(var poolFromList in _poolsList)
            {
                poolFromList.ResetAdditionalPoolSize();
            }
        }

        #endregion

        #region Protected methods | Add/removes number of Instances to/from POOL

        protected void AddNumberOfInstances(PoolData<ItemType, EnumType> pool, Queue<ItemType> queue, int numberOfInstancesToAdd)
        {
            for (int i = 0; i < numberOfInstancesToAdd; i++)
            {
                AddNewInstanceToPool(pool, queue);
            }
        }

        protected void RemoveNumberOfInstances(Queue<ItemType> queue, int numberOfInstancesToRemove)
        {
            for (int i = 0; i < numberOfInstancesToRemove; i++)
            {
                RemoveFromQueue(queue);
            }
        }

        #endregion

        #region Protected methods | Add New Instance to POOL /


        /// <summary>
        /// <para>* Creates new instance.</para>
        /// <para>* Calls OnReturnToPool().</para>
        /// <para>* Adds to pool. </para>
        /// <para> Optional parameter "isSilent" - Calls OnReturnToPool() if set to false </para>
        /// </summary>
        /// <param name="poolData"></param>
        /// <param name="queue"></param>
        /// <param name="isSilent">optional | Calls OnReturnToPool() if set to false</param>
        protected void AddNewInstanceToPool(PoolData<ItemType, EnumType> poolData, Queue<ItemType> queue, bool isSilent = false)
        {
           // gameObject.DevLog( "AddNewInstanceToPool | " + pool + " | test ");

            ItemType freshBase = CreateInstance(poolData);
            freshBase.Init(poolData.EnumID, poolData.VariantIndex);
            freshBase.gameObject.SetActive(false);

            if (!isSilent)
            {
                freshBase.OnReturnToPool();
            }
            
            AddToQueue(freshBase, queue);
        }

        protected ItemType CreateInstance(PoolData<ItemType, EnumType> pattern)
        {
            return Instantiate(pattern.Prefab, pattern.TargetContainer != null ? pattern.TargetContainer : _poolRoot, false);
        }

        #endregion

        #region Protected methods | Add to / remove from QUEUE

        /// <summary>
        /// <para>* Enqueue "newItem" to "queue"</para>
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="queue"></param>
        protected void AddToQueue(ItemType newItem, Queue<ItemType> queue)
        {
            //gameObject.DevLog("AddToPool | " + newItem + " | >> ");

            queue.Enqueue(newItem);
        }

        /// <summary>
        /// <para>* Dequeue item to queue</para>
        /// </summary>
        /// <param name="queue"></param>
        /// <returns>Returns item removed from the pool queue</returns>
        protected ItemType RemoveFromQueue(Queue<ItemType> queue)
        {
            //gameObject.DevLog("RemoveFromQueue | " + queue + " | >> ");

            return queue.Dequeue();
        }

        #endregion

        #region Protected/private methods | Utils

        /// <summary>
        /// Checks if there is pool provided for GenericType, enum and index values
        /// </summary>
        /// <typeparam name="GenericType"></typeparam>
        /// <param name="enumTypeValue"></param>
        /// <param name="variantIndexValue"></param>
        /// <returns></returns>
        private bool CheckPoolByType<GenericType>(EnumType enumTypeValue, int variantIndexValue)
        {
            string typeName = GetKeyByType<GenericType>(enumTypeValue, variantIndexValue);

            //gameObject.DevLog("CheckPoolByType >> | enumTypeValue " + enumTypeValue + " |  variantIndexValue " + variantIndexValue);

            return CheckPoolByKey(typeName);
        }

        protected bool CheckPoolByKey(string keyToCheck)
        {
            if (!_poolDictionary.ContainsKey(keyToCheck))
            {
                this.DevLog("Warning: Pool of type \"" + keyToCheck + "\" does not exists");
                return false;
            }

            //gameObject.DevLog("Pool of type \"" + keyToCheck + "\" counts " + _poolDictionary[keyToCheck].Count);
            return true;
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