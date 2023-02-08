
namespace CnC.Pools
{
    /// <summary>
    /// Interface using by ObjectPooler.
    /// <para>Note: This interface should be implemented in each MonoBehavior intended for pooling.</para>
    /// </summary>
    public interface IPooledObject
    {
        /// <summary>
        /// Called by SpawnFromPool() methods
        /// </summary>
       //

        //void OnReturnToPool();
    }
}