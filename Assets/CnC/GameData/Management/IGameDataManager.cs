namespace CnC.GameData
{
    public interface IGameDataManager<GenericEnumID, SOType>
    {
        /// <summary>
        /// Property (readonly) - number of currently registered SO of given Type based on enum
        /// </summary>
        int GameDataSOCount { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        SOType[] GetGameDataArray();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SOType GetSingleGameDataSO(GenericEnumID id);

        void LoadDataToDictionary();

        void LoadDataFromResources();
    }
}
