/// dystop.us | 08.02.2023
namespace CnC.GameData
{
    /// <summary>
    /// Note: "CAM" stands here for Create Asset Menu
    /// </summary>
    public class GameDataUtils
    {
        
        #region Create Asset Menu

        // General
        public const string CAMRoot = "UFS2/";

        // Specific roots
        public const string CAMGameDataRoot = "Game Data/";
        public const string CAMEquipmentRoot = "Fishing Equipment/";
        public const string CAMDevToolsRoot = "Dev Tools";

        // Menu Options
        public const string CAMNewManager = "/New Data Manager";
        public const string CAMNewDataFile = "/New Data File";

        public const string PostfixForDataSO = "Data_";

        // CAM Dev Tools SO 
        public const string DevToolsConfigSOFileName = "DevToolsConfigData";

        #endregion

        #region Models / prefabs Paths

        public const string ResourcesItemsPrefabs = "GameItemsPrefabs/";

        #endregion

        #region Images Paths

        public const string ResourcesIcons = "Icons/";

        public const string ResourcesBrands = "Brand Loga/";

        public const string ResourcesRenders = "Renders/";

        public const string ResourcesLines = "Lines/";

        #endregion
    }
}
