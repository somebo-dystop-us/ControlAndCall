/// dystop.us | 08.02.2023
using CnC.Pools;
using CnC.Utils;

using UnityEngine;

namespace CnC.GameData
{
    public class GameDataManager : MonoSingleton<GameDataManager>
    {
        #region Inspector fields

        [Header("Debug Mode")]
        [SerializeField] private bool _isDebug = false;
        /*
        [Space]
        [Header("Game Data - FISH SPECIES")]
        [SerializeField] private FishSpeciesDataManagerSO _fishSpeciesDataManagerSO = null;

        [Space]
        [Header("Fishing Equipment Data - RODS")]
        [SerializeField] private FishingRodDataManagerSO _fishingRodsDataManagerSO = null;

        [Header("Fishing Equipment Data - REELS")]
        [SerializeField] private FishingReelDataManagerSO _fishingReelsDataManagerSO = null;

        [Header("Fishing Equipment Data - LINES")]
        [SerializeField] private FishingLineDataManagerSO _fishingLinesDataManagerSO = null;

        [Header("Fishing Equipment Data - LEADERS")]
        [SerializeField] private FishingLeaderDataManagerSO _fishingLeadersDataManagerSO = null;

        [Header("Fishing Equipment Data - BAITS")]
        [SerializeField] private FishingBaitDataManagerSO _fishingBaitsDataManagerSO = null;

        [Header("Fishing Equipment Data - HOOKS")]
        [SerializeField] private FishingHookDataManagerSO _fishingHooksDataManagerSO = null;

        [Header("Fishing Equipment Data - FLOATS")]
        [SerializeField] private FishingFloatDataManagerSO _fishingFloatsDataManagerSO = null;

        [Header("Fishing Equipment Data - FEEDERS")]
        [SerializeField] private FishingFeederDataManagerSO _fishingFeedersDataManagerSO = null;

        [Header("Fishing Equipment Data - WEIGHTS")]
        [SerializeField] private FishingWeightDataManagerSO _fishingWeightsDataManagerSO = null;

        [Header("Fishing Equipment Data - Accesories")]
        [SerializeField] private FishingAccessoryDataManagerSO _fishingAccessoriesDataManagerSO = null;

        [Header("Fishing Equipment Data - GROUNDBAITS")]
        [SerializeField] private FishingGroundbaitDataManagerSO _fishingGroundbaitsDataManagerSO = null;

        [Header("Fishing Equipment Data - PACKAGES")]
        [SerializeField] private FishingRodDataManagerSO _fishingPackagesDataManagerSO = null;

        [Header("Fishing Equipment Data - SETS")]
        [SerializeField] private FishingRodDataManagerSO _fishingSetsDataManagerSO = null;

        [Space]
        [Header("Game Data - DLCs")]
        [SerializeField] private FishingRodDataManagerSO _gameDLCDataManagerSO = null;

        [Header("Game Data - QUESTS")]
        [SerializeField] private FishingRodDataManagerSO _gameQuestsDataManagerSO = null;
        */
        #endregion

        #region MonoBehaviours Callbacks

        private void Awake()
        {
            InitDataManagers();
        }

        private void Start()
        {
           
            //InvokeRepeating(nameof(DoPoolExample), 1f, .5f);
            //Invoke(nameof(DoPoolExample), 2f);
            //DoPoolExample();
        }

        #endregion 

        #region Public Methods | Game Data Management | Fish SPECIES 

        /*
        /// <returns>Number of existed FishSpecies SOs</returns>
        public int GetFishSpeciesCount()
        {
            if (_isDebug)
            {
                Debug.Log(name + " |  GetFishSpeciesCount() >>  " + _fishSpeciesDataManagerSO.GameDataSOCount);
            }

            return _fishSpeciesDataManagerSO.GameDataSOCount;
        }
       
        public FishSpeciesSO[] GetFishSpeciesArray()
        {
            return _fishSpeciesDataManagerSO.GetGameDataArray();
        }
       

        /// <param name="fishSpecies">Single FishSpecies SO including all Data & Methods</param>
        /// <returns></returns>
        public FishSpeciesSO GetSingleFishSpecies(FishSpecies fishSpecies)
        {
            return _fishSpeciesDataManagerSO.GetSingleGameDataSO(fishSpecies);
        }
        */

        #endregion

        #region Public Methods | Game Data Management | Fishing RODS

        /*
        /// <returns>Number of existed Fishing Rods SOs</returns>
        public int GetFishingRodIDCount()
        {
            if (_isDebug)
            {
                Debug.Log(name + " |  GetFishingRodIDCount() >>  " + _fishingRodsDataManagerSO.GameDataSOCount);
            }

            return _fishingRodsDataManagerSO.GameDataSOCount;
        }

        public FishingRodSO[] GetFishingRodsArray()
        {
            return _fishingRodsDataManagerSO.GetGameDataArray();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fishingRodID"></param>
        /// <returns>Single Fishing Rod SO including all Data & Methods</returns>
        public FishingRodSO GetSingleFishingRod(int fishingRodID)
        {
            return _fishingRodsDataManagerSO.GetSingleGameDataSO((FishingRod)fishingRodID);
        }
*/
        #endregion

        #region Private methods

        private void InitDataManagers()
        {
            /*
            _fishSpeciesDataManagerSO.InitIfNeeded();

            _fishingRodsDataManagerSO.InitIfNeeded();
            _fishingReelsDataManagerSO.InitIfNeeded();

            _fishingLinesDataManagerSO.InitIfNeeded();
            _fishingLeadersDataManagerSO.InitIfNeeded();

            _fishingBaitsDataManagerSO.InitIfNeeded();
            _fishingHooksDataManagerSO.InitIfNeeded();
            _fishingFloatsDataManagerSO.InitIfNeeded();
            _fishingFeedersDataManagerSO.InitIfNeeded();
            _fishingWeightsDataManagerSO.InitIfNeeded();

            _fishingAccessoriesDataManagerSO.InitIfNeeded();
            _fishingGroundbaitsDataManagerSO.InitIfNeeded();
            */
        }

        /// <summary>
        /// Just an example of use
        /// </summary>
        private void DoPoolExample()
        {


            for (int i = 0; i < 5; i++)
            {
                Debug.Log(name + " | SPAWN TEST | >> " );
               // var testCubeBlue = UIPrefabsPooler.Instance.SpawnFromPool<PoolTestCubeBlue>(FishSpecies.SharkTiger, 0); // point cursor to SpawnFromPool for tips

               
                if (i > 3)
                {
                   // UIPrefabsPooler.Instance.ReturnToPool(testCubeBlue);
                }
            }

            /*
            for (int i = 0; i < 8; i++)
            {
                var testCubeRed = UIPrefabsPooler.Instance.SpawnFromPool<PoolTestCubeRed>();

                UIPrefabsPooler.Instance.ReturnToPool(testCubeRed); // point cursor to ReturnToPool for tips
            }

            for (int i = 0; i < 8; i++)
            {
                UIPrefabsPooler.Instance.SpawnFromPool<PoolTestCubeGreen>();
            }

            UIPrefabsPooler.Instance.SwitchActivityStateOfAllPooledObjects<PoolTestCubeGreen>(); //  point cursor to SwitchActivityStateOfAllPooledObjects for details
            */
        }

        #endregion
    }
}
