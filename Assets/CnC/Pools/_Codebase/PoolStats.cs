/// dystop.us | 08.02.2023
namespace CnC.Pools
{
    /// <summary>
    /// Data helper class | Stores informations about generic pool status.
    /// <para>Stored data:</para>
    /// <para>* number of all pooled items</para>
    /// <para>* number of active ones</para>
    /// </summary>
    public class PoolStats 
    {
        #region Public/private properties

        /// <summary>
        /// Number of <b>all PoolBase instances</b> existed in the pool
        /// </summary>
        public int NumberOfAllPooledItems { get; private set; }

        /// <summary>
        /// Number of <b>active PoolBase instances</b> existed in the pool
        /// </summary>
        public int NumberOfActiveItems { get; private set; }

        /// <summary>
        /// Number of <b>inactive PoolBase instances</b> existed in the pool
        /// </summary>
        public int NumberOfAvailableItems { get => NumberOfAllPooledItems - NumberOfActiveItems; }

        #endregion

        #region Constructor

        /// <summary>
        /// Stores values of parameters int the private fields
        /// <para>"numberOfAllItems" | optional: 0 if not provided</para>
        /// <para>"numberOfActiveItems" | optional: 0 if not provided</para>
        /// </summary>
        /// <param name="numberOfAllItems">optional, default: 0 </param>
        /// <param name="numberOfActiveItems">optional, default: 0 </param>
        public PoolStats(int numberOfAllItems = 0, int numberOfActiveItems = 0)
        {
            NumberOfAllPooledItems = numberOfAllItems;
            NumberOfActiveItems = numberOfActiveItems;
        }

        #endregion

    }
}
