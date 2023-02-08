/// dystop.us | 08.02.2023
using UnityEngine;

using CnC.Dev;
using CnC.Utils;
using CnC.Events;

namespace CnC.Dev
{
    /// <summary>
    /// Note: these are <b>developer tools</b>, so there will be no details provided on how they work etc.
    /// </summary>
    public class DevCheatManager : DevBehaviour
    {
        #region Serialized private fields | Keyboard Shortcuts

        #endregion

        #region Serialized private fields

        [SerializeField] private DevCheatManagerWindow _windowReference;

        [Header("Array of provided Gameplay cheats")]
        [SerializeField] private DevCheatEntrySerializable<GameplayEvent>[] _providedGameplayCheats;

        #endregion

        #region MonoBehaviours

        private void Awake()
        {
            
        }
        private void Start()
        {
            _windowReference = DevFacade.GetDevToolWindow<DevCheatManagerWindow>(); 
            this.DevLog("window reference " + DevFacade.GetDevToolWindow<DevCheatManagerWindow>());
        }

        #endregion

        #region Private methods


        #endregion
    }
}
