using UnityEngine;

namespace CnC.Pools
{
    public abstract class PoolBase<PoolEnumID> : MonoBehaviour, IPooledObject
    {
        #region Public getters

        /// <summary>
        /// Read only => returns key (string) for the dictionary at <b>GenericPooler</b>
        /// <para>GetType().Name + '_' + PoolEnumIDValue + '_' + PoolVariantIndexValue </para>
        /// <para>example: FFish_Shark_1 </para>
        /// </summary>
        //public string Key { get => GetType().Name + '_' + PoolEnumIDValue + '_' + PoolVariantIndexValue; }
        public string Key
        {
            get
            {
               ///Debug.Log("KEY test >>> " + GetType().Name + '_' + PoolEnumIDValue + '_' + PoolVariantIndexValue);
               return GetType().Name + '_' + PoolEnumIDValue + '_' + PoolVariantIndexValue;
            }
        }

        #endregion

        #region Private fields - generic enum ID & variant index (int)

        private PoolEnumID _poolEnumID;
        private int _poolVariantIndex = 0;

        #endregion

        #region Public getters

        /// <summary>
        /// For example: enum FishSpecies
        /// </summary>
        public PoolEnumID PoolEnumIDValue { get => _poolEnumID; }

        /// <summary>
        /// For example: 0, 1, 2
        /// </summary>
        public int PoolVariantIndexValue { get => _poolVariantIndex;  }

        #endregion

        #region Public methods | virtual | optionaly overriden by derived classes

        /// <summary>
        /// For use by GenericPooler.InitPools()
        /// <para>Sets pool ID (enum) and pool variant index (int)</para>
        /// </summary>
        /// <param name="poolEnumID"></param>
        /// <param name="poolVariantIndexValue"></param>
        public void Init(PoolEnumID poolEnumID, int poolVariantIndexValue)
        {
            _poolEnumID = poolEnumID;
            _poolVariantIndex = poolVariantIndexValue;
        }

        /// <summary>
        /// <para>Activates the Game Gbject by callig <b>SetActive(true)</b>.</para>
        /// <para>Can by overriden - it is a virtual method</para>
        /// <para>NOTE: Overriding method should call the base method.</para>
        /// <para>Example: <b>base.OnSpawn(poolEnumID, poolVariantIndex, initParameters);</b></para>
        /// <para>Due to fact that initParameter will be passed to overriding methods, by overriding of the OnSpawn() method you can Provide the list (array) of the initial parameters of various types. </para>
        /// </summary>
        public virtual void OnSpawn(PoolEnumID poolEnumID, int poolVariantIndex, params object[] initParameters)
        {
            _poolEnumID = poolEnumID;
            _poolVariantIndex = poolVariantIndex;
#if UNITY_EDITOR
            Debug.Log(name + " | OnSpawn | poolEnumID " + poolEnumID + " | poolVariantIndex " + poolVariantIndex + " | >> ");
            //Debug.Log(name + " | OnSpawn | parameters " + initParameters + " | >>> ");
#endif

            gameObject.SetActive(true);
        }

        /// <summary>
        /// <para>Deactivates the Game Gbject by callig <b>SetActive(false)</b>.</para>
        /// <para>Can by overriden - it is a virtual method</para>
        /// <para>NOTE: Overriding method should call the base method. Example: <b>base.OnReturnToPool()</b></para>
        /// </summary>
        public virtual void OnReturnToPool()
        {
            gameObject.SetActive(false);
        }

        public virtual void UpdateContent(params object[] currentValues)
        {

        }

        #endregion

        #region Public methods | abstract | have to be overriden by derived classes



        #endregion

    }
}
